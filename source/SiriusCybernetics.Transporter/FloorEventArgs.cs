namespace SiriusCybernetics
{
    using System;

    public class FloorEventArgs : EventArgs
    {
        public FloorEventArgs(int floor)
        {
            this.Floor = floor;
        }

        public int Floor { get; private set; }
    }
}