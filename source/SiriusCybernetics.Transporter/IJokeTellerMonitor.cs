namespace SiriusCybernetics
{
    using System;
    using bbv.Common.Events;

    public interface IJokeTellerMonitor
    {
        event EventHandler<EventArgs<string>> ToldJoke;
    }
}