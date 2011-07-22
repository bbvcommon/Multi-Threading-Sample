//-------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="bbv Software Services AG">
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
    using System.Collections.Generic;
    using System.Windows.Forms;

    using bbv.Common.EventBroker;

    using SiriusCybernetics.JokeImport;

    public partial class MainForm : Form, IEventBrokerRegisterable
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void Initialize(
            IVhptUserControlFactory vhptUserControlFactory,
            IEnumerable<VhptIdentification> vhpts,
            IImporter importer)
        {
            this.InitializeJokeImport(importer);
            this.InitializeVhpts(vhpts, vhptUserControlFactory);
        }

        public void Register(IEventRegisterer eventRegisterer)
        {
            eventRegisterer.Register(this.jokeTellingMonitorUserControl);
        }

        public void Unregister(IEventRegisterer eventRegisterer)
        {
            eventRegisterer.Unregister(this.jokeTellingMonitorUserControl);
        }

        private void InitializeJokeImport(IImporter importer)
        {
            this.jokeImport.Initialize(importer);
        }

        private void InitializeVhpts(IEnumerable<VhptIdentification> vhpts, IVhptUserControlFactory vhptUserControlFactory)
        {
            foreach (var vhptId in vhpts)
            {
                var vhptControl = vhptUserControlFactory.CreateUserControl(vhptId);

                var tabPage = new TabPage(vhptId.Name);
                tabPage.Controls.Add(vhptControl);
                this.vhpts.TabPages.Add(tabPage);
            }
        }
    }
}
