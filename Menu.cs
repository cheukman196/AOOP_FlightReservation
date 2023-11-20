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
        public static void printMainMenu()
        {
            string s = "\n======== Main Menu ========";
            s += "\n1. Customers";
            s += "\n2. Flights";
            s += "\n3. Bookings";
            s += "\n4. Exit";
            s += "\n";
            s += "\nPlease enter an option:";
            Console.WriteLine(s);
        }

        public static void printCustomerMenu()
        {
            string s = "\n======== Customer Menu ========";
            s += "\n1. Add Customer";
            s += "\n2. View All Customers";
            s += "\n3. Delete Customer";
            s += "\n4. Exit to Main Menu";
            s += "\n";
            s += "\nPlease enter an option:";
            Console.WriteLine(s);
        }

        public static void printFlightMenu()
        {
            string s = "\n======== Flight Menu ========";
            s += "\n1. Add Flight";
            s += "\n2. View a Particular Flight";
            s += "\n3. View All Flights";
            s += "\n4. Delete Flight";
            s += "\n5. Exit to Main Menu";
            s += "\n";
            s += "\nPlease enter an option:";
            Console.WriteLine(s);
        }

        public static void printBookingMenu()
        {
            string s = "\n======== Booking Menu ========";
            s += "\n1. Making Booking";
            s += "\n2. View All Bookings";
            s += "\n3. Exit to Main Menu";
            s += "\n";
            s += "\nPlease enter an option:";
            Console.WriteLine(s);
        }

/*        public static string getValidMenuOption(int optionCount, string menuString)
        {
            // option set creates a set of strings that has value from 1 - optionCount
            // Note: that are all STRINGS, not int types
            // Justification: why convert to int when no calculation or complicated range checks are invovled?
            string[] optionSet = new string[optionCount];
            for (int i = 1; i <= optionCount; i++)
                optionSet[i - 1] = i.ToString();

            // print menu
            Console.WriteLine(menuString);

            // prompt user for input
            // loop until input is valid (matches values in option set)
            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (Array.IndexOf(optionSet, input) != -1)
                    return input;
                else
                {
                    Console.WriteLine(menuString);
                    Console.WriteLine($"Invalid option. Please enter option 1 - {optionCount} ");
                }
            }

        }*/

        public static void runProgram(AirlineCoordinator aCoord)
        {
            bool menuChoiceInvalid = false;
            printMainMenu();
            string menuChoice = Console.ReadLine();

            while (true)
            {
                // execute options according to menu choice
                switch (menuChoice)
                {
                    case "1":
                        break;

                    case "2":
                        break;

                    case "3":
                        break;

                    case "4":
                        if(confirmExitProgram())
                            return; // exit method (program) on receiving confirmation
                        break;

                    default:
                        menuChoiceInvalid = true;
                        break;
                }

                Console.Clear();
                // print Menu and Input errors (if any)
                printMainMenu();
                if (menuChoiceInvalid)
                {
                    Console.WriteLine("Invalid option. Please enter a valid menu option:");
                    menuChoiceInvalid = false;
                }
                // get user input on menu options again
                menuChoice = Console.ReadLine();
            }
        }

        public static void customerMenu(AirlineCoordinator aCoord)
        {
            bool menuChoiceInvalid = false;
            printCustomerMenu();
            string menuChoice = Console.ReadLine();

            while (true)
            {
                // execute options according to menu choice
                switch (menuChoice)
                {
                    case "1":
                        Console.WriteLine("Adding a new customer.");
                        string firstName = getStringInput("Please enter the First Name of the customer: ");
                        string lastName = getStringInput("Please enter the Last Name of the customer: ");
                        string phone = getPhoneInput("Please enter the phone number of the customer: ");
                        if (!aCoord.createCustomer(firstName, lastName, phone, out string error))
                            Console.WriteLine("Cannot add customer.\n" + error);
                        else
                            Console.WriteLine($"Created new customer: {firstName} {lastName}.");
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine(aCoord.viewCustomers());
                        break;

                    case "3":

                        break;

                    case "4":
                            return; 
                        break;

                    default:
                        menuChoiceInvalid = true;
                        break;
                }
                
                pressAnyKeyToConfirm();
                Console.Clear();
                // print Menu and Input errors (if any)
                printCustomerMenu();
                if (menuChoiceInvalid)
                {
                    Console.WriteLine("Invalid option. Please enter a valid menu option:");
                    menuChoiceInvalid = false;
                }
                // get user input on menu options again
                menuChoice = Console.ReadLine();
            }
        }


        public static bool confirmExitProgram()
        {
            Console.WriteLine("Please enter 'yes' to confirm exiting the program:");
            string input = Console.ReadLine();
            if (input != "yes")
                return false;
            else
            {
                Console.WriteLine("Exiting program. Thank you for using our Flight Reservation System.");
                return true;
            }
        }

        public static string getStringInput(string message)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                if (input.Trim().Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Cannot enter empty value. Please re-enter.");
                    continue;
                }

                Console.Clear();
                return input;
            }
        }

        public static string getPhoneInput(string message)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                string regex = @"^\d{10}$";
                Match match = Regex.Match(input, regex);

                if (!match.Success)
                {
                    Console.Clear();
                    Console.WriteLine("Not a 10 digit phone number. Please re-enter.");
                    continue;
                }

                Console.Clear();
                return input;
            }
        }

        public static int getPositiveIntInput(string message)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int inputNum))
                {
                    Console.Clear();
                    Console.WriteLine("Cannot enter a non-number. Please re-enter.");
                    continue;
                }

                if(inputNum < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Cannot enter a negative number. Please re-enter.");
                    continue;
                }
                Console.Clear();
                return inputNum;
            }
        }

        public static void pressAnyKeyToConfirm()
        {
            Console.WriteLine("[Press any key to confirm and continue]");
            Console.ReadKey();
        }
    }
}
