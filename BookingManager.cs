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

        public int getBookingCount() { return bookingCount; }
        public int getMaxBookings() { return maxBookings; }
        public Booking[] getBookingList() { return bookingList; }

        // find booking by bookingNumber
        // if found, return index, if not return -1
        private int findBooking(int bookingNumber)
        {
            if(bookingCount > 0)
            {
                for (int i = 0; i < bookingCount; i++)
                    if (bookingList[i].getBookingNumber() == bookingNumber)
                        return i;               
            }
            return -1;
        }

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
            int flightNum = 0;
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
                        flightNum = flight.getFlightNumber();
                        customerName = customer.getFirstName() + " " + customer.getLastName();

                    }
                    bookingDate = bookingList[i].getBookingDate();
                    sb.Append(string.Format("{0, -6} {1, -10} {2,-32} {3,-20}\n", bookingNumber, flightNum, customerName, bookingDate));
                }


            }
            return sb.ToString();
        }
    }
}
