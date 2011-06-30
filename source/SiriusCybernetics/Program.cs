using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SiriusCybernetics
{
    using bbv.Common.EventBroker;
    using bbv.Common.Events;
    using bbv.Common.StateMachine;

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
                              select new VhptController(vhpt, new ActiveStateMachine<VhptStates, VhptEvents>());

            foreach (var vhptController in controllers)
            {
                eventBroker.Register(vhptController);

                vhptController.Initialize();
            }

            var mainForm = new MainForm();

            mainForm.Initialize(
                new VhptUserControlFactory(eventBroker),
                from vhpt in vhpts select new VhptIdentification(vhpt.Id, vhpt.Name));

            Application.Run(mainForm);
        }
    }
}
