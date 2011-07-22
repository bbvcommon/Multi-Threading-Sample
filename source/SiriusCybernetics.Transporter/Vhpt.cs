namespace SiriusCybernetics
{
    using System;
    using System.Threading;
    using bbv.Common.AsyncModule;
    using bbv.Common.AsyncModule.Events;
    using bbv.Common.Events;

    public class Vhpt : IVhpt, IJokeTellerMonitor, IVhptRemoteControl
    {
        private readonly int timeDilatationFactor;
        private int currentFloor;
        private readonly Random random;
        private ModuleController asyncModule;

        public Vhpt(string name, int timeDilatationFactor)
        {
            this.timeDilatationFactor = timeDilatationFactor;
            this.Name = name;
            this.Id = Guid.NewGuid();

            this.currentFloor = 0;

            this.random = new Random();

            this.asyncModule = new ModuleController();
            this.asyncModule.Initialize(this);
            this.asyncModule.AfterConsumeMessage += this.HandleAfterConsumeMessage;
            this.asyncModule.Start();
        }

        private void HandleAfterConsumeMessage(object sender, AfterConsumeMessageEventArgs e)
        {
            if (e.Message.GetType() == typeof(RequestTransportationMessage))
            {
                this.RaiseRequestTransportationCompleted();
            }
            else if (e.Message.GetType() == typeof(RequestDestinationMessage))
            {
                this.RaiseRequestDestinationCompleted();
            }
        }

        private void RaiseRequestTransportationCompleted()
        {
            if (this.RequestTransportationCompleted!= null)
            {
                this.RequestTransportationCompleted(this, EventArgs.Empty);
            }
        }

        private void RaiseRequestDestinationCompleted()
        {
            if (this.RequestDestinationCompleted != null)
            {
                this.RequestDestinationCompleted(this, EventArgs.Empty);
            }
        }

        public event EventHandler<EventArgs<string>> ToldJoke;
        public event EventHandler<FloorEventArgs> ReceivedTransportationRequest;
        public event EventHandler<FloorEventArgs> ReceivedDestinationRequest;
        public event EventHandler<FloorEventArgs> ReachedDestination;
        public event EventHandler<FloorEventArgs> ReachedFloor;
        public event EventHandler<FloorEventArgs> LeftFloor;
        public event EventHandler PassengerEnteredTransporter;
        public event EventHandler PassengerLeftTransporter;
        public event EventHandler<EventArgs<Guid>> UnhappyPassengerOnBoard;
        public event EventHandler RequestTransportationCompleted;
        public event EventHandler RequestDestinationCompleted;

        /// <summary>
        /// Gets the Id of the VHPT.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the name of the transporter.
        /// </summary>
        public string Name { get; private set; }


        /// <summary>
        /// Requests the transportation on the specified floor calling the vhpt.
        /// </summary>
        /// <param name="floor">The floor.</param>
        public void RequestTransportationAsync(int floor)
        {
            this.asyncModule.EnqueueMessage(new RequestTransportationMessage(floor));
        }

        /// <summary>
        /// Turns the transporter on.
        /// After the VHPT is powered on it will start to react on people wanting to
        /// use it (normally when the user presses the call button on a floor)
        /// Returns the floor on which the VHPT currently is.
        /// </summary>
        /// <returns></returns>
        public int PowerOn()
        {
            return this.currentFloor;
        }

        /// <summary>
        /// Turns the VHPT off.
        /// The VHPT will stop responding to user requests for transportation. 
        /// And it will power off immediately, even if there are still people on board! Therefore
        /// this method must only be called if there are no passengers! Furthermore it is not allowed 
        /// to call this method if already a request for transportation was received. Otherwise this would
        /// lead to unhappy people.
        /// </summary>
        public void PowerOff()
        {
        }

        /// <summary>
        /// Tells a joke to the passenger.
        /// </summary>
        /// <param name="joke">The joke to tell.</param>
        public void TellJoke(string joke)
        {
            this.RaiseJokeTold(joke);
        }

        /// <summary>
        /// Requests the vpht to move to the specified destination floor.
        /// </summary>
        /// <param name="floor">The floor.</param>
        public void RequestDestinationAsync(int floor)
        {
            this.asyncModule.EnqueueMessage(new RequestDestinationMessage(floor));
        }

        [MessageConsumer]
        public void RequestDestination(RequestDestinationMessage message)
        {
            this.RaisePassengerEnteredTransporter();
            this.Delay(3);
            this.ProbablyRaiseUnhappyPassengerOnBoard();
            this.Delay(3);
            this.RaiseReceivedDestinationRequest(message.Floor);
            this.Delay(2);

            this.MoveToFloor(message.Floor);
            this.Delay(2);
            this.RaisePassengerLeftTransporter();

            this.RaiseReachedDestination(message.Floor);
        }

        [MessageConsumer]
        public void RequestTransportation(RequestTransportationMessage message)
        {
            this.RaiseReceivedTransportationRequest(message.Floor);
            this.Delay(3);

            this.MoveToFloor(message.Floor);
        }

        private void ProbablyRaiseUnhappyPassengerOnBoard()
        {
            if (this.random.Next(2) == 0)
            {
                if (this.UnhappyPassengerOnBoard != null)
                {
                    this.UnhappyPassengerOnBoard(this, new EventArgs<Guid>(this.Id));
                }
            }
        }

        private void RaiseReachedDestination(int floor)
        {
            if (this.ReachedDestination != null)
            {
                this.ReachedDestination(this, new FloorEventArgs(floor));
            }
        }

        private void RaiseReceivedDestinationRequest(int floor)
        {
            if (this.ReceivedDestinationRequest != null)
            {
                this.ReceivedTransportationRequest(this, new FloorEventArgs(floor));
            }
        }

        private void RaiseReceivedTransportationRequest(int floor)
        {
            if (this.ReceivedTransportationRequest != null)
            {
                this.ReceivedTransportationRequest(this, new FloorEventArgs(floor));
            }
        }

        private void RaisePassengerLeftTransporter()
        {
            if (this.PassengerLeftTransporter != null)
            {
                this.PassengerLeftTransporter(this, EventArgs.Empty);
            }
        }

        private void RaisePassengerEnteredTransporter()
        {
            if (this.PassengerEnteredTransporter != null)
            {
                this.PassengerEnteredTransporter(this, EventArgs.Empty);
            }
        }

        private void MoveToFloor(int floor)
        {
            if (this.currentFloor < floor)
            {
                this.MoveUpToFloor(floor);
            }

            if (this.currentFloor > floor)
            {
                this.MoveDownToFloor(floor);
            }
        }

        private void MoveDownToFloor(int floor)
        {
            while (floor < this.currentFloor)
            {
                this.RaiseLeftFloor(this.currentFloor);
                this.Delay(2);
                this.currentFloor--;
                this.RaiseReachedFloor(this.currentFloor);
                this.Delay(2);
            }
        }

        private void RaiseReachedFloor(int floor)
        {
            if (this.ReachedFloor != null)
            {
                this.ReachedFloor(this, new FloorEventArgs(floor));
            }
        }

        private void RaiseLeftFloor(int floor)
        {
            if (this.LeftFloor != null)
            {
                this.LeftFloor(this, new FloorEventArgs(floor));
            }
        }

        private void MoveUpToFloor(int floor)
        {
            while (floor > this.currentFloor)
            {
                this.RaiseLeftFloor(this.currentFloor);
                this.Delay(2);
                this.currentFloor++;
                this.RaiseReachedFloor(this.currentFloor);
                this.Delay(2);
            }
        }

        private void RaiseJokeTold(string joke)
        {
            if (this.ToldJoke != null)
            {
                this.ToldJoke(this, new EventArgs<string>(joke));
            }
        }

        private void Delay(int seconds)
        {
            Thread.Sleep(seconds * this.timeDilatationFactor);
        }
    }
}