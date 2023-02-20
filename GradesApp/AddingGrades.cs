
namespace GradesApp
{
    public abstract class AddingGrades : StudentBase
    {
        protected AddingGrades(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public override void AddGrade(string grade)
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
    }
}
