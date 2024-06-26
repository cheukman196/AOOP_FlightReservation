﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOOP_GroupProject_draft1
{
    class Flight
    {
        private static bool loadFlightDisabled = false;

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

        private Flight(int flightNumber, string origin, string destination, int maxSeats, int passengerCount, Customer[] passengerList)
        {
            this.flightNumber = flightNumber;
            this.origin = origin;
            this.destination = destination;
            this.maxSeats = maxSeats;
            this.passengerCount = passengerCount;
            this.passengerList = passengerList;
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
        public static void disableLoadFlight() { loadFlightDisabled = true; }
        // Overloaded method
        // Find passenger: try to find passenger by int CustomerID/Customer object in passengerList
        // If found, return index found; If not found, return -1
        // made public since addPassengers need to check if passenger already exists
        public int findPassenger(Customer passenger)
        {
            for(int i = 0; i < passengerCount; i++)
            {
                if (passengerList[i].Equals(passenger))
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
            if(passengerCount < maxSeats && findPassenger(passenger) == -1)
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

        public bool removePassenger(Customer passenger)
        {
            int index = findPassenger(passenger);
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
            string s = "========= Flight Information ==========";
            s += "\nFlight Number:\t\t" + flightNumber;
            s += "\nFlight Origin:\t\t" + origin;
            s += "\nFlight Destination:\t" + destination;
            s += "\nFlight Capacity:\t" + passengerCount + "/" + maxSeats + " passengers";
            s += "\n\n==== Passenger List =====";
            if (passengerCount > 0)
            {
                for (int i = 0; i < passengerCount; i++)
                {
                    s += "\n" + passengerList[i].getCustomerID() + "\t";
                    string name = passengerList[i].getFirstName() + " " + passengerList[i].getLastName();
                    s += Menu.limitStringLength(name, 40);
                }
            }
            else
                s += "\nFlight is currently not booked by any customers.\n";

            return s;
        }

        public static Flight loadFlight(int flightNumber, string origin, string destination, int maxSeats, int passengerCount, Customer[] passengerList)
        {
            if (loadFlightDisabled)
                return null;
            return new Flight(flightNumber, origin, destination, maxSeats, passengerCount, passengerList);
        }
    }
}
