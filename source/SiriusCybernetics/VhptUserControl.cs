using System.Windows.Forms;

namespace SiriusCybernetics
{
    using System;
    using bbv.Common.EventBroker;
    using bbv.Common.EventBroker.Handlers;
    using bbv.Common.Events;

    public partial class VhptUserControl : UserControl, IVhptIdentificationProvider
    {
        VhptIdentification vhptId;

        public VhptUserControl()
        {
            InitializeComponent();
        }

        [EventPublication(EventTopics.RequestPowerOn)]
        public event EventHandler RequestPowerOn;
        
        [EventPublication(EventTopics.RequestPowerOff)]
        public event EventHandler RequestPowerOff;

        public void Initialize(VhptIdentification vhptId)
        {
            this.vhptId = vhptId;
        }

        [EventSubscription(EventTopics.PowerOn, typeof(UserInterface), typeof(VhptMatcher))]
        public void HandlePowerOn(object sender, EventArgs e)
        {
            this.ToggleButtons(true);
        }

        [EventSubscription(EventTopics.PowerOff, typeof(UserInterface), typeof(VhptMatcher))]
        public void HandlePowerOff(object sender, EventArgs e)
        {
            this.ToggleButtons(false);
        }

        [EventSubscription(EventTopics.ReachedFloor, typeof(UserInterface), typeof(VhptMatcher))]
        public void HandleReachedFloor(object sender, FloorEventArgs e)
        {
            this.lastFloor.Text = e.Floor.ToString();
        }

        [EventSubscription(EventTopics.ReceivedDestinationRequest, typeof(UserInterface), typeof(VhptMatcher))]
        public void HandleReceivedDestinationRequest(object sender, FloorEventArgs e)
        {
            this.destination.Text = e.Floor.ToString();
        }

        [EventSubscription(EventTopics.PassengerEntered, typeof(UserInterface), typeof(VhptMatcher))]
        public void HandlePassengerEntered(object sender, EventArgs e)
        {
            this.passengerOnBoard.Checked = true;
        }

        [EventSubscription(EventTopics.PassengerLeft, typeof(UserInterface), typeof(VhptMatcher))]
        public void HandlePassengerLeft(object sender, EventArgs e)
        {
            this.passengerOnBoard.Checked = false;
        }

        private void ToggleButtons(bool poweredOn)
        {
            this.powerOn.Enabled = !poweredOn;
            this.powerOff.Enabled = poweredOn;
        }

        private void HandlePowerOnClick(object sender, System.EventArgs e)
        {
            this.OnRequestPowerOn();
        }

        private void HandlePowerOffClick(object sender, System.EventArgs e)
        {
            this.OnRequestPowerOff();
        }

        private void OnRequestPowerOn()
        {
            if (this.RequestPowerOn != null)
            {
                this.RequestPowerOn(this, EventArgs.Empty);
            }
        }

        private void OnRequestPowerOff()
        {
            if (this.RequestPowerOff != null)
            {
                this.RequestPowerOff(this, EventArgs.Empty);
            }
        }

        //public void Register(IEventRegisterer eventRegisterer)
        //{
        //    var vhptMatcher = new VhptMatcher(this.vhptId);

        //    eventRegisterer.AddSubscription<EventArgs<VhptIdentification>>(
        //        EventTopics.RequestPowerOn,
        //        this,
        //        this.HandlePowerOn,
        //        new UserInterface(),
        //        vhptMatcher);

        //    eventRegisterer.AddSubscription<EventArgs<VhptIdentification>>(
        //        EventTopics.RequestPowerOff,
        //        this, 
        //        this.HandlePowerOff,
        //        new UserInterface(),
        //        vhptMatcher);

        //    eventRegisterer.AddSubscription<FloorEventArgs>(
        //        EventTopics.ReachedFloor,
        //        this,
        //        this.HandleReachedFloor,
        //        new UserInterface(),
        //        vhptMatcher);

        //    eventRegisterer.AddSubscription<FloorEventArgs>(
        //        EventTopics.ReceivedDestinationRequest,
        //        this,
        //        this.HandleReceivedDestinationRequest,
        //        new UserInterface(),
        //        vhptMatcher);

        //    eventRegisterer.AddSubscription<FloorEventArgs>(
        //        EventTopics.PassengerEntered,
        //        this,
        //        this.HandlePassengerEntered,
        //        new UserInterface(),
        //        vhptMatcher);
            
        //    eventRegisterer.AddSubscription<FloorEventArgs>(
        //        EventTopics.PassengerLeft,
        //        this,
        //        this.HandlePassengerLeft,
        //        new UserInterface(),
        //        vhptMatcher);
        //}

        public void Unregister(IEventRegisterer eventRegisterer)
        {
        }

        public VhptIdentification Identification
        {
            get { return this.vhptId; }
        }
    }
}
