namespace SiriusCybernetics
{
    /// <summary>
    /// Oracle that can create new jokes to be imported.
    /// </summary>
    public interface IJokeOracle
    {
        /// <summary>
        /// Creates a new joke (very time consuming operation!).
        /// </summary>
        /// <returns>A new joke.</returns>
        string CreateJoke();
    }
}