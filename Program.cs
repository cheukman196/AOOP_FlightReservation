using System;

namespace AOOP_GroupProject_draft1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Flight Manager Test
            FlightManager fm = new FlightManager(200);
            fm.createFlight(111, "HKG", "YYZ", 20);
            fm.createFlight(222, "FDA", "BDE", 10);
            fm.createFlight(333, "XPT", "NLQ", 4);
            fm.createFlight(444, "EUT", "PKP", 35);
            fm.createFlight(111, "HKG", "YYZ", 20);

            fm.viewFlights();
            Console.WriteLine(fm.deleteFlight(221));
            fm.deleteFlight(222);
            Console.WriteLine(fm.viewFlights());
            Console.WriteLine(fm.viewParticularFlight(111));
            Console.WriteLine(fm.viewParticularFlight(332));



            Customer c1 = new Customer("Lee", "Adams", "1111");
            Customer c2 = new Customer("Queenie", "Merriweather", "2222");
            Customer c3 = new Customer("Ian", "Kojima", "3333");
            Customer c4 = new Customer("Levi", "Arson", "4444");


            // // Base Classes Testing
            //Flight f1 = new Flight(111, "HKG", "YYZ", 20);
            //Flight f2 = new Flight(222, "FDA", "BDE", 10);
            //Flight f3 = new Flight(333, "XPT", "NLQ", 4);
            //Flight f4 = new Flight(444, "EUT", "PKP", 35);

            //Booking b1 = new Booking(f1, c1);
            //Booking b2 = new Booking(f1, c2);
            //Booking b3 = new Booking(f1, c3);
            //Booking b4 = new Booking(f2, c4);
            //Booking b5 = new Booking(f3, c1);
            //Booking b6 = new Booking(f3, c3);

            //f1.addPassenger(c1);
            //f1.addPassenger(c2);
            //f1.addPassenger(c3);
            //f2.addPassenger(c4);
            //f3.addPassenger(c1);
            //f3.addPassenger(c3);
            //f1.removePassenger(100);

            //Console.WriteLine(c1.ToString());
            //Console.WriteLine(c2.ToString());
            //Console.WriteLine(f1.ToString());
            //Console.WriteLine(f2.ToString());
            //Console.WriteLine(b1.ToString());
            //Console.WriteLine(b6.ToString());
        }
    }
}
