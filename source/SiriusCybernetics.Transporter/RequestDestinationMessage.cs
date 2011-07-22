namespace SiriusCybernetics
{
    public class RequestDestinationMessage
    {
        public RequestDestinationMessage(int floor)
        {
            this.Floor = floor;
        }

        public int Floor { get; private set; }
    }
}