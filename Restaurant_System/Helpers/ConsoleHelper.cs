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
    }
}
