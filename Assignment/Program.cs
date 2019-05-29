using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Program
    {

        public static int ValidateMenuSelection()
        {
            string userInput = "";
            bool validMenuSelect = false;

            while (validMenuSelect == false)
            {
                Console.WriteLine("1 = Get Rectangle Length");
                Console.WriteLine("2 = Change Rectangle Length");
                Console.WriteLine("3 = Get Rectangle width");
                Console.WriteLine("4 = Change Rectangle Width");
                Console.WriteLine("5 = Get Rectangle perimeter");
                Console.WriteLine("6 = Get Rectangle Area");
                Console.WriteLine("7 = Exit\n");

                Console.WriteLine("Please select an option,by entering a number:\n");
                userInput = Console.ReadLine();

                if (userInput != "1" &&
                    userInput != "2" &&
                    userInput != "3" &&
                    userInput != "4" &&
                    userInput != "5" &&
                    userInput != "6" &&
                    userInput != "7")
                {
                    Console.WriteLine("That's not a valid menu option, please try again : \n");
                }
                else
                {
                    validMenuSelect = true;
                }
            }

            Console.WriteLine();
            return int.Parse(userInput);
        }
        public static int ValidateUserInput(string rectSide)
        {
            int number = 1;
            bool isValid = false;

            while (isValid == false)
            {
                Console.WriteLine($"Please enter the {rectSide} of your rectangle :");
                string userInput = Console.ReadLine();
                Console.WriteLine();

                bool result = int.TryParse(userInput, out number);

                if (result == false)
                {
                    Console.WriteLine("That is not a valid input please, please try again . \n");
                }
                else if (number <= 0)
                {
                    Console.WriteLine("Number cannot be less than 0, please try again.\n");
                }
                else if (number > 0)
                {
                    isValid = true;
                    Console.WriteLine($"The {rectSide} of your rectangle is now {number}\n");

                }
            }
            return number;
        }



        static void Main(string[] args)
        {
            Rectangle c = new Rectangle();
            bool validRectangleSelect = false;
            string rectangleSelection;
            int selection;

            while (validRectangleSelect == false)
            {
                Console.WriteLine("1 = Use default value of Length=1 and Width=1 \n");
                Console.WriteLine("2 = Provide your own Perimeters\n");
                Console.WriteLine("Choose a menu item to begin:");
                rectangleSelection = Console.ReadLine();
                Console.WriteLine();

                if (rectangleSelection != "1" && rectangleSelection != "2")
                {
                    Console.WriteLine("That's not a valid selection, please try again.\n");
                }
                else if (int.Parse(rectangleSelection) == 1)
                {
                    validRectangleSelect = true;
                    int length = 1;
                    int width = 1;

                    Console.WriteLine($"Your default Length is {length} and Width is {width}.\n");
                    Rectangle customRectangle = new Rectangle(length, width);
                    c = customRectangle;

                }
                else if (int.Parse(rectangleSelection) == 2)
                {
                    validRectangleSelect = true;

                    int length;
                    int width;

                    length = ValidateUserInput("length");
                    width = ValidateUserInput("width");

                    Console.WriteLine($"Your custom Length is {length} and Width is {width}.\n");
                    Rectangle customRectangle = new Rectangle(length, width);
                    c = customRectangle;
                }
            }


            selection = ValidateMenuSelection();

            while (selection != 7)
            {
                int result;

                switch (selection)
                {
                    case 1:
                        Console.WriteLine($"Length is: {c.GetLength()}\n");
                        break;
                    case 2:
                        result = ValidateUserInput("length");
                        c.SetLength(result);
                        break;
                    case 3:
                        Console.WriteLine($"Width is: {c.GetWidth()}\n");
                        break;
                    case 4:
                        result = ValidateUserInput("width");
                        c.SetWidth(result);
                        break;
                    case 5:
                        Console.WriteLine($"The Perimeter of Length {c.GetLength()} and Width {c.GetWidth()} is: {c.GetPerimeter()}\n");
                        break;
                    case 6:
                        Console.WriteLine($"The Area of Length {c.GetLength()} and Width {c.GetWidth()} is: {c.GetArea()}\n");
                        break;
                    default:
                        break;
                }

                selection = ValidateMenuSelection();

            }

        }
    }
}
