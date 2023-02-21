namespace GradesApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            GradeEntry.ColorWriteLine(ConsoleColor.Blue, "Welcome in the Student's Grades Book console app");

            bool closeApp = false;

            while (!closeApp)
            {
                Console.WriteLine();
                GradeEntry.ColorWriteLine(ConsoleColor.Yellow,
                "1 - Add student's grades to the .txt file and show statistics\n" +
                "2 - Add student's grades to the program memory and show statistics\n" +
                "X - Close app\n");
                GradeEntry.ColorWriteLine(ConsoleColor.Cyan, "Choose one the option");
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
            
            var student = new SavedStudent(firstName, lastName);
            GradeEntry.Combine(firstName, lastName, student);
        }

        private static void AddGradesToMemory()
        {
            string firstName = GetValuefromUser("Please insert student's first name: ");
            string lastName = GetValuefromUser("Please insert student's last name: ");

            var student = new InMemoryStudent(firstName, lastName);
            GradeEntry.Combine(firstName, lastName, student);
        }

        private static string GetValuefromUser(string rating)
        {
            Console.WriteLine($"{rating}");
            string? userInput = Console.ReadLine();
            return userInput!;
        }
    }
}