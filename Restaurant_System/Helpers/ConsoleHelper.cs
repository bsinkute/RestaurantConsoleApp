using System.Text;

namespace RestaurantSystem.Helpers
{
    public static class ConsoleHelper
    {
        public static bool YesOrNoInput()
        {
            string input = Console.ReadLine().ToLower();
            while (input != "yes" && input != "y" && input != "no" && input != "n")
            {
                Console.Write("Invalid input. Pease enter (yes/no): ");
                input = Console.ReadLine().ToLower();
            }
            if (input == "yes" || input == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void GoBack()
        {
            Console.Write("Press any key to go back to employee menu. ");
            Console.ReadKey();
        }

        public static string ReadMaskedInput()
        {
            StringBuilder realInput = new StringBuilder(); // To store the actual input
            StringBuilder maskedInput = new StringBuilder(); // To store the masked input

            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(intercept: true); // Read key without displaying it

                if (keyInfo.Key == ConsoleKey.Backspace && realInput.Length > 0)
                {
                    // Remove last character from both realInput and maskedInput
                    realInput.Remove(realInput.Length - 1, 1);
                    maskedInput.Remove(maskedInput.Length - 1, 1);

                    // Move cursor back and clear the last displayed character
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(keyInfo.KeyChar)) // Ignore control characters
                {
                    // Append the actual character to realInput and '*' to maskedInput
                    realInput.Append(keyInfo.KeyChar);
                    maskedInput.Append("*");

                    // Display '*' on the console
                    Console.Write("*");
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);

            Console.WriteLine(); // Move cursor to the next line after Enter

            return realInput.ToString(); // Return the actual input (without masking)
        }
    }
}
