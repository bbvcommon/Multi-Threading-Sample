namespace SiriusCybernetics
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;

    using bbv.Common.AsyncModule;
    using bbv.Common.EventBroker;
    using bbv.Common.StateMachine;
    using bbv.Common.Threading;

    using SiriusCybernetics.JokeImport;
    using SiriusCybernetics.JokeTelling;

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var eventBroker = new EventBroker();

            IVhptManager vhptManager = new VhptManager();
            var vhpts = vhptManager.GetAllVhpts();

            var controllers = from vhpt in vhpts 
                              select CreateVhptController(vhpt, eventBroker);

            foreach (var vhptController in controllers)
            {
                eventBroker.Register(vhptController);

                vhptController.Initialize();
            }

            var mainForm = new MainForm();
            var importDialogFactory = new JokeImportProgressDialogFactory();
            var importer = new Importer(new JokeOracle(), new JokeImporter(), importDialogFactory, new UserInterfaceThreadSynchronizer());

            importDialogFactory.Initialize(mainForm, importer);
            
            mainForm.Initialize(
                new VhptUserControlFactory(eventBroker),
                from vhpt in vhpts select new VhptIdentification(vhpt.Id, vhpt.Name),
                importer);

            eventBroker.Register(mainForm);

            Application.Run(mainForm);
        }

        private static VhptController CreateVhptController(IVhpt vhpt, EventBroker eventBroker)
        {
            var jokeTeller = new JokeTeller(new ModuleController(), new JokeEngine());
            jokeTeller.Initialize();
            eventBroker.Register(jokeTeller);

            return new VhptController(vhpt, new ActiveStateMachine<VhptStates, VhptEvents>(), jokeTeller);
        }

        public class JokeOracle : IJokeOracle
        {
            public string CreateJoke()
            {
                Thread.Sleep(50);

                return "joke";
            }
        }

        public class JokeImporter : IJokeImporter
        {
            public void ImportJoke(string joke)
            {
            }
        }

        public class JokeEngine : IJokeEngine
        {
            public string GetJoke()
            {
                return "a VHPT enters a bar ...";
            }
        }
    }
}
