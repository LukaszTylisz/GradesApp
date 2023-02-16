namespace GradesApp
{
    public delegate void GradeUnder3Delegate(object sender, EventArgs args);
    public abstract class StudentBase: Person, IStudent
    {
        public StudentBase(string firstName, string lastName) : base(firstName, lastName)
        {
            FirstName= firstName;
            LastName= lastName;
        }
        public event GradeUnder3Delegate? GradeUnder3;
        public abstract void AddGrade(double grade);
        public abstract void AddGrade(string grade);
        public abstract void ShowGrades();
        public abstract Statistics GetStatistics();
        public void ShowStatistics()
        {
            var stat = GetStatistics();
            if (stat.Count !=0)
            {
                ShowGrades();
                Console.WriteLine($"\n{FirstName} {LastName} statistics: "); 
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Total grades: {stat.Count}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Highest grade: {stat.High:N2}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Lowest grade: {stat.Low:N2}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Average: {stat.Average:N2}");
                Console.WriteLine();
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Couldn't get statistics for {this.FirstName} {this.LastName} because no grade has been added.");
            }
        }
        protected void CheckIsGradeUnder3()
        {
            if (GradeUnder3 != null)
            {
                GradeUnder3(this, new EventArgs());
            }
        }
    }
}
