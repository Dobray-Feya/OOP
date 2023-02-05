namespace AboutInheritance
{
    internal class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MainPhoneNumber { get; set; }
        private int[] OtherPhoneNumbers = new int[10];

        // Метод с произвольным количеством аргументов - params
        public Contact(string firstName, string lastName, int mainPhoneNumber, params int[] otherPhoneNumbers)
        {
            FirstName = firstName;
            LastName = lastName;
            MainPhoneNumber = mainPhoneNumber + 913000000;

            for (int i = 0; i < otherPhoneNumbers.Length; i++)
            {
                OtherPhoneNumbers[i] = otherPhoneNumbers[i];
            }
        }

        public Contact(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void Print()
        {
            if (MainPhoneNumber == 0)
            {
                Console.WriteLine($"{FirstName} {LastName}");
            }
            else
            {
                Console.Write($"{FirstName} {LastName}, тел. {MainPhoneNumber}");

                foreach (int e in OtherPhoneNumbers)
                {
                    if (e != 0)
                    {
                        Console.Write(" | " + e);
                    }
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine();
            }
        }

        // virtual - пометка, что функция виртуальная. В классе-потомке она может быть переопределена.
        public virtual string GetInitials()
        {
            return FirstName[0].ToString() + ". " + LastName;
        }
    }
}
