using CabInvoiceGenerator.Utils;

namespace CabInvoiceGenerator
{
    public class Ride
    {
        public double Distance { get; }
        public int Time { get; }

        public Ride(double distance, int time)
        {
            this.Distance = distance;
            this.Time = time;
        }
    }
}
