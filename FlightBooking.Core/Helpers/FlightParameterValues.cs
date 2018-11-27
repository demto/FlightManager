using FlightBooking.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightBooking.Core.Helpers {
    public class StandardFlightParameterValues : IBusinessRulesParameters {
        public double ProfitFromFlight { get; set; }
        public int TotalExpectedBaggage { get; set; }
        public int TotalLoyaltyPointsRedeemed { get; set; }
        public int TotalLoyaltyPointsAccrued { get; set; }
        public double CostOfFlight { get; set; }
        public int SeatsTaken { get; set; }
        public int NumberOfSeats { get; set; }
        public int PassengerCount { get; set; }
        public int GeneralSales { get; set; }
        public int LoyaltySales { get; set; }
        public int AirlineEmployeeSales { get; set; }
        public int DiscountedSales { get; set; }
        public double ProfitSurplus { get; set; }
        public double MinimumTakeOffPercentage { get; set; }
    }
}
