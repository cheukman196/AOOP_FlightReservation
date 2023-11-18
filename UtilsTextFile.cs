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

        //public static Customer[] loadCustomerFile(string filePath)
        //{
        //    if (!File.Exists(filePath))
        //        return null;

        //    using (StreamReader sr = new StreamReader(filePath))
        //    {
        //        int customerCount = int.Parse(sr.ReadLine());
        //        Customer[] customerList = new Customer[customerCount + 100];
        //        for (int i = 0; i < customerCount; i++)
        //        {
        //            string[] customerInfo = sr.ReadLine().Split();
        //            int customerID = int.Parse(customerInfo[0]);
        //            string firstName = customerInfo[1];
        //            string lastName = customerInfo[2];
        //            string phone = customerInfo[3];
        //            int bookingsCount = int.Parse(customerInfo[4]);

        //            customerList[i] = new Customer(firstName, lastName, phone);
        //            customerList[i].setCustomerID(customerID);
        //            customerList[i].setBookingsCount(bookingsCount);
        //        }
        //    }

        //}

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
                    int passengerCount = flightList[i].getPassengerCount();
                    Customer[] passengerList = flightList[i].getPassengerList();
                    string passengerIdList = "";
                    
                    if(passengerCount > 0)
                        for (int k = 0; k < flightList[i].getPassengerCount(); k++)
                            passengerIdList += flightList[i].getPassengerList()[k].getCustomerID() + ",";

                    sw.WriteLine(flightNum + " " + origin + " " + destination + " " + passengerCount + " " + passengerIdList);
                }
            }
            
        }

        public static void saveBookingFile(string filePath, int bookingCount, Booking[] bookingList)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(bookingCount);
                for (int i = 0; i < bookingCount; i++)
                {
                    int bookingNumber = bookingList[i].getBookingNumber();
                    string bookingDate = bookingList[i].getBookingDate();
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
