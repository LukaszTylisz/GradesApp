using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;

namespace GradesApp
{
    public class SavedStudent : AddingGrades
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