namespace Arkashova.ListTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> integerList = new SinglyLinkedList<int>(100);
            integerList.InsertFirst(97);
            integerList.InsertFirst(96);

            Console.WriteLine(integerList);
            Console.WriteLine("Count -> " + integerList.Count);
            Console.WriteLine("GetFirst -> " + integerList.GetFirst());

            Console.WriteLine("list[0] = " + integerList[0]);
            Console.WriteLine("list[1] = " + integerList[1]);
            Console.WriteLine("list[2] = " + integerList[2]);
            Console.WriteLine();

            Console.WriteLine("list[0] = 10, list[1] = 2, list[2] = 3");
            integerList[0] = 10;
            integerList[1] = 2;
            integerList[2] = 3;
            Console.WriteLine(integerList);

            integerList.Insert(0, 6);
            Console.WriteLine($"Insert(0, 6) => {integerList}; Count = {integerList.Count}");
            integerList.Insert(3, 1);
            Console.WriteLine($"Insert(3, 1) => {integerList}; Count = {integerList.Count}");
            integerList.Insert(5, 8);
            Console.WriteLine($"Insert(5, 8) => {integerList}; Count = {integerList.Count}");
            Console.WriteLine();

            Console.WriteLine("RemoveAt(1) => удаленное значение = " + integerList.RemoveAt(1) + " => " + integerList + "; Count = " + integerList.Count);
            Console.WriteLine("RemoveAt(0) => удаленное значение = " + integerList.RemoveAt(0) + " => " + integerList + "; Count = " + integerList.Count);
            Console.WriteLine("RemoveAt(3) => удаленное значение = " + integerList.RemoveAt(3) + " => " + integerList + "; Count = " + integerList.Count);
            Console.WriteLine();

            Console.WriteLine("RemoveFirst() => удаленное значение = " + integerList.RemoveFirst() + " => " + integerList + "; Count = " + integerList.Count);
            Console.WriteLine();

            integerList.Reverse();
            Console.WriteLine("Reverse() => " + integerList + "; Count = " + integerList.Count);
            Console.WriteLine();

            integerList.Insert(1, 2);
            integerList.Insert(3, 4);
            Console.WriteLine(integerList);
            integerList.Reverse();
            Console.WriteLine("Reverse() => " + integerList + "; Count = " + integerList.Count);
            Console.WriteLine();

            SinglyLinkedList<int> integerList2 = integerList.GetCopy();
            Console.WriteLine("GetCopy() => " + integerList2 + "; Count = " + integerList2.Count);
            Console.WriteLine("Копия списка равна списку? " + Equals(integerList, integerList2));
            Console.WriteLine();

            Console.WriteLine("Пустой список строк:");
            SinglyLinkedList<string> linesList = new SinglyLinkedList<string>();
            Console.WriteLine(linesList + "; Count = " + linesList.Count);
            SinglyLinkedList<string> linesList2 = linesList.GetCopy();
            Console.WriteLine("GetCopy() => " + linesList2 + "; Count = " + linesList2.Count);
            linesList2.Reverse();
            Console.WriteLine("Reverse() => " + linesList2 + "; Count = " + linesList2.Count);
            Console.WriteLine();

            linesList.InsertFirst("one");
            Console.WriteLine("InsertFirst (\"one\") => " + linesList + "; Count = " + linesList.Count);
            linesList.Insert(1, "two");
            Console.WriteLine("Insert(1, \"two\") => " + linesList + "; Count = " + linesList.Count);
            linesList.Insert(2, "three");
            Console.WriteLine("Insert(2, \"three\") => " + linesList + "; Count = " + linesList.Count);
            linesList.Insert(3, "three");
            Console.WriteLine("Insert(3, \"three\") => " + linesList + "; Count = " + linesList.Count);
            linesList.Insert(3, null);
            Console.WriteLine("Insert(3, null) => " + linesList + "; Count = " + linesList.Count);
            Console.WriteLine();

            Console.WriteLine("Remove(\"two\") => " + linesList.Remove("two") + " => " + linesList + "; Count = " + linesList.Count);
            Console.WriteLine("Remove(\"one\") => " + linesList.Remove("one") + " => " + linesList + "; Count = " + linesList.Count);
            Console.WriteLine("Remove(\"four\") => " + linesList.Remove("four") + " => " + linesList + "; Count = " + linesList.Count);
            Console.WriteLine("Remove(null) => " + linesList.Remove(null) + " => " + linesList + "; Count = " + linesList.Count);
            Console.WriteLine("Remove(\"three\") => " + linesList.Remove("three") + " => " + linesList + "; Count = " + linesList.Count);
        }
    }
}