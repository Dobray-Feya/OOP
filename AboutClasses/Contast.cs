namespace AboutClasses
{
    public class Contact
    {
        // Это поля. Они всегда должны быть приватны. Это инкапсуляция.
        /* Но далее  вместо полей буду использовать свойства, т.к. они более лаконичны, потому что включают в себя геттеры и сеттеры.
         * В C# рекомендуется использовать именно свойства.
         * Свойства пишутся с большой буквы в отличие от полей. И они публичны, т.к. сеттеры и геттеры должны быть публичны.

        private string firstName; //по умолчанию у поля string значение "", а у числового поля значение 0.
        private string lastName;
        private int phoneNumber;
        */

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }

        /* Выше написана краткая запись свойств - автоматические свойства (их рекомендуется использовать для простых классов).
         * На самом деле для автоматических свойств компилятор создает приватное поле и свойство работает с ним. 
         * Ниже приведена полная запись свойств. Ее надо использовать для сложных классов, где н-р, нужны проверки входных данных.
         * В полной записи есть поля, а геттеры и сеттеры задаются в явном виде. 
         * В сеттере используется ключевое слово value. Оно обозначает передаваемое значение
         * 
         * private string firstName;
         * 
         * public string FirstName
         * {
         * get { return firstName }
         * set { firstName = value }
         * }
        */

        // Далее конструкторы. Имя конструктора всегда совпадает с именем класса.
        // Можно применять перегрузку функций-конструкторов, если хочется предусмотреть вызов с разным числом аргументов.

        /* Если при объявлении классса не создавать конструктор, то компилятор C# сам генерирует конструктор по умолчанию
         * (он без аргументов), который ничего не делает, а только вызывает конструктор класса-родителя.
         * Если в классе создать любой конструктор с аргументами, то компилятор не создает конструктор по умолчанию.
         * В этом случае если понадобится создать конструктор без аргументов, то его нужно будет объявить самим. */

        public Contact(string firstName, string lastName, int phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber + 913000000;
        }

        public Contact(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /* Это геттеры и сеттеры - как они пишутся, если не использовать удобный механизм свойств, а использовать только поля.
         * Но в C# вместо такого полного синтаксиса используется упрощеная конструкция - свойства (см. выше).
         * Поэтому спрячу геттеры и сеттеры внутри комментария
         * Не обязательно иметь оба.
         * Они публичные, чтобы можно было получать значения полей и менять их значения (поля же приватны и напрямую к ним обратиться не получится).

        public string GetFirstname()
        {
            return firstName;
        }

        public void SetFirstname(string firstName)
        {
            this.firstName = firstName;
        }

        public string GetLastname()
        {
            return lastName;
        }

        public void SetLastname(string lastName)
        {
            this.lastName = lastName;
        }

        public string GetPhoneNumber()
        {
            return phoneNumber;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }
        */


        /* Методы, которые можно применять к объектам данного класса.
         * Методы публичные, если их надо вызывать из других классов.
         * Могут быть приватные методы для каких-то служебных целей. */


        public void Print()
        {
            if (PhoneNumber == 0)
            {
                Console.WriteLine($"{FirstName} {LastName}");
            }
            else
            {
                Console.WriteLine($"{FirstName} {LastName}, тел. {PhoneNumber}");
            }
        }
        /* Метод выше не static, потому что он работает с конкретным объектом.
        Но есть поля и методы static (см. примеры ниже).
        Поле MaxNameLength относится не к конкретным объектам, а ко всему классу в целом.
        Оно вызывается через имя класса Contact: 
        int maxLenght = Contact.MaxNameLength;
        Функция FormatName форматирует переданную в нее строку, без привязки к конкретному объекту.
        Она вызывается через имя класса Contact:
        string formattedName = Contact.FormatName("Иванов Иван")
        
        Кстати, класс Math содержит только статистические константы и статистические методы
        (такие классы называются классами-утилитами).
        Math.PI - статистическое поле-константа
        Math.Abs(x) - статистический метод  */

        public static readonly int MaxNameLength = 100;

        public static string FormatName(string name)
        {
            // Возвращает имя с инициалами. Тут должен быть код
            return name;
        }

    }
}
