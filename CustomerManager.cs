using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOOP_GroupProject_draft1
{
    class CustomerManager
    {
        private int customerCount;
        private int maxCustomers;
        private Customer[] customerList;

        public CustomerManager(int max)
        {
            this.maxCustomers = max;
            this.customerCount = 0; // we initialize the customerCount value here
            this.customerList = new Customer[max];
        }

        // for loading customer manager
        // for loadCustomerManager()
        private CustomerManager(int customerCount, int maxCustomers, Customer[] customerList)
        {
            this.customerCount = customerCount;
            this.maxCustomers = maxCustomers;
            this.customerList = customerList;
        }

        public int getCustomerCount() { return customerCount; }
        public int getMaxCustomers() { return maxCustomers; }
        public Customer[] getCustomerList() { return customerList; }

        public bool createCustomer(string fName, string lName, string phone, out string error)
        {
            error = "";
            // check customerCount does not exceed maxCustomers 
            if (customerCount >= maxCustomers)
            {
                error += "\nError: System's customer limit reached.";
                return false;
            }

            // check if any existing customers have the same firstName, lastName, phone combination
            if (findCustomer(fName, lName, phone) != -1)
            {
                error += "\nError: Customer with same information already exists.";
                return false;
            }

            customerList[customerCount] = new Customer(fName, lName, phone);
            customerCount++;
            return true;
        }

        public bool deleteCustomer(int id, out string error)
        {
            int index = findCustomer(id);
            error = "";
            // check Customer exists in customerList
            if(index == -1)
            {
                error += "\nError: Customer not found.";
                return false;
            }

            // check bookingCount (must be 0)
            if (customerList[index].getBookingsCount() > 0) 
            {
                error += "\nError: Cannot delete customer with bookings.";
                return false;
            }
            // on passing all checks, delete Customer
            customerList[index] = customerList[customerCount - 1];
            customerList[customerCount - 1] = null;
            customerCount--;
            return true;
        }

        public String viewCustomers()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("==================== Customer List ====================\n");
            if (customerCount == 0)
            {
                sb.Append("No customers in the system yet.\n");
                return sb.ToString();
            }

            // if there are Customer objects, append headers and table content
            sb.Append(string.Format("{0, -5} {1, -32} {2,-16}\n", "*ID*", "*Name*", "*Phone*"));
            for (int i = 0; i < customerCount; i++)
            {
                if (customerList[i] != null)
                {
                    int id = customerList[i].getCustomerID();
                    string firstName = customerList[i].getFirstName();
                    string lastName = customerList[i].getLastName();
                    string phone = customerList[i].getPhone();
                    sb.Append(string.Format("{0, -5} {1, -32} {2,-16}\n", id, firstName + " " + lastName, phone));
                }
            }
            return sb.ToString();
        }

        // It is used to retrieve Customer instance
        // For createBooking() in bookingManager
        // It may return NULL when such customer does not exist
        public Customer retrieveCustomerById(int id)
        {
            int index = findCustomer(id);
            if (index != -1)
                return customerList[index];
            return null;
        }

        // search for customer by id
        // if found return index, if not return -1
        private int findCustomer(int id){ 
        
            for (int i = 0; i < customerCount; i++)
                if (customerList[i] != null && customerList[i].getCustomerID() == id)
                    return i;
            return -1;
        }

        // search for customer by combination of first name, last name and phone
        // if found return index, if not return -1
        private int findCustomer(string fName, string lname, string phone)
        {
            for (int i = 0; i < customerCount; i++)
                if (customerList[i].getFirstName() == fName && customerList[i].getLastName() == lname && customerList[i].getPhone() == phone)
                    return i;
            return -1;
        }

        // calls private Constructor that sets ALL attributes of the manager
        public static CustomerManager loadCustomerManager(int customerCount, int maxCustomers, Customer[] customerList)
        {
            return new CustomerManager(customerCount, maxCustomers, customerList);
        }
    }
}
