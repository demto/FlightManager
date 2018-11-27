using System;
using System.Linq;
using System.Collections.Generic;
using FlightBooking.Core.Domain;
using FlightBooking.Core.Reports;
using FlightBooking.SharedProject.DSOs;
using FlightBooking.Core.Interfaces;
using FlightBooking.Core.BusinessRules;
using FlightBooking.Core.Helpers;

namespace FlightBooking.Core
{
    public class ScheduledFlight {

        public ScheduledFlight(FlightRoute flightRoute) {
            FlightRoute = flightRoute;
            Passengers = new List<Passenger>();
        }

        public FlightRoute FlightRoute { get; private set; }
        public Plane Aircraft { get; private set; }
        public List<Passenger> Passengers { get; private set; }
        public FlightDetails ScheduledFlightDetails {
            get {
                return new FlightDetails() {
                    FlightRoute = this.FlightRoute,
                    Passengers = this.Passengers,
                    Aircraft = this.Aircraft,
                };
            }
        }

        public void AddPassenger(Passenger passenger) {
            Passengers.Add(passenger);
        }

        public void SetAircraftForRoute(Plane aircraft) {
            Aircraft = aircraft;
        }

        // If no business rules are specified by the user we default to the standard rules

        public string GetSummaryReport() {
            var values = FlightParameterCalculator.GetFlightParameterValues(ScheduledFlightDetails);
            var businessRules = new StandardRules(values);
            return GetSummaryReport(businessRules);
        }

        public string GetSummaryReport(IBusinessRules businessRules) {
            var reportService = new ScheduledFlightReportGenerator(businessRules);

            var dsoForReport = new ScheduledFlightSummaryReportDso() {
                FlightDetails = ScheduledFlightDetails,
                CalculatedValues = FlightParameterCalculator.GetFlightParameterValues(ScheduledFlightDetails),
            };

            return reportService.GetScheduledFlightSummaryReport(dsoForReport);
        }
    }
}
