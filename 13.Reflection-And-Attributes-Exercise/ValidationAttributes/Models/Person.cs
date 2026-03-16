namespace ValidationAttributes.Models
{
    public class Person
    {
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        public string FullName
        {
            get; private set;
        }
        public int Age
        {
            get; private set;
        }
    }
}
