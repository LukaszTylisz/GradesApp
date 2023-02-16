namespace GradesApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Rating.ColorWriteLine(ConsoleColor.Blue, "Welcome in the Student's Grades Book console app");

            bool closeApp = false;

            while (!closeApp)
            {
                Console.WriteLine();
                Rating.ColorWriteLine(ConsoleColor.Yellow,
                "1 - Add student's grades to the .txt file and show statistics\n" +
                "2 - Add student's grades to the program memory and show statistics\n" +
                "X - Close app\n");
                Rating.ColorWriteLine(ConsoleColor.Cyan, "Choose one the option");
                var userInput = Console.ReadLine()
                                       .ToUpper();
                switch (userInput)
                {
                    case "1":
                        AddGradesToFile();
                        break;
                    case "2":
                        AddGradesToMemory();
                        break;
                    case "X":
                        closeApp = true;
                        break;

                    default:
                        Console.WriteLine("Invalid operation. \n");
                        continue;
                }
                Console.WriteLine("\nSee You next time, press any key to exit");
                Console.ReadKey();
            }
        }
        private static void AddGradesToFile()
        {
            string firstName = GetValuefromUser("Please insert student's first name: ");
            string lastName = GetValuefromUser("Please insert student's last name: ");

            Rating.CombineToFile(firstName, lastName);
        }
        private static void AddGradesToMemory()
        {
            string firstName = GetValuefromUser("Please insert student's first name: ");
            string lastName = GetValuefromUser("Please insert student's last name: ");
            Rating.CombineToMemory(firstName, lastName);
        }
        private static string GetValuefromUser(string rating)
        {
            Console.WriteLine($"{rating}");
            string? userInput = Console.ReadLine();
            return userInput!;
        }
    }
}