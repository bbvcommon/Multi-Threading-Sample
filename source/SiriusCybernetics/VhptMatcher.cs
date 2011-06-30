//-------------------------------------------------------------------------------
// <copyright file="VhptMatcher.cs" company="bbv Software Services AG">
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
    using System.IO;
    using bbv.Common.EventBroker.Internals;
    using bbv.Common.EventBroker.Matchers;
    using bbv.Common.Events;

    public class VhptMatcher : ISubscriptionMatcher
    {
        public VhptMatcher()
        {
        }

        public bool Match(IPublication publication, ISubscription subscription, EventArgs e)
        {
            var publisher = publication.Publisher as IVhptIdentificationProvider;
            var subscriber = subscription.Subscriber as IVhptIdentificationProvider;

            return publisher != null && subscriber != null && publisher.Identification.Equals(subscriber.Identification);
        }

        public void DescribeTo(TextWriter writer)
        {
            writer.Write("matches publishers and subcribers providing the same VHPT identification");
        }
    }
}