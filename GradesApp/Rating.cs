namespace GradesApp
{
    public abstract class Rating : StudentBase
    {
        protected Rating(string firstName, string lastName) : base(firstName, lastName)
        {
        }
        public static void CombineToFile(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                var savedStudent = new SavedStudent(firstName, lastName);
                savedStudent.GradeUnder3 += OnGradeUnder3;
                EnterGrade(savedStudent);
                savedStudent.ShowStatistics();
            }
            else
            {
                ColorWriteLine(ConsoleColor.Red, "Fields can't be empty");
            }
        }
        public static void CombineToMemory(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                var inMemoryStudent = new InMemoryStudent(firstName, lastName);
                inMemoryStudent.GradeUnder3 += OnGradeUnder3;
                EnterGrade(inMemoryStudent);
                inMemoryStudent.ShowStatistics();
            }
            else
            {
                ColorWriteLine(ConsoleColor.Red, "Fields can't be empty");
            }
        }
        private static void EnterGrade(IStudent student)
        {
            while (true)
            {
                ColorWriteLine(ConsoleColor.Magenta, $"Enter grade for {student.FirstName} {student.LastName}");
                var input = Console.ReadLine();
                if (input == "q" || input == "Q")
                {
                    break;
                }
                try
                {
                    student.AddGrade(input!);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    ColorWriteLine(ConsoleColor.Green, "To leave and show the statistics press 'Q'");
                }
            }
        }
        static void OnGradeUnder3(object sender, EventArgs args)
        {
            ColorWriteLine(ConsoleColor.DarkGray, "Oh no! Student got grade under 3. We should inform student’s parents about this fact!");
        }
        public static void ColorWriteLine(ConsoleColor theColor, string theMessage)
        {
            Console.ForegroundColor = theColor;
            Console.WriteLine(theMessage);
            Console.ResetColor();
        }
    }
}
