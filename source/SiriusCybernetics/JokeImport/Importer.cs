namespace SiriusCybernetics.JokeImport
{
    using System.ComponentModel;

    using bbv.Common.Async;
    using bbv.Common.Threading;

    public class Importer : IImporter, IImportCanceler
    {
        private readonly AsyncWorker asyncWorker;
        private readonly IJokeImporter jokeImporter;
        private readonly IJokeOracle jokeOracle;

        private readonly IJokeImportProgressDialogFactory importDialogFactory;

        private readonly IUserInterfaceThreadSynchronizer uiSynchronizer;

        private bool cancel;

        public Importer(IJokeOracle jokeOracle, IJokeImporter jokeImporter, IJokeImportProgressDialogFactory importDialogFactory, IUserInterfaceThreadSynchronizer uiSynchronizer)
        {
            this.jokeOracle = jokeOracle;
            this.jokeImporter = jokeImporter;
            this.importDialogFactory = importDialogFactory;
            this.uiSynchronizer = uiSynchronizer;

            this.asyncWorker = new AsyncWorker(this.ImportJokesWorker);
        }

        public void ImportJokes()
        {
            if (this.IsImportAlreadyRunning())
            {
                return;
            }

            this.cancel = false;
            this.asyncWorker.RunWorkerAsync();
        }

        public void CancelImport()
        {
            this.cancel = true;
        }

        private bool IsImportAlreadyRunning()
        {
            return this.asyncWorker.IsBusy;
        }

        private void ImportJokesWorker(object sender, DoWorkEventArgs e)
        {
            IJokeImportProgressDialog importDialog = this.CreateAndShowProgressDialog();

            this.Import(importDialog);

            this.CloseProgressDialog(importDialog);
        }

        private void Import(IJokeImportProgressDialog importDialog)
        {
            for (int i = 0; i < 100 && !this.cancel; i++)
            {
                this.ImportJoke(i, importDialog);
            }
        }

        private void ImportJoke(int i, IJokeImportProgressDialog importDialog)
        {
            string joke = this.jokeOracle.CreateJoke();
            this.jokeImporter.ImportJoke(joke);

            this.uiSynchronizer.ExecuteAsync(() => importDialog.ShowProgress("imported " + (i + 1) + " jokes"));
        }

        private IJokeImportProgressDialog CreateAndShowProgressDialog()
        {
            IJokeImportProgressDialog importDialog = null;

            this.uiSynchronizer.Execute(() =>
                {
                    importDialog = this.importDialogFactory.CreateImportDialog();
                    importDialog.Show();
                });
            return importDialog;
        }

        private void CloseProgressDialog(IJokeImportProgressDialog importDialog)
        {
            this.uiSynchronizer.Execute(importDialog.Close);
        }
    }
}