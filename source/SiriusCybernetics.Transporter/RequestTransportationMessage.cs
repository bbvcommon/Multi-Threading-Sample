namespace SiriusCybernetics
{
    public class RequestTransportationMessage
    {
        public RequestTransportationMessage(int floor)
        {
            this.Floor = floor;
        }

        public int Floor { get; private set; }
    }
}