using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOOP_GroupProject_draft1
{
    static class Menu
    {
        // ========== Get Menu String functions ===========
        public static string getMainMenu()
        {
            string s = "======== FLAIR: Flight Reservation System ========";
            s += "\n--- Main Menu ---\n";
            s += "\n1. Customers";
            s += "\n2. Flights";
            s += "\n3. Bookings";
            s += "\n4. Save Changes and Exit";
            s += "\n";
            s += "\nPlease enter an option:";
            return s;
        }

        public static string getCustomerMenu()
        {
            string s = "======== FLAIR: Flight Reservation System ========";
            s += "\n--- Customer Menu ---\n";
            s += "\n1. Add Customer";
            s += "\n2. View All Customers";
            s += "\n3. Delete Customer";
            s += "\n4. Exit to Main Menu";
            s += "\n";
            s += "\nPlease enter an option:";
            return s;
        }

        public static string getFlightMenu()
        {
            string s = "======== FLAIR: Flight Reservation System ========";
            s += "\n--- Flight Menu ---\n";
            s += "\n1. Add Flight";
            s += "\n2. View All Flights";
            s += "\n3. View a Particular Flight";
            s += "\n4. Delete Flight";
            s += "\n5. Exit to Main Menu";
            s += "\n";
            s += "\nPlease enter an option:";
            return s;
        }

        public static string getBookingMenu()
        {
            string s = "======== FLAIR: Flight Reservation System ========";
            s += "\n--- Booking Menu ---\n";
            s += "\n1. Make Booking";
            s += "\n2. View All Bookings";
            s += "\n3. Delete Booking";
            s += "\n4. Exit to Main Menu";
            s += "\n";
            s += "\nPlease enter an option:";
            return s;
        }

        // ========== Run Menu Logic Functions ==========
        public static void runProgram(AirlineCoordinator aCoord)
        {
            bool menuChoiceInvalid = false;
            Console.WriteLine(getMainMenu());
            string menuChoice = Console.ReadLine();

            while (true)
            {
                // execute options according to menu choice
                switch (menuChoice)
                {
                    case "1":
                        runCustomerMenu(aCoord);
                        break;

                    case "2":
                        runFlightMenu(aCoord);
                        break;

                    case "3":
                        runBookingMenu(aCoord);
                        break;

                    case "4":
                        if (confirmExitProgram())
                            return; // exit method (program) on receiving confirmation
                        break;

                    default:
                        menuChoiceInvalid = true;
                        break;
                }

                Console.Clear();
                // print Menu and Input errors (if any)
                Console.WriteLine(getMainMenu());
                if (menuChoiceInvalid)
                {
                    Console.WriteLine("Invalid option. Please enter a valid menu option:");
                    menuChoiceInvalid = false;
                }
                // get user input on menu options again
                menuChoice = Console.ReadLine();
            }
        }

        public static void runCustomerMenu(AirlineCoordinator aCoord)
        {
            bool menuChoiceInvalid = false;
            Console.Clear();
            Console.WriteLine(getCustomerMenu());
            string menuChoice = Console.ReadLine();

            while (true)
            {
                // execute options according to menu choice
                switch (menuChoice)
                {
                    case "1":
                        string firstName = getStringInput("[Add Customer]\n" + aCoord.viewCustomers() + "\nPlease enter customer's first name: ");
                        string lastName = getStringInput("[Add Customer]\n" + aCoord.viewCustomers() + "\nPlease enter customer's last name: ");
                        string phone = getPhoneInput("[Add Customer]\n" + aCoord.viewCustomers() + "\nPlease enter customer's phone number: ");
                        if (!aCoord.createCustomer(firstName, lastName, phone, out string error1))
                            Console.WriteLine("[Add Customer]\n" + aCoord.viewCustomers() + $"\nCannot add customer ({firstName} {lastName} {phone})" + error1);
                        else
                            Console.WriteLine("[Add Customer]\n" + aCoord.viewCustomers() + $"\nSuccessfully created new customer: {firstName} {lastName} ({phone}).");

                        pressAnyKeyToConfirm();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("[View All Customers]");
                        Console.WriteLine(aCoord.viewCustomers());
                        pressAnyKeyToConfirm();
                        break;

                    case "3":
                        Console.Clear();
                        int id = getPositiveIntInput("[Delete Customer]\n" + aCoord.viewCustomers() + "\nPlease enter the ID of the customer to delete:");
                        if (!aCoord.deleteCustomer(id, out string error2))
                            Console.WriteLine("[Delete Customer]\n" + aCoord.viewCustomers() + $"\nCannot delete customer." + error2);
                        else
                            Console.WriteLine("[Delete Customer]\n" + aCoord.viewCustomers() + $"\nSuccessfully deleted customer (ID: {id}).");

                        pressAnyKeyToConfirm();
                        break;

                    case "4":
                        return; // return to main menu

                    default:
                        menuChoiceInvalid = true;
                        break;
                }

                Console.Clear();
                // print Menu and Input errors (if any)
                Console.WriteLine(getCustomerMenu());
                if (menuChoiceInvalid)
                {
                    Console.WriteLine("Invalid option. Please enter a valid menu option:");
                    menuChoiceInvalid = false;
                }
                // get user input on menu options again
                menuChoice = Console.ReadLine();
            }
        }

        public static void runFlightMenu(AirlineCoordinator aCoord)
        {
            bool menuChoiceInvalid = false;
            Console.Clear();
            Console.WriteLine(getFlightMenu());
            string menuChoice = Console.ReadLine();

            while (true)
            {
                // execute options according to menu choice
                switch (menuChoice)
                {
                    case "1":
                        int createFlightNumber = getPositiveIntInput("[Add Flight]\n" + aCoord.viewFlights() + "\nPlease enter the flight number of the new flight: ");
                        string origin = getAirportCodeInput("[Add Flight]\n" + aCoord.viewFlights() + "\nPlease enter flight origin's airport code (e.g. YYZ): ");
                        string destination = getAirportCodeInput("[Add Flight]\n" + aCoord.viewFlights() + "\nPlease enter flight destination's airport code (e.g. YVR): ");
                        int maxSeats = getPositiveIntInput("[Add Flight]\n" + aCoord.viewFlights() + "\nPlease enter new flight's max number of seats: ");
                        if (!aCoord.createFlight(createFlightNumber, origin, destination, maxSeats, out string error1))
                            Console.WriteLine("[Add Flight]\n" + aCoord.viewFlights() + $"\nCannot add flight ({createFlightNumber} from {origin} to {destination})" + error1);
                        else
                            Console.WriteLine("[Add Flight]\n" + aCoord.viewFlights() + $"\nSuccessfully created new flight: {createFlightNumber} from {origin} to {destination}.");

                        pressAnyKeyToConfirm();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("[View All Flights]");
                        Console.WriteLine(aCoord.viewFlights());
                        pressAnyKeyToConfirm();
                        break;

                    case "3":
                            Console.Clear();
                            int viewFlightNumber = getPositiveIntInput("[View Particular Flight]\n" + aCoord.viewFlights() + "\nPlease enter the flight number of the flight to view:");
                            if (aCoord.viewParticularFlight(viewFlightNumber) == null)
                                Console.WriteLine("[View Particular Flight]\n" + aCoord.viewFlights() + $"\nCannot find flight.");
                            else
                                Console.WriteLine("[View Particular Flight]\n" + aCoord.viewParticularFlight(viewFlightNumber));

                        pressAnyKeyToConfirm();

                        break;

                    case "4":
                        Console.Clear();
                        int deleteFlightNumber = getPositiveIntInput("[Delete Flight]\n" + aCoord.viewFlights() + "\nPlease enter the flight number of the flight to delete:");
                        if (!aCoord.deleteFlight(deleteFlightNumber, out string error2))
                            Console.WriteLine("[Delete Flight]\n" + aCoord.viewFlights() + "\nCannot delete flight." + error2);
                        else
                            Console.WriteLine($"Successfully deleted flight (Flight number: {deleteFlightNumber}).");

                        pressAnyKeyToConfirm();
                        break;

                    case "5":
                        return;

                    default:
                        menuChoiceInvalid = true;
                        break;
                }

                Console.Clear();
                // print Menu and Input errors (if any)
                Console.WriteLine(getFlightMenu());
                if (menuChoiceInvalid)
                {
                    Console.WriteLine("Invalid option. Please enter a valid menu option:");
                    menuChoiceInvalid = false;
                }
                // get user input on menu options again
                menuChoice = Console.ReadLine();
            }
        }

        public static void runBookingMenu(AirlineCoordinator aCoord)
        {
            bool menuChoiceInvalid = false;
            Console.Clear();
            Console.WriteLine(getBookingMenu());
            string menuChoice = Console.ReadLine();

            while (true)
            {
                // execute options according to menu choice
                switch (menuChoice)
                {
                    case "1":
                        int customerID = getPositiveIntInput("[Make Booking]\n" + aCoord.viewCustomers() + "\nPlease select customer by entering the customer number: ");
                        int flightNumber = getPositiveIntInput("[Make Booking]\n" + aCoord.viewFlights() + "\nPlease select flight by entering the flight number: ");

                        if (!aCoord.makeBooking(flightNumber, customerID, out string error1))
                            Console.WriteLine("[Make Booking]\n" + aCoord.viewFlights() +$"\nCannot make booking." + error1);
                        else
                            Console.WriteLine("[Make Booking]\n" + aCoord.viewFlights() +$"\nSuccessfully created new booking: " +
                                $"(added {aCoord.getCustomerManager().retrieveCustomerById(customerID).getFirstName()} " +
                                $"{aCoord.getCustomerManager().retrieveCustomerById(customerID).getLastName()} to Flight {flightNumber})");

                        pressAnyKeyToConfirm();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("[View All Bookings]");
                        Console.WriteLine(aCoord.viewBookings());
                        pressAnyKeyToConfirm();
                        break;

                    case "3":
                        Console.Clear();
                        int bookingNumber = getPositiveIntInput("[Delete Booking]\n" + aCoord.viewBookings() + "\nPlease enter the booking number of the booking to delete:");
                        if (!aCoord.deleteBooking(bookingNumber, out string error2))
                            Console.WriteLine($"Cannot delete booking." + error2);
                        else
                            Console.WriteLine($"Successfully deleted Booking #{bookingNumber}.");

                        pressAnyKeyToConfirm();
                        break;

                    case "4":
                        return;

                    default:
                        menuChoiceInvalid = true;
                        break;
                }

                Console.Clear();
                // print Menu and Input errors (if any)
                Console.WriteLine(getBookingMenu());
                if (menuChoiceInvalid)
                {
                    Console.WriteLine("Invalid option. Please enter a valid menu option:");
                    menuChoiceInvalid = false;
                }
                // get user input on menu options again
                menuChoice = Console.ReadLine();
            }
        }

        // ========== Menu confirmation functions ==========

        public static void pressAnyKeyToConfirm()
        {
            Console.WriteLine("[Press any key to confirm and continue]");
            Console.ReadKey();
        }

        public static bool confirmExitProgram()
        {
            Console.WriteLine("Please enter 'yes' to confirm exiting the program:");
            string input = Console.ReadLine();
            if (input != "yes")
                return false;
            else
            {
                Console.Clear();
                Console.WriteLine("Thank you for using our Flight Reservation System. Goodbye!");
                return true;
            }
        }


        // ========= Input validation functions ==========
        public static string getStringInput(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Trim().Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine(message + "\nCannot enter empty value. Please re-enter.");
                    continue;
                }

                Console.Clear();
                return input;
            }
        }

        public static string getPhoneInput(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            while (true)
            {
                string input = Console.ReadLine();
                string regex = @"^\d{10}$";
                Match match = Regex.Match(input, regex);

                if (!match.Success)
                {
                    Console.Clear();
                    Console.WriteLine(message + "\nNot a 10 digit phone number. Please re-enter.");
                    continue;
                }

                Console.Clear();
                return input;
            }
        }

        public static string getAirportCodeInput(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            while (true)
            {
                string input = Console.ReadLine().ToUpper();
                string regex = @"^[A-Z]{3}$";
                Match match = Regex.Match(input, regex);

                if (!match.Success)
                {
                    Console.Clear();
                    Console.WriteLine(message + "\nNot a 3-letter airport code. Please re-enter.");
                    continue;
                }

                Console.Clear();
                return input;
            }
        }

        public static int getPositiveIntInput(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            while (true)
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int inputNum))
                {
                    Console.Clear();
                    Console.WriteLine(message + "\nCannot enter a non-number. Please re-enter.");
                    continue;
                }

                if (inputNum <= 0)
                {
                    Console.Clear();
                    Console.WriteLine(message + "\nCannot enter a negative number. Please re-enter.");
                    continue;
                }
                Console.Clear();
                return inputNum;
            }
        }

        // ========== String length limitation functions ==========
        public static string limitStringLength(string input, int length){
            if (input.Length <= length)
                return input;

            string finalString = input.Substring(0, length - 5);
            return finalString + "... ";
        }
    }
}
