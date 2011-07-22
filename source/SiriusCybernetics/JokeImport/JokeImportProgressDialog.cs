namespace SiriusCybernetics.JokeImport
{
    using System.Windows.Forms;

    public partial class JokeImportProgressDialog : Form, IJokeImportProgressDialog
    {
        private IWin32Window owner;

        private IImportCanceler importCanceler;

        public JokeImportProgressDialog()
        {
            InitializeComponent();
        }

        public void Initialize(IWin32Window owner, IImportCanceler importCanceler)
        {
            this.owner = owner;
            this.importCanceler = importCanceler;
        }

        public new void Show()
        {
            this.Show(this.owner);
        }

        public void ShowProgress(string progressMessage)
        {
            this.progress.Text = progressMessage;
        }

        private void HandleCancelClick(object sender, System.EventArgs e)
        {
            this.importCanceler.CancelImport();
        }
    }
}
