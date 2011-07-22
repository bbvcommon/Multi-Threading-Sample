namespace SiriusCybernetics
{
    using System;
    using bbv.Common.Events;

    /// <summary>
    /// Vertical happy people transporter.
    /// </summary>
    public interface IVhpt
    {
        /// <summary>
        /// Fired when a user pressed the call button on a floor. The VHPT will move to the floor where the user
        /// pressed the call button. If there is already a passenger on it, then it will first go to
        /// the requested destination, and afterwards to the requested floor.
        /// </summary>
        event EventHandler<FloorEventArgs> ReceivedTransportationRequest;

        /// <summary>
        /// Fired when a passenger chose the destination after entering the transporter.
        /// </summary>
        event EventHandler<FloorEventArgs> ReceivedDestinationRequest;

        /// <summary>
        /// Fired when the HPTV has reached a requested destination and the passanger has left the VHPT. That means that for
        /// the people to be happy they have to be out of the VHPT to have reached the destination.
        /// </summary>
        event EventHandler<FloorEventArgs> ReachedDestination;

        /// <summary>
        /// Fired when ever the VHPT reaches (or even only passes) a floor.
        /// </summary>
        event EventHandler<FloorEventArgs> ReachedFloor;

        /// <summary>
        /// Fired when ever the VHPT leaves (or even only passes) a floor.
        /// </summary>
        event EventHandler<FloorEventArgs> LeftFloor;

        /// <summary>
        /// Fired when the passenger enters the VHPT.
        /// </summary>
        event EventHandler PassengerEnteredTransporter;

        /// <summary>
        /// Fired when the passenger left the VHPT.
        /// </summary>
        event EventHandler PassengerLeftTransporter;

        /// <summary>
        /// Fired when the VHPT detects that the passenger is unhappy.
        /// The GUID passed in the event args is the <see cref="Id"/> of this VHPT.
        /// </summary>
        event EventHandler<EventArgs<Guid>> UnhappyPassengerOnBoard;

        /// <summary>
        /// Gets the Id of the VHPT.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets the name of the transporter.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Turns the transporter on.
        /// After the VHPT is powered on it will start to react on people wanting to
        /// use it (normally when the user presses the call button on a floor)
        /// Returns the floor on which the VHPT currently is.
        /// </summary>
        /// <returns></returns>
        int PowerOn();

        /// <summary>
        /// Turns the VHPT off.
        /// The VHPT will stop responding to user requests for transportation. 
        /// And it will power off immediately, even if there are still people on board! Therefore
        /// this method must only be called if there are no passengers! Furthermore it is not allowed 
        /// to call this method if already a request for transportation was received. Otherwise this would
        /// lead to unhappy people.
        /// </summary>
        void PowerOff();

        /// <summary>
        /// Tells a joke to the passenger.
        /// </summary>
        /// <param name="joke">The joke to tell.</param>
        void TellJoke(string joke);
    }
}

