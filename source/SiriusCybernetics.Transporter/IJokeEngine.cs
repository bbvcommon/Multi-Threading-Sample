namespace SiriusCybernetics
{
    /// <summary>
    /// Provides access to jokes.
    /// </summary>
    public interface IJokeEngine
    {
        /// <summary>
        /// Returns a new joke.
        /// </summary>
        /// <returns>A new joke.</returns>
        string GetJoke();
    }
}