using FlightBooking.Core.Enums;
using FlightBooking.Core.Interfaces;
using FlightBooking.SharedProject.DSOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Core.Reports
{
    public class ScheduledFlightReportGenerator
    {

        #region Private Members

        private readonly string VERTICAL_WHITE_SPACE = Environment.NewLine + Environment.NewLine;
        private readonly string NEW_LINE = Environment.NewLine;
        private const string INDENTATION = "    ";

        private string report;

        private IBusinessRules businessRules;

        #endregion

        #region Constructor

        public ScheduledFlightReportGenerator(IBusinessRules businessRules)
        {
            this.businessRules = businessRules;

            report = string.Empty;
        }

        #endregion

        #region Report

        public string GetScheduledFlightSummaryReport(ScheduledFlightSummaryReportDso dso)
        {
            GenerateReport(dso);
            return report;
        }


        private void GenerateReport(ScheduledFlightSummaryReportDso dso)
        {
            report = "Flight summary for " + dso.FlightDetails.FlightRoute.Title;

            report += VERTICAL_WHITE_SPACE;

            report += "Total passengers: " + dso.CalculatedValues.SeatsTaken;
            report += NEW_LINE;
            report += INDENTATION + "General sales: " + dso.CalculatedValues.GeneralSales;
            report += NEW_LINE;
            report += INDENTATION + "Loyalty member sales: " + dso.CalculatedValues.LoyaltySales;
            report += NEW_LINE;
            report += INDENTATION + "Airline employee comps: " + dso.CalculatedValues.AirlineEmployeeSales;
            report += NEW_LINE;
            report += INDENTATION + "Discounted sales: " + dso.CalculatedValues.DiscountedSales;
            report += VERTICAL_WHITE_SPACE;
            report += "Total expected baggage: " + dso.CalculatedValues.TotalExpectedBaggage;

            report += VERTICAL_WHITE_SPACE;

            report += "Total revenue from flight: " + dso.CalculatedValues.ProfitFromFlight;
            report += NEW_LINE;
            report += "Total costs from flight: " + dso.CalculatedValues.CostOfFlight;
            report += NEW_LINE;

            report += (dso.CalculatedValues.ProfitSurplus > 0 ? "Flight generating profit of: " : "Flight losing money of: ") + dso.CalculatedValues.ProfitSurplus;

            report += VERTICAL_WHITE_SPACE;

            report += "Total loyalty points given away: " + dso.CalculatedValues.TotalLoyaltyPointsAccrued + NEW_LINE;
            report += "Total loyalty points redeemed: " + dso.CalculatedValues.TotalLoyaltyPointsRedeemed + NEW_LINE;

            report += VERTICAL_WHITE_SPACE;

            if (businessRules.CanFlightProceed)
                report += "THIS FLIGHT MAY PROCEED";
            else
                report += "FLIGHT MAY NOT PROCEED";
        }

        #endregion
    }
}
