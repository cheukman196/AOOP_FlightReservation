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
            this.customerCount = 0;
            this.customerList = new Customer[max];
        }

        public int getCustomerCount() { return customerCount; }
        public int getMaxCustomers() { return maxCustomers; }
        public Customer[] getCustomerList() { return customerList; }

        // search for customer by id
        // if found return index, if not return -1
        private int findCustomer(int id)
        {
            if(customerCount > 0)
            {
                for (int i = 0; i < customerCount; i++)
                    if (customerList[i] != null && customerList[i].getCustomerID() == id)
                        return i;
            }
            return -1;
        }

        // search for customer by combination of first name, last name and phone
        // if found return index, if not return -1
        private int findCustomer(string fName, string lname, string phone)
        {
            if (customerCount > 0)
            {
                for (int i = 0; i < customerCount; i++)
                    if (customerList[i].getFirstName() == fName && customerList[i].getLastName() == lname && customerList[i].getPhone() == phone)
                        return i;
            }
            return -1;
        }

        public Customer retrieveCustomerById(int id)
        {
            int index = findCustomer(id);
            if (index != -1)
                return customerList[index];

            return null;
        }

        public bool createCustomer(string fName, string lName, string phone)
        {
            if(customerCount < maxCustomers && findCustomer(fName, lName, phone) == -1)
            {
                customerList[customerCount] = new Customer(fName, lName, phone);
                customerCount++;
                return true;
            }
            return false;
        }

        public bool deleteCustomer(int id, out string error)
        {
            int index = findCustomer(id);
            error = "";
            if(index == -1)
            {
                error += "\nError: Customer not found.";
                return false;
            }

            if (customerList[index].getBookingsCount() > 0)
            {
                error += "\nError: Cannot delete customer with bookings.";
                return false;
            }


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


}
}
