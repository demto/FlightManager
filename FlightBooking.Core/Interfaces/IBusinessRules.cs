using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightBooking.Core.Interfaces
{
    public interface IBusinessRules {
        bool CanFlightProceed { get; }
    }
}
