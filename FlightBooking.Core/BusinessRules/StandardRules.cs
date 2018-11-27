using FlightBooking.Core.Helpers;
using FlightBooking.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightBooking.Core.BusinessRules
{
    public class StandardRules : IBusinessRules
    {

        public StandardRules(IBusinessRulesParameters values) {

            if(values.GetType() != typeof(StandardFlightParameterValues)){
                throw new InvalidOperationException("Standard Rules can only get standard flight parameters");
            }

            Values = values as StandardFlightParameterValues;
        }

        public StandardFlightParameterValues Values { get; set; }

        public bool CanFlightProceed {
            get {
                return Values.ProfitSurplus > 0 &&
                    Values.SeatsTaken < Values.NumberOfSeats &&
                    Values.SeatsTaken / (double)Values.NumberOfSeats > Values.MinimumTakeOffPercentage;
            }
        }
    }
}
