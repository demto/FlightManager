using FlightBooking.Core.Enums;

namespace FlightBooking.Core.Domain
{
    public class Passenger
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int AllowedBags { get; set; }
        public int LoyaltyPoints { get; set; }
        public bool IsUsingLoyaltyPoints { get; set; }
        public PassengerTypeEnum Type { get; set; }
    }
}
