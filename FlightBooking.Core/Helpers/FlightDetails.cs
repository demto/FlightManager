using FlightBooking.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightBooking.Core.Helpers {
    public class FlightDetails {
        public FlightRoute FlightRoute { get; set; }
        public IList<Passenger> Passengers { get; set; }
        public Plane Aircraft { get; set; }
    }
}
