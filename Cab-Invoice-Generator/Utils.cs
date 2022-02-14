using System;
using System.Collections.Generic;

namespace CabInvoiceGenerator.Utils
{
    /// <summary>Enum/Collection of Ride type for this project</summary>
    public enum RideType
    {
        Premium,
        Normal,
    }
    /// <summary>Enum/Collection of exception type for this project</summary>
    public enum ExceptionType
    {
        InvalidDistance,
        InvalidRideType,
        InvalidTime,
        InvalidUserID,
        NullRides,
    }

    /// <summary>Custom exception for this project</summary>
    public class CabInvoiceException : Exception
    {
        private readonly Dictionary<ExceptionType, string> _response = new Dictionary<ExceptionType, string>(){
            {ExceptionType.InvalidRideType, "Invalid ride type"},
            {ExceptionType.InvalidDistance, "Invalid Distance"},
            {ExceptionType.InvalidTime, "Invalid Time"},
            {ExceptionType.InvalidUserID, "Invalid User Id"},
            {ExceptionType.NullRides, "Null Rides"},
        };
        public override string Message => _response[exception];
        public readonly ExceptionType exception;
        
        public CabInvoiceException(string msg) : base(message: msg) { }
        
        public CabInvoiceException(ExceptionType type, string msg) : base(msg)
        {
            this.exception = type;
        }
        public CabInvoiceException(ExceptionType type)
        {
            this.exception = type;
        }
    }
}