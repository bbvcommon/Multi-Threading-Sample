//-------------------------------------------------------------------------------
// <copyright file="VhptController.cs" company="bbv Software Services AG">
//   Copyright (c) 2008-2010 bbv Software Services AG
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace SiriusCybernetics
{
    using System;
    using bbv.Common.EventBroker;
    using bbv.Common.EventBroker.Handlers;
    using bbv.Common.StateMachine;

    public enum VhptStates
    {
        Off,
        On,
        Idle,
        PickingUp,
        PassengerOnBoard,
        TransportingPassenger,
    }

    public enum VhptEvents
    {
        PowerOn,
        PowerOff,
        ReceivedTransportationRequest,
        PassengerEntered,
        PassengerLeft,
        ReachedDestination
    }

    public class VhptController : IVhptIdentificationProvider
    {
        private readonly IVhpt vhpt;

        private VhptIdentification vhptIdentification;

        private readonly IStateMachine<VhptStates, VhptEvents> stateMachine;

        private readonly JokeTelling.IJokeTeller jokeTeller;

        public VhptController(IVhpt vhpt, IStateMachine<VhptStates, VhptEvents> stateMachine, JokeTelling.IJokeTeller jokeTeller)
        {
            this.vhpt = vhpt;
            this.stateMachine = stateMachine;
            this.jokeTeller = jokeTeller;

            this.vhptIdentification = new VhptIdentification(this.vhpt.Id, this.vhpt.Name);

            this.RegisterVhptEvents();
            this.InitialzeStateMachine();
        }

        public void Initialize()
        {
            this.stateMachine.Start();    
        }

        private void RegisterVhptEvents()
        {
            this.vhpt.ReceivedTransportationRequest += (s, e) => this.stateMachine.Fire(VhptEvents.ReceivedTransportationRequest, e);
            this.vhpt.PassengerEnteredTransporter += (s, e) => this.stateMachine.Fire(VhptEvents.PassengerEntered);
            this.vhpt.PassengerLeftTransporter += (s, e) => this.stateMachine.Fire(VhptEvents.PassengerLeft);
            this.vhpt.ReachedDestination += (s, e) => this.stateMachine.Fire(VhptEvents.ReachedDestination);

            this.vhpt.ReceivedDestinationRequest += (s, e) => this.OnReceivedDestinationRequest(e);
            this.vhpt.ReachedFloor += (s, e) => this.OnReachedFloor(new TransporterFloorEventArgs(new VhptIdentification(this.vhpt.Id, this.vhpt.Name), e.Floor));

            this.vhpt.PassengerEnteredTransporter += (s, e) => this.OnPassengerEntered();
            this.vhpt.PassengerLeftTransporter += (s, e) => this.OnPassengerLeft();

            this.vhpt.UnhappyPassengerOnBoard += (s, e) => this.jokeTeller.TellJoke(this.vhpt);
        }

        public void OnReceivedDestinationRequest(FloorEventArgs floorEventArgs)
        {
            if (this.ReceivedDestinationRequest != null)
            {
                this.ReceivedDestinationRequest(this, floorEventArgs);
            }
        }

        public void OnReachedFloor(TransporterFloorEventArgs floorEventArgs)
        {
            if (this.ReachedFloor != null)
            {
                this.ReachedFloor(this, floorEventArgs);
            }
        }
        
        public void OnPassengerEntered()
        {
            if (this.PassengerEntered != null)
            {
                this.PassengerEntered(this, EventArgs.Empty);
            }
        }

        public void OnPassengerLeft()
        {
            if (this.PassengerLeft != null)
            {
                this.PassengerLeft(this, EventArgs.Empty);
            }
        }

        [EventPublication(EventTopics.PowerOn)]
        public event EventHandler PowerOn;

        [EventPublication(EventTopics.PowerOff)]
        public event EventHandler PowerOff;

        [EventPublication(EventTopics.ReachedFloor)]
        public event EventHandler<FloorEventArgs> ReachedFloor;

        [EventPublication(EventTopics.ReceivedDestinationRequest)]
        public event EventHandler<FloorEventArgs> ReceivedDestinationRequest;
        
        [EventPublication(EventTopics.PassengerEntered)]
        public event EventHandler PassengerEntered;

        [EventPublication(EventTopics.PassengerLeft)]
        public event EventHandler PassengerLeft;


        private void InitialzeStateMachine()
        {
            this.stateMachine.DefineHierarchyOn(VhptStates.On, VhptStates.Idle, HistoryType.None, VhptStates.Idle, VhptStates.PassengerOnBoard, VhptStates.PickingUp, VhptStates.TransportingPassenger);

            this.stateMachine.In(VhptStates.Off)
                .On(VhptEvents.PowerOn)
                    .Goto(VhptStates.On).Execute(this.OnPowerOn);

            this.stateMachine.In(VhptStates.On)
               .On(VhptEvents.PowerOff)
                   .Goto(VhptStates.Off).Execute(this.OnPowerOff);

            this.stateMachine.In(VhptStates.Idle)
                .On(VhptEvents.ReceivedTransportationRequest)
                    .Goto(VhptStates.PickingUp).Execute<FloorEventArgs>(this.PickUp);

            this.stateMachine.In(VhptStates.PickingUp)
                .On(VhptEvents.PassengerEntered)
                    .Goto(VhptStates.PassengerOnBoard);

            this.stateMachine.In(VhptStates.PassengerOnBoard)
                .On(VhptEvents.ReceivedTransportationRequest).Goto(VhptStates.TransportingPassenger);

            this.stateMachine.In(VhptStates.TransportingPassenger)
                .On(VhptEvents.ReachedDestination).Goto(VhptStates.Idle);

            this.stateMachine.Initialize(VhptStates.Off);
        }

        private void OnPowerOn()
        {
            var floor = this.vhpt.PowerOn();

            if (this.PowerOn != null)
            {
                this.PowerOn(this, EventArgs.Empty);
            }

            this.OnReachedFloor(new TransporterFloorEventArgs(new VhptIdentification(this.vhpt.Id, this.vhpt.Name), floor));
        }

        private void OnPowerOff()
        {
            if (this.PowerOff != null)
            {
                this.PowerOff(this, EventArgs.Empty);
            }
        }

        private void PickUp(FloorEventArgs floorEventArgs)
        {
        }

        [EventSubscription(EventTopics.RequestPowerOn, typeof(Publisher), typeof(VhptMatcher))]
        public void HandlePowerOnRequest(object sender, EventArgs e)
        {
            this.stateMachine.Fire(VhptEvents.PowerOn);
        }

        [EventSubscription(EventTopics.RequestPowerOff, typeof(Publisher), typeof(VhptMatcher))]
        public void HandlePowerOffRequest(object sender, EventArgs e)
        {
            this.stateMachine.Fire(VhptEvents.PowerOff);
        }

        public VhptIdentification Identification
        {
            get { return this.vhptIdentification; }
        }
    }
}