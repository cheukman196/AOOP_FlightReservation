using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOOP_GroupProject_draft1
{
    class Customer
    {
        private static int uniqueCustomerID = 100;
        private static bool loadCustomerDisabled = false;
        private static bool loadUniqueCustomerIDDisabled = false;

        private int customerID;
        private string firstName;
        private string lastName;
        private string phone;
        private int bookingsCount;

        public Customer(string fName, string lName, string phone)
        {
            this.customerID = uniqueCustomerID;
            this.firstName = fName;
            this.lastName = lName;
            this.phone = phone;
            this.bookingsCount = 0;
            uniqueCustomerID++;
        }

        // for loading a file
        // called using the loadCustomer() method
        private Customer(int id, string firstName, string lastName, string phone, int bookingsCount)
        {
            this.customerID = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.bookingsCount = bookingsCount;
        }

        // getters
        public int getCustomerID() { return customerID; }
        public string getFirstName() { return firstName; }
        public string getLastName() { return lastName; }
        public string getPhone() { return phone; }
        public int getBookingsCount() { return bookingsCount; }
        public static int getUniqueCustomerID() { return uniqueCustomerID; }

        // For createBooking
        public void addBookingsCount() { bookingsCount++; }

        // For loading a file and creating a customer
        public static void disableLoadCustomer() { loadCustomerDisabled = true; }

        // For loading a file and creating a customer
        // added a boolean check: 'loadCustomerDisabled' will be set to true AFTER loading all the data
        // that way, no other people can use the loadCustomer() method anymore
        public static Customer loadCustomer(int customerID, string fName, string lName, string phone, int bookingCount)
        {
            if (loadCustomerDisabled)
                return null;
            return new Customer(customerID, fName, lName, phone, bookingCount);
        }

        // For loading a file and initiate the uniqueCusomerID
        public static bool loadUniqueCustomerID(int id)
        {
            if (loadUniqueCustomerIDDisabled)
                return false;

            uniqueCustomerID = id;
            loadUniqueCustomerIDDisabled = true;
            return true;
        }

        public override string ToString()
        {
            string s = "\nCustomer ID: " + customerID;
            s += "\nName: " + firstName + " " + lastName;
            s += "\nPhone: " + phone;
            s += "\nNumber of bookings: " + bookingsCount;
            return s;
        }

    }
}
