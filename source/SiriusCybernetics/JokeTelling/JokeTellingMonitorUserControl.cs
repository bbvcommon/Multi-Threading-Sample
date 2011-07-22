namespace SiriusCybernetics.JokeTelling
{
    using System;
    using System.Windows.Forms;

    using bbv.Common.EventBroker;
    using bbv.Common.EventBroker.Handlers;

    public partial class JokeTellingMonitorUserControl : UserControl
    {
        private int numberOfToldJokes = 0;

        public JokeTellingMonitorUserControl()
        {
            InitializeComponent();

            this.UpdateUserInterface();
        }

        [EventSubscription(EventTopics.ToldJoke, typeof(UserInterface))]
        public void HandleToldJoke(object sender, EventArgs e)
        {
            this.numberOfToldJokes++;

            this.UpdateUserInterface();
        }

        private void UpdateUserInterface()
        {
            this.numberOfJokes.Text = this.numberOfToldJokes.ToString();
        }
    }
}
