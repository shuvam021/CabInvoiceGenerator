namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        public double totalFare;
        public double average;
        public int numOfRides;

        public InvoiceSummary(int numOfRides, double totalFare)
        {
            this.numOfRides = numOfRides;
            this.totalFare = totalFare;
            this.average = this.totalFare / this.numOfRides;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is InvoiceSummary) && obj == null)
                return false;
            var item = (InvoiceSummary) obj;
            return this.numOfRides.Equals(item.numOfRides) && this.totalFare.Equals(item.totalFare) && this.average.Equals(item.average);
        }
    }
}
