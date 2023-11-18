using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOOP_Group_Project_coopdraft1
{
    class Flight
    {
        private int flightNumber;
        private string origin;
        private string destination;
        private int maxSeats;
        private int passengerCount;
        private Customer[] passengerList;

        public Flight(int flightNumber, string origin, string destination, int maxSeats)
        {
            this.flightNumber = flightNumber;
            this.origin = origin;
            this.destination = destination;
            this.maxSeats = maxSeats;
            this.passengerCount = 0;
            this.passengerList = new Customer[maxSeats];
        }


        // getters
        public int getFlightNumber() { return flightNumber; }
        public string getOrigin() { return origin; }
        public string getDestination() { return destination; }
        public int getMaxSeats() { return maxSeats; }
        public int getPassengerCount() { return passengerCount; }
        public Customer[] getPassengerList() { return passengerList; }

        // setters (only flightNumber, origin and destination, other values manipulated differently)
        public void setFlightNumber(int value) { flightNumber = value; }
        public void setOrigin(string value) { origin = value; }
        public void setDesination(string value) { destination = value; }

        // Overloaded method
        // Find passenger: try to find passenger by int CustomerID/Customer object in passengerList
        // If found, return index found; If not found, return -1
        private int findPassenger(Customer passenger)
        {
            for (int i = 0; i < passengerCount; i++)
            {
                if (passengerList[i] == passenger)
                    return i;
            }
            return -1;
        }

        private int findPassenger(int id)
        {
            for (int i = 0; i < passengerCount; i++)
            {
                if (passengerList[i].getCustomerID() == id)
                    return i;
            }
            return -1;
        }

        // method to add a passenger to a flight
        // conditions: 1. plane must have free seats 2. passenger has not already booked the flight
        public bool addPassenger(Customer passenger)
        {
            if (passengerCount < maxSeats && findPassenger(passenger) == -1)
            {
                passengerList[passengerCount] = passenger;
                passengerCount++;
                return true;
            }
            return false;
        }

        public bool removePassenger(int id)
        {
            int index = findPassenger(id);
            if (index != -1)
            {
                passengerList[index] = passengerList[passengerCount - 1];
                passengerList[passengerCount - 1] = null;
                passengerCount--;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string s = "\n========= Flight Information ==========";
            s += "\nFlight Number: " + flightNumber;
            s += "\nFlight Origin: " + origin;
            s += "\nFlight Destination: " + destination;
            s += "\nFlight Capacity: " + passengerCount + "/" + maxSeats + " passengers";
            s += "\n==== Passenger List =====";
            if (passengerCount > 0)
            {
                for (int i = 0; i < passengerCount; i++)
                    s += "\n" + passengerList[i].getCustomerID() + "\t" + passengerList[i].getFirstName() + " " + passengerList[i].getLastName();
            }
            else
                s += "\nFlight is currently not booked by any customers.";

            return s;
        }
    }
}
