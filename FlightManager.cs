using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOOP_GroupProject_draft1
{
    class FlightManager
    {
        private int flightCount;
        private int maxFlights;
        private Flight[] flightList;

        public FlightManager(int maxFlights)
        {
            this.flightCount = 0;
            this.maxFlights = maxFlights;
            this.flightList = new Flight[maxFlights];
        }

        public int getFlightCount() { return flightCount; }
        public int getMaxFlights() { return maxFlights; }
        public Flight[] getFlightList() { return flightList; }

        // searches for Flight object in flightList
        // if found, return index, if not return -1
        private int findFlight(int flightNumber)
        {
            if(flightCount > 0)
                for(int i = 0; i < flightCount; i++)
                    if(flightList[i].getFlightNumber() == flightNumber)
                        return i;
            return -1;
        }
        
        // tries to create a new Flight object 
        // condition: flight count is smaller than max allowed
        // condition: flight number is not a duplicate
        public bool createFlight(int flightNumber, string origin, string destination, int maxSeats)
        {
            if(flightCount < maxFlights && findFlight(flightNumber) == -1)
            {
                flightList[flightCount] = new Flight(flightNumber, origin, destination, maxSeats);
                flightCount++;
                return true;
            }
            return false;
        }

        // delete Flight object by a flightNumber input
        // condition: Flight object must exist in flightList
        // condition: Flight object passenger count must be 0
        public bool deleteFlight(int flightNumber)
        {
            int index = findFlight(flightNumber);

            // note: -1 index may produce problems despite short circuiting, please test
            if (index != -1 && flightList[index].getPassengerCount() == 0) 
            {
                flightList[index] = flightList[flightCount - 1];
                flightList[flightCount - 1] = null;
                flightCount--;
                return true;
            }
            return false;
        }

        // view all flights in a formatted table
        // if flights exist, show flight number, origin, destination
        // if no flights exist in system, show message 
        // pass string to UI for printing
        public String viewFlights()
        {
            var sb = new System.Text.StringBuilder();
            sb.Append("========== Flight List ==========\n");
            if (flightCount > 0)
            {
                sb.Append(string.Format("{0, -10} {1, -10} {2,-10}\n", "*Flight*", "*From*", "*To*"));
                for (int i = 0; i < flightCount; i++)
                {
                    int fNum = flightList[i].getFlightNumber();
                    string origin = flightList[i].getOrigin();
                    string destination = flightList[i].getDestination();
                    sb.Append(string.Format("{0, -10} {1, -10} {2,-10}\n", fNum, origin, destination));
                }
            } 
            else 
                sb.Append("No Flights created in the system yet.\n");
            
            return sb.ToString();
        }

        // view a particular flight by flightNumber
        // condition: if flight exists
        // pass string to UI to print
        // !! may return null, please handle
        public String viewParticularFlight(int id)
        {
            int index = findFlight(id);
            if(index != -1)
                return flightList[index].ToString();        
            return null;
        }

    }
}
