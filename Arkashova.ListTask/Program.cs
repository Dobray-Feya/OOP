namespace Arkashova.ListTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> integersList1 = new SinglyLinkedList<int>(100);
            integersList1.InsertFirst(97);
            integersList1.InsertFirst(96);

            Console.WriteLine(integersList1);
            Console.WriteLine("Count -> " + integersList1.Count);
            Console.WriteLine("GetFirst -> " + integersList1.GetFirst());

            Console.WriteLine("list[0] = " + integersList1[0]);
            Console.WriteLine("list[1] = " + integersList1[1]);
            Console.WriteLine("list[2] = " + integersList1[2]);
            Console.WriteLine();

            Console.WriteLine("list[0] = 10, list[1] = 2, list[2] = 3");
            integersList1[0] = 10;
            integersList1[1] = 2;
            integersList1[2] = 3;
            Console.WriteLine(integersList1);

            integersList1.Insert(0, 6);
            Console.WriteLine($"Insert(0, 6) => {integersList1}; Count = {integersList1.Count}");
            integersList1.Insert(3, 1);
            Console.WriteLine($"Insert(3, 1) => {integersList1}; Count = {integersList1.Count}");
            integersList1.Insert(5, 8);
            Console.WriteLine($"Insert(5, 8) => {integersList1}; Count = {integersList1.Count}");
            Console.WriteLine();

            Console.WriteLine("RemoveAt(1) => удаленное значение = " + integersList1.RemoveAt(1) + " => " + integersList1 + "; Count = " + integersList1.Count);
            Console.WriteLine("RemoveAt(0) => удаленное значение = " + integersList1.RemoveAt(0) + " => " + integersList1 + "; Count = " + integersList1.Count);
            Console.WriteLine("RemoveAt(3) => удаленное значение = " + integersList1.RemoveAt(3) + " => " + integersList1 + "; Count = " + integersList1.Count);
            Console.WriteLine();

            Console.WriteLine("RemoveFirst() => удаленное значение = " + integersList1.RemoveFirst() + " => " + integersList1 + "; Count = " + integersList1.Count);
            Console.WriteLine();

            integersList1.Reverse();
            Console.WriteLine("Reverse() => " + integersList1 + "; Count = " + integersList1.Count);
            Console.WriteLine();

            integersList1.Insert(1, 2);
            integersList1.Insert(3, 4);
            Console.WriteLine(integersList1);
            integersList1.Reverse();
            Console.WriteLine("Reverse() => " + integersList1 + "; Count = " + integersList1.Count);
            Console.WriteLine();

            SinglyLinkedList<int> integersList12 = integersList1.GetCopy();
            Console.WriteLine("GetCopy() => " + integersList12 + "; Count = " + integersList12.Count);
            Console.WriteLine("Копия списка равна списку? " + Equals(integersList1, integersList12));
            Console.WriteLine();

            Console.WriteLine("Пустой список строк:");
            SinglyLinkedList<string> stringsList1 = new SinglyLinkedList<string>();
            Console.WriteLine(stringsList1 + "; Count = " + stringsList1.Count);
            SinglyLinkedList<string> stringsList2 = stringsList1.GetCopy();
            Console.WriteLine("GetCopy() => " + stringsList2 + "; Count = " + stringsList2.Count);
            stringsList2.Reverse();
            Console.WriteLine("Reverse() => " + stringsList2 + "; Count = " + stringsList2.Count);
            Console.WriteLine();

            stringsList1.InsertFirst("one");
            Console.WriteLine("InsertFirst (\"one\") => " + stringsList1 + "; Count = " + stringsList1.Count);
            stringsList1.Insert(1, "two");
            Console.WriteLine("Insert(1, \"two\") => " + stringsList1 + "; Count = " + stringsList1.Count);
            stringsList1.Insert(2, "three");
            Console.WriteLine("Insert(2, \"three\") => " + stringsList1 + "; Count = " + stringsList1.Count);
            stringsList1.Insert(3, "three");
            Console.WriteLine("Insert(3, \"three\") => " + stringsList1 + "; Count = " + stringsList1.Count);
            stringsList1.Insert(3, null);
            Console.WriteLine("Insert(3, null) => " + stringsList1 + "; Count = " + stringsList1.Count);
            Console.WriteLine();

            Console.WriteLine("Remove(\"two\") => " + stringsList1.Remove("two") + " => " + stringsList1 + "; Count = " + stringsList1.Count);
            Console.WriteLine("Remove(\"one\") => " + stringsList1.Remove("one") + " => " + stringsList1 + "; Count = " + stringsList1.Count);
            Console.WriteLine("Remove(\"four\") => " + stringsList1.Remove("four") + " => " + stringsList1 + "; Count = " + stringsList1.Count);
            Console.WriteLine("Remove(null) => " + stringsList1.Remove(null) + " => " + stringsList1 + "; Count = " + stringsList1.Count);
            Console.WriteLine("Remove(\"three\") => " + stringsList1.Remove("three") + " => " + stringsList1 + "; Count = " + stringsList1.Count);
        }
    }
}