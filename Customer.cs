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

        private int customerID;
        private string firstName;
        private string lastName;
        private string phone;
        private int bookingsCount;

        public Customer(string fName, string lName, string phone)
        {
            this.customerID = uniqueCustomerID++;
            this.firstName = fName;
            this.lastName = lName;
            this.phone = phone;
            this.bookingsCount = 0;
        }

        private Customer(int customerID, string fName, string lName, string phone, int bookingsCount)
        {
            this.customerID = customerID;
            this.firstName = fName;
            this.lastName = lName;
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

        // setters
        public void setFirstName(string value) { firstName = value; }
        public void setLastName(string value) { lastName = value; }
        public void setPhone(string value) { phone = value; }
        public void increaseBookingsCount() { bookingsCount++; }

        public static void disableLoadCustomer() { loadCustomerDisabled = true; }
        public static Customer loadCustomer(int customerID, string fName, string lName, string phone, int bookingCount)
        {
            if (loadCustomerDisabled)
                return null;
            return new Customer(customerID, fName, lName, phone, bookingCount);
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
