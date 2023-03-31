namespace Arkashova.LambdaTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>
            {
                new("Саша", 30),
                new("Петя", 22),
                new("Петя", 18),
                new("Саша", 19),
                new("Лена", 20),
                new("Маша", 4),
                new("Нина", 45),
                new("Маша", 22),
                new("Саша", 40),
                new("Таня", 22),
                new("Лена", 1)
            };

            foreach (var person in persons)
            {
                Console.WriteLine(person.Name + " - " + person.Age);
            }

            Console.WriteLine();

            // А) получить список уникальных имен

            var uniqueNames = persons
                .Select(p => p.Name)
                .Distinct()
                .ToList();

            // Б) вывести список уникальных имен в формате: Имена: Иван, Сергей, Петр.

            Console.WriteLine("Имена: " + string.Join(", ", uniqueNames));
            Console.WriteLine();

            // В) получить список людей младше 18, посчитать для них средний возраст

            var youngPersons = persons.Where(p => p.Age < 18);

            var youngPersonsNamesAndAges = youngPersons.Select(p => p.Name + " (" + p.Age + ")");

            if (youngPersons.ToList().Count == 0)
            {
                Console.WriteLine("Людей младше 18 лет нет.");
            }
            else
            {
                Console.WriteLine("Люди младше 18 лет:");
                Console.WriteLine(string.Join(", ", youngPersonsNamesAndAges));

                var youngPersonsAverageAge = youngPersons.Average(p => p.Age);
                Console.WriteLine("Средний возраст людей младше 18 лет = " + youngPersonsAverageAge);
            }

            Console.WriteLine();

            // Г) при помощи группировки получить Dictionary, в котором ключи – имена, а значения – средний возраст

            var personsAverageAgesByNames = persons
                .GroupBy(p => p.Name, p => p.Age)
                .ToDictionary(g => g.Key, g => g.Average());

            Console.WriteLine("Средний возраст людей для каждого имени:");
            Console.WriteLine(string.Join(", ", personsAverageAgesByNames));
            Console.WriteLine();

            // Д) получить людей, возраст которых от 20 до 45, вывести в консоль их имена в порядке убывания возраста

            var personsFrom20To45Ages = persons
                .Where(p => (p.Age >= 20) && (p.Age <= 45))
                .OrderByDescending(p => p.Age)
                .Select(p => p.Name)
                .ToList();

            Console.WriteLine("Имена людей в возрасте от 20 до 45 лет (в порядке убывания возраста):");
            Console.WriteLine(string.Join(", ", personsFrom20To45Ages));
        }
    }
}