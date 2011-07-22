namespace SiriusCybernetics
{
    using System.Collections.Generic;

    /// <summary>
    /// Manages the happy people transporters
    /// </summary>
    public class VhptManager : IVhptManager
    {
        private readonly List<IVhpt> vhpts;

        public VhptManager()
        {
            this.vhpts = new List<IVhpt>
                             {
                                 new Vhpt("Freddy Tours", 1000),
                                 new Vhpt("Sonamar", 1000)
                             };
        }

        /// <summary>
        /// Returns all vertical happy people transporters of the building.
        /// </summary>
        /// <returns>vertical happy people transporters.</returns>
        public IEnumerable<IVhpt> GetAllVhpts()
        {
            return this.vhpts;
        }
    }
}