using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOOP_GroupProject_draft1
{
    class AirlineCoordinator
    {
        private CustomerManager cm;
        private FlightManager fm;
        private BookingManager bm;

        public AirlineCoordinator (CustomerManager cm, FlightManager fm, BookingManager bm)
        {
            this.cm = cm;
            this.fm = fm;
            this.bm = bm;
        }

        public FlightManager getFlightManager() { return fm; }
        public CustomerManager getCustomerManager() { return cm; }
        public BookingManager getBookingManager() { return bm; }

        public bool createFlight(int flightNumber, string origin, string destination, int maxSeats, out string error)
        {
            return fm.createFlight(flightNumber, origin, destination, maxSeats, out error); 
        }

        public bool deleteFlight(int flightNumber, out string error)
        {
            return fm.deleteFlight(flightNumber, out error);
        }

        public string viewFlights()
        {
            return fm.viewFlights();
        }

        public string viewParticularFlight(int id)
        {
            return fm.viewParticularFlight(id);
        }

        public bool createCustomer(string fName, string lName, string phone, out string error)
        {
            return cm.createCustomer(fName, lName, phone, out error);
        }

        public bool deleteCustomer(int id, out string error)
        {
            return cm.deleteCustomer(id, out error);
        }

        public string viewCustomers()
        {
            return cm.viewCustomers();
        }


        // !!!! Consider custom error classes to check, so you can have custom errors
        // leaving menu display for menu class
        public bool makeBooking(int flightNumber, int customerID, out string error)
        {
            error = "";
            Flight flight = fm.retrieveFlightById(flightNumber);
            Customer customer = cm.retrieveCustomerById(customerID);

            if (flight == null)
            {
                error += "\nError: Flight not found."; // when flight is not found
                return false;
            }

            if(customer == null)
            {
                error += "\nError: Customer not found."; // when customer is not found
                return false;
            }

            if(flight.getPassengerCount() >= flight.getMaxSeats())
            {
                error += "\nError: Flight is full."; // when flight is full (passengerCount >= seats)
                return false;
            }

            if (flight.findPassenger(customer) != -1)
            {
                error += "\nError: Customer has already booked flight."; // when flight is full (passengerCount >= seats)
                return false;
            }

            if (!bm.createBooking(flight, customer))
            {
                error += "\nError: Maximum number of bookings reached."; // when bookingCount > maxBooking (BookingManager)
                return false;
            }

            flight.addPassenger(customer);
            customer.increaseBookingsCount();
            return true;
        }

        public string viewBookings()
        {
            return bm.viewBookings();
        }

        public bool deleteBooking(int id, out string error)
        {
            return bm.deleteBooking(id, out error);
        }
    }
}
