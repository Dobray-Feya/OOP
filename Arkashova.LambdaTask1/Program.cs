namespace Arkashova.LambdaTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>
            {
                new Person("Саша", 30),
                new Person("Петя", 22),
                new Person("Петя", 18),
                new Person("Саша", 19),
                new Person("Лена", 20),
                new Person("Маша", 44),
                new Person("Нина", 45),
                new Person("Маша", 22),
                new Person("Саша", 0),
                new Person("Таня", 22),
                new Person("Лена", 1)
            };

            foreach (var person in persons)
            {
                Console.WriteLine(person.Name + " - " + person.Age);
            }

            Console.WriteLine();

            // А) получить список уникальных имен

            var unicNames = persons
                .Select(person => person.Name)
                .Distinct()
                .ToList();

            // Б) вывести список уникальных имен в формате: Имена: Иван, Сергей, Петр.

            Console.WriteLine("Имена: " + string.Join(", ", unicNames));
            Console.WriteLine();

            // В) получить список людей младше 18, посчитать для них средний возраст

            var youngPersons = persons
                .Where(person => person.Age < 18);

            Console.WriteLine("Люди младше 18 лет:");
            Console.WriteLine(string.Join(", ", youngPersons.Select(person => person.Name + " (" + person.Age +")")));

            var youngPersonsAverageAge = youngPersons
                .Select(person => person.Age)
                .Average();

            Console.WriteLine("Средний возраст людей младше 18 лет = " + youngPersonsAverageAge);
            Console.WriteLine();

            // Г) при помощи группировки получить Dictionary, в котором ключи – имена, а значения – средний возраст

            var personsAverageAgesByNames = persons.
                GroupBy(person => person.Name, person => person.Age).
                ToDictionary(name => name.Key, ages => ages.ToList().Average());

            Console.WriteLine("Средний возраст людей для каждого имени:");
            Console.WriteLine(string.Join(", ", personsAverageAgesByNames));
            Console.WriteLine();

            // Д) получить людей, возраст которых от 20 до 45, вывести в консоль их имена в порядке убывания возраста

            var personsFrom20To45Ages = persons
                .Where(person => (person.Age >= 20) && (person.Age <= 45))
                .OrderByDescending(person => person.Age)
                .Select(person => person.Name)
                .ToList();

            Console.WriteLine("Имена людей в возрасте от 20 до 45 лет (в порядке убывания возраста):");
            Console.WriteLine(string.Join(", ", personsFrom20To45Ages));
        }
    }
}