using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOOP_GroupProject_draft1
{
    class Booking
    {
        private static int uniqueBookingNumber = 100; // using number 100 so that we start with 3 digits
        private static bool loadBookingDisabled = false; // condition check for loadBooking() method
        private static bool loadUniqueBookingNumberDisabled = false; // condition check for loadUniqueBookingNumber() method

        private int bookingNumber;
        private string bookingDate;
        private Flight flight;
        private Customer customer;

        public Booking(Flight flight, Customer customer)
        {
            bookingNumber = uniqueBookingNumber++;
            bookingDate = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
            this.flight = flight;
            this.customer = customer;
        }

        // For loading a file
        // used in loadBooking()
        private Booking(int bookingNumber, string bookingDate, Flight flight, Customer customer)
        {
            this.bookingNumber = bookingNumber;
            this.bookingDate = bookingDate;
            this.flight = flight;
            this.customer = customer;
        }

        // getters
        public int getBookingNumber() { return bookingNumber; }
        public Customer getCustomer() { return customer; }
        public Flight getFlight() { return flight; }
        public string getBookingDate() { return bookingDate; }

        // for loading files
        public static int getUniqueBookingNumber() { return uniqueBookingNumber; }
        public static void disableLoadBooking() { loadBookingDisabled = true; }

        // for loading a Booking
        // the Utility class will disable 'loadBookingDisabled' after loading all classes
        public static Booking loadBooking(int bookingNumber, string bookingDate, Flight flight, Customer customer)
        {
            if (loadBookingDisabled)
                return null;
            return new Booking(bookingNumber, bookingDate, flight, customer);
        }

        // for loading the Booking class's unique booking number
        // restrict calling this method twice by changing condition boolean value on first call
        public static bool loadUniqueBookingNumber(int bookingNumber)
        {
            if (loadUniqueBookingNumberDisabled)
                return false;

            uniqueBookingNumber = bookingNumber;
            loadUniqueBookingNumberDisabled = true; // once true, this method cannot run successfully again
            return true;
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
