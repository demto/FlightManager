using System;
using FlightBooking.Core;
using FlightBooking.Core.Domain;
using FlightBooking.Core.Enums;

namespace FlightBookingProblem
{
    public class Program{
        private static ScheduledFlight _scheduledFlight ;

        static void Main(string[] args){
            SetupAirlineData();

            string command = "";

            do {
                command = Console.ReadLine() ?? "";
                var enteredText = command.ToLower();

                if (enteredText.Contains("print summary")){
                    Console.WriteLine();
                    Console.WriteLine(_scheduledFlight.GetSummaryReport());
                } else if (enteredText.Contains("add general")){
                    AddPassengerToScheduledFlight (enteredText, PassengerTypeEnum.General, false );
                } else if (enteredText.Contains("add loyalty")){
                    AddPassengerToScheduledFlight (enteredText, PassengerTypeEnum.LoyaltyMember, true );
                } else if (enteredText.Contains("add airline")){
                    AddPassengerToScheduledFlight (enteredText, PassengerTypeEnum.AirlineEmployee, false );
                } else if (enteredText.Contains("add discounted")){
                    AddPassengerToScheduledFlight (enteredText, PassengerTypeEnum.Discounted, false );
                } else if (enteredText.Contains("exit")){
                    Environment.Exit(1);
                } else {
                    WriteUnknownInputMessage();
                }
            } while (command != "exit");
        }

        private static void WriteUnknownInputMessage(){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("UNKNOWN INPUT");
            Console.ResetColor();
        }

        private static void AddPassengerToScheduledFlight(
            string enteredText,
            PassengerTypeEnum passengerType,
            bool isLoyaltyMember){
            string[] passengerSegments = enteredText.Split(' ');

            if (!isLoyaltyMember) {
                _scheduledFlight.AddPassenger(new Passenger {
                    Type = passengerType,
                    Name = passengerSegments[2],
                    Age = Convert.ToInt32(passengerSegments[3]),
                });
            } else {
                _scheduledFlight.AddPassenger(new Passenger {
                    Type = passengerType,
                    Name = passengerSegments[2],
                    Age = Convert.ToInt32(passengerSegments[3]),
                    LoyaltyPoints = Convert.ToInt32(passengerSegments[4]),
                    IsUsingLoyaltyPoints = Convert.ToBoolean(passengerSegments[5]),
                });
            }
        }

        private static void SetupAirlineData(){
            FlightRoute londonToParis = new FlightRoute("London", "Paris"){
                BaseCost = 50, 
                BasePrice = 100, 
                LoyaltyPointsGained = 5,
                MinimumTakeOffPercentage = 0.7
            };

            _scheduledFlight = new ScheduledFlight(londonToParis);

            _scheduledFlight.SetAircraftForRoute(
                new Plane { Id = 123, Name = "Antonov AN-2", NumberOfSeats = 12 });
        }
    }
}
