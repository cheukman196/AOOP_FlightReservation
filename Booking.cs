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
        private static bool loadBookingDisabled = false;

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

        private Booking(int bookingNumber, string bookingDate, Flight flight, Customer customer)
        {
            this.customer = customer;
            this.flight = flight;
            this.bookingNumber = bookingNumber;
            this.bookingDate = bookingDate;
        }

        // getters
        public int getBookingNumber() { return bookingNumber; }
        public string getBookingDate() { return bookingDate; }
        public Customer getCustomer() { return customer; }
        public Flight getFlight() { return flight; }
        public static int getUniqueBookingNumber() { return uniqueBookingNumber; }
        public static void disableLoadBooking() { loadBookingDisabled = true; }

        public static Booking loadBooking(int bookingNumber, string bookingDate, Flight flight, Customer customer)
        {
            if (loadBookingDisabled)
                return null;
            return new Booking(bookingNumber, bookingDate, flight, customer);
        }

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
