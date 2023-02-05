namespace AboutInheritance
{
    internal sealed class ExtraContact : Contact         // sealed - запрет наследования от этого класса
                                                         // также можно применять sealed для методов класса
    {
        public string HomeAddress { get; set; }

        public ExtraContact(string firstName, string lastName, int phoneNumber, string adress) : base(firstName, lastName, phoneNumber)
        {
            HomeAddress = adress;
        }

        public ExtraContact(string firstName, string lastName, int phoneNumber) : base(firstName, lastName, phoneNumber)
        {
        }

        /* Здесь Print - невиртуальная функция.
         * Это называется сокрытием (hiding), 
         * потому что если будут обращаться к этой функции, то вызовется функция потомка.
         * Но если для потомка формально (при объявлении перменной) указан класс-родителя,
         * то для него вызовется функция класса-родителя.
         * Рекомендуется указать ключевое слово new, иначе будет warning.
         * Тем самым мы говорим компилятору, что мы понимаем, что тут будет сокрытие метода. */

        public new void Print()
        {
            if (MainPhoneNumber == 0)
            {
                Console.Write($"{FirstName} {LastName}");
            }
            else
            {
                Console.Write($"{FirstName} {LastName} (тел. {MainPhoneNumber})");
            }

            if (HomeAddress != "")
            {
                Console.WriteLine($", {HomeAddress}");
            }
            else 
            {
                Console.WriteLine();
            }
        }

        /* Но есть и другой, более полезный вариант переопределения методов
         * Он называется переопределением метода (overriding).
         * Функции, которые можно переопределить в классах-потомках, называются виртуальными (virtual functions)
         * При вызове виртуальной функции будет использоваться реализация,
         * соответствующая настоящему типу объекта, а не типу ссылки.
         * Нужно указывать ключевое слово override. */

        /* поля не могут быть виртуальными. Они всегда hiding (перекрытие). */

        public override string GetInitials()
        {
            // Из дочернего класса можно обратиться к полям и методам
            // непосредственного родителя при помощи слова base, чтобы "дополнить" его реализацию

            return "тов. " + base.GetInitials();
        }
    }
}
