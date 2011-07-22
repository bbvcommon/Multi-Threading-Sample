namespace SiriusCybernetics
{
    using System;
    using System.Windows.Forms;

    public partial class VhptRemoteUserControl : UserControl
    {
        private IVhptRemoteControl vhptRemoteControl;

        public VhptRemoteUserControl()
        {
            this.InitializeComponent();
        }

        public void Initialize(IVhptRemoteControl vhptRemoteControl)
        {
            this.vhptRemoteControl = vhptRemoteControl;
            this.vhptRemoteControl.RequestDestinationCompleted += this.HandleRequestDestinationCompleted;
            this.vhptRemoteControl.RequestTransportationCompleted += this.HandleRequestTransportationCompleted;

            this.vhptNameTextBox.Text = this.vhptRemoteControl.Name;
        }

        private void HandleRequestDestinationCompleted(object sender, EventArgs e)
        {
            this.requestDestinationButton.Enabled = true;
        }

        private void HandleRequestTransportationCompleted(object sender, EventArgs e)
        {
            this.requestTransportationButton.Enabled = true;
        }

        private void HandleRequestTransportationButtonClicked(object sender, System.EventArgs e)
        {
            this.requestTransportationButton.Enabled = false;
            this.vhptRemoteControl.RequestTransportationAsync(Convert.ToInt32(this.transportationFloor.Value));
        }

        private void HandleRequestDestinationButtonClicked(object sender, EventArgs e)
        {
            this.requestDestinationButton.Enabled = false;
            this.vhptRemoteControl.RequestDestinationAsync(Convert.ToInt32(this.destinationFloor.Value));
        }
    }
}
