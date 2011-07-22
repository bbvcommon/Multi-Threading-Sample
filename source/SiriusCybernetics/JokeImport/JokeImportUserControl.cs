namespace SiriusCybernetics.JokeImport
{
    using System;
    using System.Windows.Forms;

    public partial class JokeImportUserControl : UserControl
    {
        private IImporter jokeImporter;

        public JokeImportUserControl()
        {
            InitializeComponent();
        }

        public void Initialize(IImporter importer)
        {
            this.jokeImporter = importer;
        }

        private void HandleImportJokesClick(object sender, EventArgs e)
        {
            this.jokeImporter.ImportJokes();
        }
    }
}
