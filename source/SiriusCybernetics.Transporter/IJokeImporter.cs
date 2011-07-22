namespace SiriusCybernetics
{
    /// <summary>
    /// Imports jokes into the joke engine.
    /// </summary>
    public interface IJokeImporter
    {
        /// <summary>
        /// Imports the specified joke into the joke engine.
        /// </summary>
        /// <param name="joke">The joke to import.</param>
        void ImportJoke(string joke);
    }
}