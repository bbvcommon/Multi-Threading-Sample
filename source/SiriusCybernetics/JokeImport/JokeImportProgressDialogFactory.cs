namespace SiriusCybernetics.JokeImport
{
    using System.Windows.Forms;

    public class JokeImportProgressDialogFactory : IJokeImportProgressDialogFactory
    {
        private IWin32Window owner;
        private IImportCanceler importCanceler;

        public void Initialize(IWin32Window owner, IImportCanceler importCanceler)
        {
            this.owner = owner;
            this.importCanceler = importCanceler;
        }

        public IJokeImportProgressDialog CreateImportDialog()
        {
            var d = new JokeImportProgressDialog();
            d.Initialize(this.owner, this.importCanceler);

            return d;
        }
    }
}