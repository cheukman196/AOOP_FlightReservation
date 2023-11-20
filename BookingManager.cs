using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOOP_GroupProject_draft1
{
    class BookingManager
    {
        private int bookingCount;
        private int maxBookings;
        private Booking[] bookingList;

        public BookingManager(int max)
        {
            this.maxBookings = max;
            this.bookingCount = 0;
            this.bookingList = new Booking[max];
        }

        // for loading the booking manager
        // called by loadBookingManager()
        private BookingManager(int bookingCount, int maxBookings, Booking[] bookingList)
        {
            this.bookingCount = bookingCount;
            this.maxBookings = maxBookings;
            this.bookingList = bookingList;
        }

        public int getBookingCount() { return bookingCount; }
        public int getMaxBookings() { return maxBookings; }
        public Booking[] getBookingList() { return bookingList; }

        // create booking
        // condition: customer manager's customer list not already full
        public bool createBooking(Flight flight, Customer customer)
        {
            // leaving Flight and Customer exists check and max seat check for Coordinator
            // leaving flightCount++ and customerCount++ for Coordinator class
            if(bookingCount < maxBookings)
            {
                bookingList[bookingCount] = new Booking(flight, customer);
                bookingCount++;
                return true;
            }
            return false;
        }

        // Delete booking
        public bool deleteBooking(int id, out string error)
        {
            error = "";
            int index = findBooking(id);
            if (index == -1)
            {
                error += "\nError: Booking not found.";
                return false;
            }

            Customer customer = bookingList[index].getCustomer();
            Flight flight = bookingList[index].getFlight();
            
            if(customer == null || flight == null)
            {
                error += "\nError: Incomplete information of Booking in system.";
                return false;
            }

            
            bookingList[index] = bookingList[bookingCount - 1];
            bookingList[bookingCount - 1] = null;
            bookingCount--;
            customer.decreaseBookingsCount();
            flight.removePassenger(customer);
            return true;            
        }

        // updated view Bookings to format strings
        public String viewBookings()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("============================== Booking List ==============================\n");
            if (bookingCount == 0)
            {
                sb.Append("No Bookings in the system yet.\n");
                return sb.ToString();
            }

            string customerName = "";
            string flightNum = "";
            int bookingNumber = 0;
            string bookingDate = "";
            
            // if there are Customer objects, append headers and table content
            sb.Append(string.Format("{0, -6} {1, -10} {2,-32} {3,-20}\n","*ID*","*Flight#*", "*Customer Name*", "*Booking Date*"));
            for (int i = 0; i < bookingCount; i++)
            {
                if (bookingList[i] != null)
                {
                    bookingNumber = bookingList[i].getBookingNumber();
                    Flight flight = bookingList[i].getFlight();
                    Customer customer = bookingList[i].getCustomer();
                    if (flight != null && customer != null)
                    {
                        flightNum = flight.getFlightNumber().ToString();
                        customerName = customer.getFirstName() + " " + customer.getLastName();

                    }
                    bookingDate = bookingList[i].getBookingDate();
                    sb.Append(string.Format("{0, -6} {1, -10} {2,-32} {3,-20}\n", bookingNumber, Menu.limitStringLength(flightNum, 6), Menu.limitStringLength(customerName,32), bookingDate));
                }

            }
            return sb.ToString();
        }

        // find booking by bookingNumber
        // if found, return index, if not return -1
        private int findBooking(int bookingNumber)
        {
            if (bookingCount > 0)
            {
                for (int i = 0; i < bookingCount; i++)
                    if (bookingList[i].getBookingNumber() == bookingNumber)
                        return i;
            }
            return -1;
        }

        // !
        public static BookingManager loadBookingManager(int bookingCount, int maxBookings, Booking[] bookingList)
        {
            return new BookingManager(bookingCount, maxBookings, bookingList);
        }
    }
}
