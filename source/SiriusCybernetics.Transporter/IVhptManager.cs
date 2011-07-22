namespace SiriusCybernetics
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides access to all vertical happy people transporters of a building.
    /// </summary>
    public interface IVhptManager
    {
        /// <summary>
        /// Returns all vertical happy people transporters of the building.
        /// </summary>
        /// <returns>vertical happy people transporters.</returns>
        IEnumerable<IVhpt> GetAllVhpts();
    }
}