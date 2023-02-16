
using GradesApp;

public class TypeTests
{
    public class Typetest
    {
        public delegate string WriteMessage(string Message);

        int counter = 0;

        [Fact]
        public void WriteMessageDelegateCanPointToMethode()
        {
            WriteMessage del = ReturnMessage;
            del += ReturnMessage;
            del += ReturnMessage2;
            var result = del("Hello");
            Assert.Equal(3, counter);
        }

        string ReturnMessage(string message)
        {
            counter++;
            return message;
        }

        string ReturnMessage2(string message)
        {
            counter++;
            return message;
        }

        [Fact]
        public void GetStudentReturnsDirrefentsObjects()
        {
            var student1 = GetStudent("Tom", "Hanks");
            var student2 = GetStudent("Frank", "Sinatra");

            Assert.NotSame(student2, student1);
            Assert.False(Object.ReferenceEquals(student1, student2));
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var student1 = GetStudent("Sergio", "Ramos");
            var student2 = student1;

            Assert.Same(student2, student1);
            Assert.True(Object.ReferenceEquals(student1, student2));
        }
        private InMemoryStudent GetStudent(string name, string secondName)
        {
            return new InMemoryStudent(name, secondName);
        }
    }
}