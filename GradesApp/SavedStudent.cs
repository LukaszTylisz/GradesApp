using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;

namespace GradesApp
{
    public class SavedStudent : StudentBase
    {
        private const string fileName = "_grades.txt";
        private string fullFileName;
        
        public SavedStudent(string firstName, string lastName) : base(firstName, lastName)
        {
            fullFileName = $"{firstName}_{lastName}{fileName}";
        }
        public override void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 6)
            {
                using (var writer = File.AppendText($"{fullFileName}"))
                using (var writer2 = File.AppendText($"audit.txt"))
                {
                    writer.WriteLine(grade);
                    writer2.WriteLine($"{FirstName} {LastName} - {grade}    {DateTime.UtcNow}");
                    if (grade < 3)
                    {
                        CheckIsGradeUnder3();
                    }
                }
            }
        }

        public override void AddGrade(string grade)
        {
            double convertedGradeToDouble = char.GetNumericValue(grade[0]);
            if (grade.Length == 2 && char.IsDigit(grade[0]) && grade[0] <= '6' && (grade[1] == '+' || grade[1] == '-'))
            {
                switch (grade[1])
                {
                    case '+':
                        double gradePlus = convertedGradeToDouble + 0.50;
                        if (gradePlus > 1 && gradePlus <= 6)
                        {
                            AddGrade(gradePlus);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid argument: {nameof(grade)}. Only grades from 1 to 6 are allowed!");
                        }
                        break;

                    case '-':
                        double gradeMinus = convertedGradeToDouble - 0.25;
                        if (gradeMinus > 1 && gradeMinus <= 6)
                        {
                            AddGrade(gradeMinus);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid argument: {nameof(grade)}. Only grades from 1 to 6 are allowed!");
                        }
                        break;

                    default:
                        throw new ArgumentException($"Invalid argument: {nameof(grade)}. Only grades from 1 to 6 are allowed!");
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

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            if (File.Exists($"{fullFileName}"))
            {
                using (var reader = File.OpenText($"{fullFileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = double.Parse(line);
                        result.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return result;
        }

        public override void ShowGrades()
        {
            string? line;
            string str = ($"{this.FirstName} {this.LastName} grades are: ");
            using (StreamReader reader = new StreamReader(fullFileName))
            {
                Console.Write(str);
                while ((line = reader.ReadLine()) != null)
                {
                    Console.Write($"{line}; ");
                }
            }
        }

    }
}