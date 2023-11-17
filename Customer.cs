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

        private int customerID;
        private string firstName;
        private string lastName;
        private string phone;
        private int bookingsCount;

        public Customer(string fname, string lname, string phone)
        {
            this.customerID = uniqueCustomerID++;
            this.firstName = fname;
            this.lastName = lname;
            this.phone = phone;
            this.bookingsCount = 0;
        }

        // getters
        public int getCustomerID() { return customerID; }
        public string getFirstName() { return firstName; }
        public string getLastName() { return lastName; }
        public string getPhone() { return phone; }
        public int getBookingsCount() { return bookingsCount; }

        // setters
        public void setFirstName(string value) { firstName = value; }
        public void setLastName(string value) { lastName = value; }
        public void setPhone(string value) { phone = value; }
        public void increaseBookingsCount() { bookingsCount++; }
        public void decreaseBookingsCount() { bookingsCount--; }

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
