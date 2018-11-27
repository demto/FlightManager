using FlightBooking.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightBooking.Core.Helpers {
    public static class FlightParameterCalculator {

        public static StandardFlightParameterValues GetFlightParameterValues(FlightDetails details) {

            StandardFlightParameterValues returnValues = new StandardFlightParameterValues();

            foreach (var passenger in details.Passengers) {
                switch (passenger.Type) {
                    case (PassengerTypeEnum.General): {
                            returnValues.ProfitFromFlight += details.FlightRoute.BasePrice;
                            returnValues.TotalExpectedBaggage++;
                            break;
                        }
                    case (PassengerTypeEnum.LoyaltyMember): {
                            if (passenger.IsUsingLoyaltyPoints) {
                                int loyaltyPointsRedeemed = Convert.ToInt32(Math.Ceiling(details.FlightRoute.BasePrice));
                                passenger.LoyaltyPoints -= loyaltyPointsRedeemed;
                                returnValues.TotalLoyaltyPointsRedeemed += loyaltyPointsRedeemed;
                            } else {
                                returnValues.TotalLoyaltyPointsAccrued += details.FlightRoute.LoyaltyPointsGained;
                                returnValues.ProfitFromFlight += details.FlightRoute.BasePrice;
                            }
                            returnValues.TotalExpectedBaggage += 2;
                            break;
                        }
                    case (PassengerTypeEnum.AirlineEmployee): {
                            returnValues.TotalExpectedBaggage += 1;
                            break;
                        }
                    case (PassengerTypeEnum.Discounted): {
                            returnValues.ProfitFromFlight += details.FlightRoute.BasePrice / 2;
                            break;
                        }
                }
                returnValues.CostOfFlight += details.FlightRoute.BaseCost;
                returnValues.SeatsTaken++;
            }

            returnValues.GeneralSales = GetGeneralSalesDetails(details);
            returnValues.LoyaltySales = GetLoyaltySalesDetails(details);
            returnValues.AirlineEmployeeSales = GetAirlineEmployeeSalesDetails(details);
            returnValues.DiscountedSales = GetDiscountedSalesDetails(details);

            returnValues.ProfitSurplus = returnValues.ProfitFromFlight - returnValues.CostOfFlight;

            returnValues.NumberOfSeats = details.Aircraft.NumberOfSeats;

            returnValues.MinimumTakeOffPercentage = details.FlightRoute.MinimumTakeOffPercentage;
            return returnValues;
        }

        public static int GetGeneralSalesDetails(FlightDetails flightDetails) {
            return flightDetails.Passengers.Count(p => p.Type == PassengerTypeEnum.General);
        }

        public static int GetLoyaltySalesDetails(FlightDetails flightDetails) {
            return flightDetails.Passengers.Count(p => p.Type == PassengerTypeEnum.LoyaltyMember);
        }

        public static int GetAirlineEmployeeSalesDetails(FlightDetails flightDetails) {
            return flightDetails.Passengers.Count(p => p.Type == PassengerTypeEnum.AirlineEmployee);
        }

        public static int GetDiscountedSalesDetails(FlightDetails flightDetails) {
            return flightDetails.Passengers.Count(p => p.Type == PassengerTypeEnum.Discounted);
        }
    }
}
