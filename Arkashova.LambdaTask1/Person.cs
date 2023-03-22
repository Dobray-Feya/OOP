namespace Arkashova.LambdaTask1
{
    internal class Person
    {
        public string Name { get; }

        public int Age { get; }

        public Person(string name, int age)
        {
            if (age < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(age), "Возраст не может быть меньше нуля.");
            }

            Name = name;
            Age = age;
        }
    }
}
