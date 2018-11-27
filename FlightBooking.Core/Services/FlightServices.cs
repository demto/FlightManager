using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightBooking.Core.Services
{
    public class FlightServices
    {
        #region Private Members

        private ScheduledFlight scheduledFlight;

        #endregion

        public FlightServices(ScheduledFlight scheduledFlight)
        {
            this.scheduledFlight = scheduledFlight;
        }
    }
}
