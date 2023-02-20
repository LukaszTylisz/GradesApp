using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace GradesApp
{
    public class InMemoryStudent : AddingGrades
    {
        public List<double> grades;
        public InMemoryStudent(string firstName, string lastName) : base(firstName, lastName)
        {
            grades = new List<double>();
        }

        public override void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 6)
            {
                grades.Add(grade);
                if (grade < 3)
                {
                    CheckIsGradeUnder3();
                }
            }
            else
            {
                throw new ArgumentException($"Invalid argument: {nameof(grade)}. Only grades from 1 to 6 are allowed!");
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach (var grade in grades)
            {
                result.Add(grade);
            }
            return result;
        }

        public override void ShowGrades()
        {
            string showFullName = ($"{this.FirstName} {this.LastName} grades are:");
            string join = string.Join("; ", grades);
            GradeEntry.ColorWriteLine(ConsoleColor.DarkYellow,($"\n{showFullName} {join}"));
        }
    }
}