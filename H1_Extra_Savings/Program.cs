namespace H1_Extra_Savings
{
    internal class Program
    {
        static void Main()
        {
            Controller();
        }

        #region Controllers
        static void Controller()
        {
            // Creates an infite loop so the program is repeatable
            while (true)
            {
                // Clears the console, for previous output
                Console.Clear();

                // Creates variable to hold data for the user input
                float deposit = 0;
                float interest = 0;
                float years = 0;

                // Runs a for loop 3 times, to gather input for the information required for the math equation
                for (short i = 0; i < 3; i++)
                {
                    // Outputs a message based on the current value of i 
                    if (i == 0)
                    {
                        Message("How much do you want to deposit?");
                    }
                    else if (i == 1)
                    {
                        Message("What is the interest rate, in percent?");
                    }
                    else
                    {
                        Message("How long will the money be waiting");
                    }

                    // Reads the input from the user and makes it into a char array
                    char[] input = Console.ReadLine().ToCharArray();

                    // Checks if the user input is valid
                    if (!isValidInput(input) || input.Length < 1)
                    {
                        Message("Input invalid, numbers and commas only.\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    }

                    // Creates a string based on the user input char array
                    string inputStr = string.Join("", input);

                    // Converts the input string to float and puts the data into the appropriate variable
                    if (i == 0)
                    {
                        deposit = float.Parse(inputStr);
                    }
                    else if (i == 1)
                    {
                        interest = float.Parse(inputStr);
                    }
                    else
                    {
                        years = float.Parse(inputStr);
                    }
                }

                interest = interest/100;

                // Runs a for loop that runs for each year the money is waiting in the bank and does some math to calculate the balance
                for (int i = 0;i < years; i++)
                {
                    deposit = deposit * (1 + interest);
                }

                // if the deposit is not 0 then call the Result method.
                // This if statement is required because it would call the Result method if the user had invalid input and it would output 0 in the console
                if(deposit != 0)
                {
                    Result(deposit, years);
                }
            }
        }

        static bool isValidInput(char[] input)
        {
            // String with the allowed characters
            string allowedCharacters = "1234567890,";

            // For loop to run through each character in the user input
            for (int i = 0; i < input.Length; i++)
            {
                // If any character is not inside the allowedCharacters string, then it returns false
                if (!allowedCharacters.Contains(input[i]))
                {
                    return false;
                }
            }

            // if the for loop is over, then the string is valid and return true
            return true;
        }

        #endregion

        #region Views

        static void Message(string message)
        {
            // Returns any message from the controller
            Console.WriteLine(message);
        }

        static void Result(float deposit, float years)
        {
            // Outputs the balance, after {years} of interest growth
            // Also changes the colors to green, for this message and then back to whit efor the "Press enter to redo"
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your money in {years} will be: {Math.Round(deposit, 2)}");
            Console.ResetColor();
            Console.WriteLine("Press enter to redo");
            Console.ReadLine();
        } 

        #endregion
    }
}