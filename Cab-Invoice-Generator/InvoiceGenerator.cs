using System;
using System.Linq;
using CabInvoiceGenerator.Utils;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        private RideType _rideType;
        private readonly int _minimumFair;
        private readonly int _costPerTime;
        private readonly int _minimumCostPerKm;

        /// <summary>Generate Cab Service Invoices</summary>
        public InvoiceGenerator(RideType type)
        {
            _rideType = type;

            if (type == RideType.Normal)
            {
                this._minimumCostPerKm = 10;
                this._costPerTime = 1;
                this._minimumFair = 5;
            }
            else if (type == RideType.Premium)
            {
                this._minimumCostPerKm = 15;
                this._costPerTime = 2;
                this._minimumFair = 20;
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
            double totalFare = (distance * _minimumCostPerKm) + (time * _costPerTime);
            return Math.Max(totalFare, _minimumFair);
        }

        /// <summary>fare calculation from given Array of Ride object</summary>
        /// <param name="rides">Array of Ride object</param>
        /// <returns>Returns Total fare in Double</returns>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            if(rides == null || rides.Length == 0)
                throw new CabInvoiceException(ExceptionType.NullRides);
            totalFare += rides.Sum(item => CalculateFare(item.Distance, item.Time));
            var result = Math.Max(totalFare, _minimumFair);
            return new InvoiceSummary(rides.Length, result);
        }
    }
}
