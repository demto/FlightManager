using FlightBooking.Core.Domain;
using FlightBooking.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.SharedProject.DSOs
{
    public class ScheduledFlightSummaryReportDso
    {
        public FlightDetails FlightDetails { get; set; }
        public StandardFlightParameterValues CalculatedValues { get; set; }
    }
}
