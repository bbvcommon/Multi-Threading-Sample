namespace SiriusCybernetics.JokeTelling
{
    using bbv.Common.AsyncModule;

    public interface IJokeTeller
    {
        void TellJoke(IVhpt vhpt);
    }

    public class JokeTeller : IJokeTeller
    {
        private readonly IModuleController controller;

        private readonly IJokeEngine jokeEngine;

        public JokeTeller(IModuleController controller, IJokeEngine jokeEngine)
        {
            this.controller = controller;
            this.jokeEngine = jokeEngine;
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
        }
    }
}