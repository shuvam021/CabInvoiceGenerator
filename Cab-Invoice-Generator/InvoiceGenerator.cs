using System;
using CabInvoiceGenerator.Utils;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        RideType rideType;
        public readonly int MINIMUM_FAIR;
        public readonly int COST_PER_TIME;
        public readonly int MINIMUM_COST_PER_KM;

        /// <summary>Generate Cab Service Invoices</summary>
        public InvoiceGenerator(RideType type)
        {
            rideType = type;

            if (type == RideType.Normal)
            {
                this.MINIMUM_COST_PER_KM = 10;
                this.COST_PER_TIME = 1;
                this.MINIMUM_FAIR = 5;
            }
            else if (type == RideType.Premium)
            {
                this.MINIMUM_COST_PER_KM = 10;
                this.COST_PER_TIME = 1;
                this.MINIMUM_FAIR = 5;
            }
            else
            {
                throw new CabInvoiceException(ExceptionType.InvalidRideType);
            }
        }

        /// <summary>fare calculation from given travelled distance and spent time</summary>
        /// <param name="distance">distance in KM (non negative decimal value)</param>
        /// <param name="time">time in minute(non negative int value)</param>
        /// <returns>Returns Total fare in Double</returns>
        public double CalculateFare(double distance, int time)
        {
            if (distance <= 0)
                throw new CabInvoiceException(ExceptionType.InvalidDistance);
            if (time <= 0)
                throw new CabInvoiceException(ExceptionType.InvalidTime);
            double totalFare = (distance * MINIMUM_COST_PER_KM) + (time * COST_PER_TIME);
            return Math.Max(totalFare, MINIMUM_FAIR);
        }
    }
}
