using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOOP_GroupProject_draft1
{
    class Booking
    {
        private static int uniqueBookingNumber = 100;

        private int bookingNumber;
        private string bookingDate;
        private Customer customer;
        private Flight flight;

        public Booking(Flight flight, Customer customer)
        {
            this.customer = customer;
            this.flight = flight;
            bookingNumber = uniqueBookingNumber++;
            bookingDate = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
        }

        // getters
        public int getBookingNumber() { return bookingNumber; }
        public string getBookingDate() { return bookingDate; }
        public Customer getCustomer() { return customer; }
        public Flight getFlight() { return flight; }

        // no setters (create new booking if customers want to modify booking)

        public override string ToString()
        {
            string s = "\nBooking Number: " + bookingNumber;
            s += "\nBooking Date: " + bookingDate;
            s += "\nCustomer: " + customer.getCustomerID() + " " + customer.getFirstName() + " " + customer.getLastName();
            s += "\nFlight#" + flight.getFlightNumber() + " from " + flight.getOrigin() + " to " + flight.getDestination();
            return s;
        }

    }
}
