using System;

namespace AOOP_GroupProject_draft1
{
    class Program
    {
        static AirlineCoordinator aCoord;
        static void Main(string[] args)
        {
            CustomerManager cm = UtilsTextFile.loadCustomerFile(UtilsTextFile.customerManagerFilePath);
            FlightManager fm = UtilsTextFile.loadFlightFile(UtilsTextFile.flightManagerFilePath, cm);
            BookingManager bm = UtilsTextFile.loadBookingFile(UtilsTextFile.bookingManagerFilePath, cm, fm);
            UtilsTextFile.loadClassUniqueID(UtilsTextFile.uniqueClassIDFilePath);

            aCoord = new AirlineCoordinator(cm, fm, bm);

            //aCoord.createFlight(111, "HKG", "YYZ", 4);
            //aCoord.createFlight(222, "FDA", "BDE", 10);
            //aCoord.createFlight(333, "XPT", "NLQ", 20);
            //aCoord.createFlight(444, "EUT", "PKP", 35);
            //aCoord.createFlight(555, "EKF", "VLT", 35);


            //aCoord.createCustomer("Lee", "Adams", "1111");
            //aCoord.createCustomer("Queenie", "Merriweather", "2222");
            //aCoord.createCustomer("Ian", "Kojima", "3333");
            //aCoord.createCustomer("Levi", "Arson", "4444");
            //aCoord.createCustomer("Ashe", "Larson", "5555");

            //aCoord.makeBooking(111, 100, out string errorA);
            //aCoord.makeBooking(111, 101, out string errorB);
            //aCoord.makeBooking(111, 102, out string errorC);
            //aCoord.makeBooking(111, 103, out string errorD);
            //aCoord.makeBooking(111, 104, out string errorE);
            //aCoord.makeBooking(222, 101, out string errorF);
            //aCoord.makeBooking(333, 102, out string errorG);
            //aCoord.makeBooking(444, 103, out string errorH);

            //Console.WriteLine(aCoord.deleteCustomer(100, out string errorI));
            //Console.WriteLine(aCoord.deleteCustomer(101, out string errorJ));
            //Console.WriteLine(aCoord.deleteFlight(111, out string errorK));
            //Console.WriteLine(aCoord.deleteFlight(222, out string errorL));

            //Console.WriteLine(errorA + " " + errorB + " " + errorC + " " + errorD);
            //Console.WriteLine(errorE + " " + errorF + " " + errorG + " " + errorH);
            //Console.WriteLine(errorI + " " + errorJ + " " + errorK + " " + errorL);

            Console.WriteLine(aCoord.viewFlights());
            Console.WriteLine(aCoord.viewCustomers());
            Console.WriteLine(aCoord.viewBookings());

            Menu.customerMenu(aCoord);

            UtilsTextFile.saveFlightFile(UtilsTextFile.flightManagerFilePath,
                aCoord.getFlightManager().getFlightCount(), aCoord.getFlightManager().getFlightList());

            UtilsTextFile.saveCustomerFile(UtilsTextFile.customerManagerFilePath,
               aCoord.getCustomerManager().getCustomerCount(), aCoord.getCustomerManager().getCustomerList());

            UtilsTextFile.saveBookingFile(UtilsTextFile.bookingManagerFilePath,
               aCoord.getBookingManager().getBookingCount(), aCoord.getBookingManager().getBookingList());

            UtilsTextFile.saveClassUniqueID(UtilsTextFile.uniqueClassIDFilePath, Customer.getUniqueCustomerID(), Booking.getUniqueBookingNumber());

            //CustomerManager loadedCustomerManager = UtilsTextFile.loadCustomerFile(UtilsTextFile.customerManagerFilePath);
            //FlightManager loadedFlightManager = UtilsTextFile.loadFlightFile(UtilsTextFile.flightManagerFilePath, loadedCustomerManager);
            //BookingManager loadedBookingManager = UtilsTextFile.loadBookingFile(UtilsTextFile.bookingManagerFilePath, loadedCustomerManager, loadedFlightManager);
            //UtilsTextFile.loadClassUniqueID(UtilsTextFile.uniqueClassIDFilePath);

            //Console.WriteLine(loadedCustomerManager.viewCustomers());
            //Console.WriteLine(loadedFlightManager.viewFlights());
            //Console.WriteLine(loadedFlightManager.viewParticularFlight(555));
            //Console.WriteLine(loadedBookingManager.viewBookings());
            //Console.WriteLine(Customer.getUniqueCustomerID() + " " + Booking.getUniqueBookingNumber());
        }
    }
}
