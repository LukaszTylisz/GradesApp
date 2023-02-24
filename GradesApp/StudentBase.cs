namespace GradesApp
{
    public delegate void GradeUnder3Delegate(object sender, EventArgs args);
    public abstract class StudentBase : Person, IStudent
    {
        public StudentBase(string firstName, string lastName) : base(firstName, lastName)
        {
            FirstName= firstName;
            LastName= lastName;
        }
        public event GradeUnder3Delegate? GradeUnder3;
        public abstract void ShowGrades();
        public abstract Statistics GetStatistics();
        public abstract void AddGrade(double grade);
        
        public  void AddGrade(string grade)
        {
            double convertedGradeToDouble = char.GetNumericValue(grade[0]);
            if (grade.Length == 2 && char.IsDigit(grade[0]) && grade[0] <= '6' && (grade[1] == '+' || grade[1] == '-'))
            {
                {
                    double gradePlus = convertedGradeToDouble + 0.50;
                    double gradeMinus = convertedGradeToDouble - 0.25;
                    if (gradePlus > 1 && gradeMinus > 1 && gradeMinus <= 6 && gradePlus <= 6)
                    {
                        switch (grade[1])
                        {
                            case '+':
                                AddGrade(gradePlus);
                                break;

                            case '-':
                                AddGrade(gradeMinus);
                                break;

                            default:
                                throw new ArgumentException($"Invalid argument: {nameof(grade)}. Only grades from 1 to 6 are allowed!");
                        }
                    }
                }
            }
            else
            {
                double gradeDouble = 0;
                var isParsed = double.TryParse(grade, out gradeDouble);
                if (isParsed && gradeDouble > 0 && gradeDouble <= 6)
                {
                    AddGrade(gradeDouble);
                }
                else
                {
                    throw new ArgumentException($"Invalid argument: {nameof(grade)}. Only grades from 1 to 6 are allowed!");
                }
            }
        }

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
