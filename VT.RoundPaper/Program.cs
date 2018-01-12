using System;
using System.Linq;
using VT.RoundPaper.CustomExceptions;
using VT.RoundPaper.Domain;
using VT.RoundPaper.Interfaces;

namespace VT.RoundPaper
{
    class Program
    {
        static StreetSpecificationFile streetSpecification;

        static void Main(string[] args)
        {
            CreateSpecificationFile();            
        }

        public static void CreateSpecificationFile()
        {
            Console.WriteLine();
            Console.WriteLine("Insert a line of <space> separated values indicating the numbers for the Street Specification File:");

            var inputNumbers = Console.ReadLine().Trim();
            var strNumbers = inputNumbers.Split(' ');

            try
            {
                int[] numbers = strNumbers.Select(int.Parse).ToArray();
                streetSpecification = new StreetSpecificationFile(numbers);
                MainMenu();
            }            
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input, please use only numbers and spaces.");
                Console.ResetColor();
                CreateSpecificationFile();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                CreateSpecificationFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                CreateSpecificationFile();
            }            
        }

        public static void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Press (1) to generate a report for the Street Specification file.");
            Console.WriteLine("Press (2) for estimating the delivery.");
            Console.WriteLine("Press (3) to create a new Street Specification File.");
            Console.WriteLine("Press (4) to exit the application.");            

            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    ValidateStreetSpecification();
                    break;
                case '2':
                    PlanDelivery();
                    break;
                case '3':
                    CreateSpecificationFile();
                    break;
                case '4':
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    MainMenu();
                    break;
            }
        }

        private static void ValidateStreetSpecification()
        {
            Console.WriteLine();
            Console.WriteLine("The Street Specification File is {0}.", streetSpecification.IsValid ? "valid" : "invalid");
            Console.WriteLine("There are {0} house(s) in this street.", streetSpecification.StreetNumbers.Length);
            Console.WriteLine("There are {0} house(s) on the left side of the street.", streetSpecification.LeftStreetNumbers.Length);
            Console.WriteLine("There are {0} house(s) on the right side of the street.", streetSpecification.RightStreetNumbers.Length);
            
            MainMenu();
        }
        
        private static void PlanDelivery()
        {
            Console.WriteLine();
            Console.WriteLine("Please choose a delivery method:");
            Console.WriteLine("Press (1) to use a Round delivery method.");
            Console.WriteLine("Press (2) to use an Ascending delivery method.");
            Console.WriteLine("Press (3) to go back to the main menu.");

            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    try { PrintDeliveryPlan(new RoundDeliveryMethod(streetSpecification)); }
                    catch (InvalidSpecificationFileException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        PlanDelivery();
                    };
                    break;
                case '2':
                    try { PrintDeliveryPlan(new AscendingDeliveryMethod(streetSpecification)); }
                    catch (InvalidSpecificationFileException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        PlanDelivery();
                    };                    
                    break;
                case '3':
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    PlanDelivery();
                    break;
            }
        }

        private static void PrintDeliveryPlan(IDeliveryMethod plan)
        {
            Console.WriteLine();
            Console.WriteLine("The delivery will be done in the following order:");
            Console.WriteLine(String.Join(", ", plan.HouseNumbers));
            Console.WriteLine("It will require the paper boy/girl to cross the street {0} time(s).", plan.NumberOfCrossings);

            PlanDelivery();
        }
    }
}
