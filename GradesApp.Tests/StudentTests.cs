using GradesApp;

public class StudentTests
{
    [Fact]
    public void Test1()
    {
        var student = new InMemoryStudent("Johan", "Cruyff");
        student.AddGrade(4.0);
        student.AddGrade(3.5);
        student.AddGrade(4.5);
        student.AddGrade(5.0);

        var result = student.GetStatistics();

        Assert.Equal(4.2, result.Average, 1);
        Assert.Equal(5.0, result.High, 1);
        Assert.Equal(3.5, result.Low, 1);
    }
}