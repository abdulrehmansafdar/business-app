using System;

namespace signl_ogin
{
    internal class utility
    {
        public static int errorhandles(string input)
        {
            int result = 0; // Default value in case of error

            try
            {
                // Attempt to parse the input string to an integer
                result = int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Input is not in the correct format.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Input value is too large or too small to fit in the integer type.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: An unexpected error occurred: {ex.Message}");
            }

            return result;
        }
        public static float errorhandles(float input)
        {
            float result = 0.0f; // Default value in case of error

            try
            {
                // No need to parse the input since it's already a float
                result = input;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: An unexpected error occurred: {ex.Message}");
            }

            return result;
        }

        public static int errorhandles(int input)
        {
            int result = 0; // Default value in case of error

            try
            {
                // No need to parse the input since it's already an integer
                result = input;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: An unexpected error occurred: {ex.Message}");
            }

            return result;
        }
    }
}
