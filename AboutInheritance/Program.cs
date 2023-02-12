namespace AboutInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contact contact1 = new Contact("Петя", "Иванов", 123456, 4567898, 56567);
            Console.WriteLine("Объекта класса " + contact1.GetType());
            PrintIsContactOrExtraContact(contact1);
            contact1.Print();
            Console.WriteLine(contact1.GetInitials() + " ");
            Console.WriteLine();

            ExtraContact extraContact1 = new ExtraContact("Ваня", "Дудочкин", 123456, "ул. Ленина, д. 5, кв. 12");
            Console.WriteLine("Объекта класса " + extraContact1.GetType());
            PrintIsContactOrExtraContact(extraContact1);
            extraContact1.Print();
            Console.WriteLine(extraContact1.GetInitials() + " ");
            Console.WriteLine();



            // Print - невиртуальная функция, поэтому на объектах, которые формально (через объявление переменной)
            // относятся к классу-родителю, продолжает выполняться функция класса-родителя.

            Contact extraContact2 = extraContact1 as Contact;
            Console.WriteLine("После приведения к типу Contact:");
            extraContact2.Print();
            Console.Write(extraContact2.GetInitials() + " ");
            Console.WriteLine();
        }

        public static void PrintIsContactOrExtraContact(Object contact)
        {
            if (contact is Contact)
            {
                Console.Write("относится к классу Contact, ");
            }
            else
            {
                Console.Write("не относится к классу Contact, ");
            }

            if (contact is ExtraContact)
            {
                Console.WriteLine("относится к классу ExtraContact");
            }
            else
            {
                Console.WriteLine("не относится к классу ExtraContact");
            }
        }
    }
}