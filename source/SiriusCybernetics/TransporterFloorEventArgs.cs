namespace SiriusCybernetics
{
    public class TransporterFloorEventArgs : FloorEventArgs
    {
        public TransporterFloorEventArgs(VhptIdentification vhptIdentification, int floor) : base(floor)
        {
            this.VhptIdentification = vhptIdentification;
        }

        public VhptIdentification VhptIdentification { get; private set; }
    }
}