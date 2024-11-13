namespace ScoreCalculation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("Welcome To My SCORE Calculation App");
            Console.WriteLine("============================================");
            Console.WriteLine("Title:        *** SCORE Calculation APP ***");
            Console.WriteLine("Description:  This calculator adds 1 point for each even number \n 3 points for each odd number \n 5 points for every 8 you provide respectively and sums it");
            Console.WriteLine("Author:       Esther Zamani");
            Console.WriteLine("Release Date: November / 2024");
            Console.WriteLine("Date is:      {0}, {1}", DateTime.Now.ToString("F"), DateTime.Now.Year);
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("");


            Console.WriteLine("Please input any range of numbers seperated by coma:");
            Console.ForegroundColor = ConsoleColor.White;
            string input = (Console.ReadLine() ?? "").Trim();
            bool isValid = !string.IsNullOrEmpty(input);
            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a range of numbers separated by commas.");
                return;
            }

            int[] inputArray;
            try
            {
                inputArray = input.Split(',')
                                 .Select(s => int.Parse(s.Trim()))
                                 .ToArray();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please make sure all inputs are valid integers separated by commas.");
                return;
            }

            Console.WriteLine("The total score is: " + Calculator.CalculateScore(inputArray));
        }
    }
}
