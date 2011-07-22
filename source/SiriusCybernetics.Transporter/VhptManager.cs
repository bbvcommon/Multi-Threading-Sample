namespace SiriusCybernetics
{
    using System.Collections.Generic;
    using bbv.Common.AsyncModule;

    /// <summary>
    /// Manages the happy people transporters
    /// </summary>
    public class VhptManager : IVhptManager
    {
        private readonly List<IVhpt> vhpts;

        public VhptManager()
        {
            var freddyTours = new Vhpt("Freddy Tours", 1000, new ModuleController());
            freddyTours.Initialize();

            var sonamar = new Vhpt("Sonamar", 1000, new ModuleController());
            sonamar.Initialize();

            this.vhpts = new List<IVhpt>
                             {
                                 freddyTours,
                                 sonamar
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