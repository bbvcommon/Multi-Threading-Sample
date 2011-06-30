namespace SiriusCybernetics
{
    using bbv.Common.EventBroker;

    public class VhptUserControlFactory : IVhptUserControlFactory
    {
        readonly IEventBroker eventBroker;

        public VhptUserControlFactory(IEventBroker eventBroker)
        {
            this.eventBroker = eventBroker;
        }

        public VhptUserControl CreateUserControl(VhptIdentification vhptId)
        {
            var vhptUserControl = new VhptUserControl();

            vhptUserControl.Initialize(vhptId);

            this.eventBroker.Register(vhptUserControl);

            return vhptUserControl;
        }
    }
}