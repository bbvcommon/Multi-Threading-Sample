namespace SiriusCybernetics.JokeImport
{
    public interface IJokeImportProgressDialog
    {
        void Show();

        void Close();

        void ShowProgress(string progressMessage);
    }
}