namespace SiriusCybernetics
{
    using System;

    public interface IVhptRemoteControl
    {
        /// <summary>
        /// Gets the name of the transporter.
        /// </summary>
        string Name { get; }

        event EventHandler RequestTransportationCompleted;

        event EventHandler RequestDestinationCompleted;

        void RequestTransportationAsync(int floor);

        void RequestDestinationAsync(int floor);
    }
}