namespace GradesApp
{
    public interface IStudent
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        event GradeUnder3Delegate GradeUnder3;
        void AddGrade(double grade);
        void AddGrade(string grade);
        void ShowGrades();
        Statistics GetStatistics();
        void ShowStatistics();
    }
}
