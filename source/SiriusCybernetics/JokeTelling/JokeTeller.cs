namespace SiriusCybernetics.JokeTelling
{
    using System;

    using bbv.Common.AsyncModule;
    using bbv.Common.EventBroker;

    public interface IJokeTeller
    {
        void TellJoke(IVhpt vhpt);
    }

    public class JokeTeller : IJokeTeller
    {
        private readonly IModuleController controller;

        private readonly IJokeEngine jokeEngine;

        [EventPublication(EventTopics.ToldJoke)]
        public event EventHandler ToldJoke;

        public JokeTeller(IModuleController controller, IJokeEngine jokeEngine)
        {
            this.controller = controller;
            this.jokeEngine = jokeEngine;
        }

        public void Initialize()
        {
            this.controller.Initialize(this, true);
            this.controller.Start();
        }

        public void TellJoke(IVhpt vhpt)
        {
            this.controller.EnqueueMessage(vhpt);
        }

        [MessageConsumer]
        public void ConsumeTellJoke(IVhpt vhpt)
        {
            var joke = this.jokeEngine.GetJoke();

            vhpt.TellJoke(joke);

            this.OnToldJoke();
        }

        private void OnToldJoke()
        {
            if (this.ToldJoke != null)
            {
                this.ToldJoke(this, EventArgs.Empty);
            }
        }
    }
}