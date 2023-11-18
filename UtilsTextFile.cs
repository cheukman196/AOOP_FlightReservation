using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AOOP_GroupProject_draft1
{
    static class UtilsTextFile
    {
        public static readonly string executionDirectory = Environment.CurrentDirectory;
        public static readonly string projectDirectory = Directory.GetParent(executionDirectory).Parent.Parent.FullName;
        public static readonly string flightManagerFilePath = projectDirectory + "/" + "flight_manager.txt";
        public static readonly string customerManagerFilePath = projectDirectory + "/" + "customer_manager.txt";
        public static readonly string bookingManagerFilePath = projectDirectory + "/" + "booking_manager.txt";
        public static readonly string uniqueClassIDFilePath = projectDirectory + "/" + "unique_class_ID.txt";


        public static void saveCustomerFile(string filePath, int customerCount, Customer[] customerList)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(customerCount);
                for (int i = 0; i < customerCount; i++)
                {
                    int customerID = customerList[i].getCustomerID();
                    string firstName = customerList[i].getFirstName();
                    string lastName = customerList[i].getLastName();
                    string phone = customerList[i].getPhone();
                    int bookingsCount = customerList[i].getBookingsCount();
                    sw.WriteLine(customerID + " " + firstName + " " + lastName + " " + phone + " " + bookingsCount);
                }
            }
        }

        public static CustomerManager loadCustomerFile(string filePath)
        {

            if (!File.Exists(filePath))
                return null;

            CustomerManager cm = null;
            Customer[] customerList = null;

            using (StreamReader sr = new StreamReader(filePath))
            {
                int customerCount = int.Parse(sr.ReadLine());
                int maxCustomer = customerCount + 100;
                customerList = new Customer[maxCustomer];
                for (int i = 0; i < customerCount; i++)
                {
                    string[] customerInfo = sr.ReadLine().Split();
                    int customerID = int.Parse(customerInfo[0]);
                    string firstName = customerInfo[1];
                    string lastName = customerInfo[2];
                    string phone = customerInfo[3];
                    int bookingsCount = int.Parse(customerInfo[4]);

                    customerList[i] = Customer.loadCustomer(customerID, firstName, lastName, phone, bookingsCount);
                }
                cm = CustomerManager.loadCustomerManager(customerCount, maxCustomer, customerList);
            }
            Customer.disableLoadCustomer();
            return cm;
        }

        public static void saveFlightFile(string filePath, int flightCount, Flight[] flightList)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(flightCount);
                for (int i = 0; i < flightCount; i++)
                {
                    int flightNum = flightList[i].getFlightNumber();
                    string origin = flightList[i].getOrigin();
                    string destination = flightList[i].getDestination();
                    int maxSeats = flightList[i].getMaxSeats();
                    int passengerCount = flightList[i].getPassengerCount();
                    Customer[] passengerList = flightList[i].getPassengerList();
                    string passengerIdList = "";
                    
                    if(passengerCount > 0)
                        for (int k = 0; k < flightList[i].getPassengerCount(); k++)
                            passengerIdList += flightList[i].getPassengerList()[k].getCustomerID() + ",";

                    sw.WriteLine(flightNum + " " + origin + " " + destination + " " + maxSeats + " " + passengerCount + " " + passengerIdList);
                }
            }
            
        }

        public static FlightManager loadFlightFile(string filePath, CustomerManager cm)
        {
            if (!File.Exists(filePath))
                return null;

            FlightManager fm = null;
            Flight[] flightList = null;

            using (StreamReader sr = new StreamReader(filePath))
            {
                int flightCount = int.Parse(sr.ReadLine());
                int maxFlights = flightCount + 100;
                flightList = new Flight[maxFlights];
                for (int i = 0; i < flightCount; i++)
                {
                    string[] flightInfo = sr.ReadLine().Split();

                    int flightNumber = int.Parse(flightInfo[0]);
                    string origin = flightInfo[1];
                    string destination = flightInfo[2];
                    int maxSeats = int.Parse(flightInfo[3]);
                    int passengerCount = int.Parse(flightInfo[4]);

                    Customer[] passengerList = new Customer[passengerCount];
                    string passengerIdList = flightInfo[5];
                    if(passengerIdList.Length > 0)
                    {
                        string[] passengerIdArray = flightInfo[5].Substring(0, flightInfo[5].Length - 1).Split(",");
                        for (int k = 0; k < passengerIdArray.Length; k++)
                        {
                            Customer customer = cm.retrieveCustomerById(int.Parse(passengerIdArray[k]));
                            passengerList[k] = customer;
                        }
                    }
                    flightList[i] = Flight.loadFlight(flightNumber, origin, destination, maxSeats, passengerCount, passengerList);
                }
                fm = FlightManager.loadFlightManager(flightCount, maxFlights, flightList);
            }
            Flight.disableLoadFlight();
            return fm;
        }


        public static void saveBookingFile(string filePath, int bookingCount, Booking[] bookingList)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(bookingCount);
                for (int i = 0; i < bookingCount; i++)
                {
                    int bookingNumber = bookingList[i].getBookingNumber();
                    string bookingDate = bookingList[i].getBookingDate().Replace(" ", "-");
                    int flightNumber = bookingList[i].getFlight().getFlightNumber();
                    int customerID = bookingList[i].getCustomer().getCustomerID();
                    sw.WriteLine(bookingNumber + " " + bookingDate + " " + flightNumber + " " + customerID);
                }
            }
        }

        public static void saveClassUniqueID(string filePath, int uniqueCustomerID, int uniqueBookingNumber)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(uniqueCustomerID + " " + uniqueBookingNumber);
            }
        }
    }
}
