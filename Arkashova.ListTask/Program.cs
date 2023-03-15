namespace Arkashova.ListTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListItem<int> item1 = new ListItem<int>(100);

            SinglyLinkedList<int> integerList = new SinglyLinkedList<int>(item1);

            integerList.InsertHead(99);
            integerList.InsertHead(98);
            integerList.InsertHead(97);

            Console.WriteLine(integerList);
            Console.WriteLine("GetCount -> " + integerList.GetCount());
            Console.WriteLine("GetHeadData -> " + integerList.GetHeadData());

            Console.WriteLine("list[0] = " + integerList[0]);
            Console.WriteLine("list[1] = " + integerList[1]);
            Console.WriteLine("list[2] = " + integerList[2]);
            Console.WriteLine("list[3] = " + integerList[3]);
            Console.WriteLine();

            Console.WriteLine("list[0] = 1, list[1] = 2, list[2] = 3");
            integerList[0] = 1;
            integerList[1] = 2;
            integerList[2] = 3;
            Console.WriteLine(integerList);

            Console.WriteLine("SetData(0, 10) => старое значение = " + integerList.SetData(0, 10) + ", новое значение = " + integerList.GetData(0));
            Console.WriteLine(integerList + "; Count = " + integerList.GetCount());
            Console.WriteLine();

            int insertedValue = 1;
            integerList.Insert(0, insertedValue);
            Console.WriteLine($"Insert(0, {insertedValue}) => {integerList}; Count = {integerList.GetCount()}");
            integerList.Insert(4, insertedValue);
            Console.WriteLine($"Insert(4, {insertedValue}) => {integerList}; Count = {integerList.GetCount()}");
            integerList.Insert(6, insertedValue);
            Console.WriteLine($"Insert(6, {insertedValue}) => {integerList}; Count = {integerList.GetCount()}");
            Console.WriteLine();

            Console.WriteLine("RemoveAt(1) => удаленное значение = " + integerList.RemoveAt(1));
            Console.WriteLine(integerList + "; Count = " + integerList.GetCount());
            Console.WriteLine("RemoveAt(0) => удаленное значение = " + integerList.RemoveAt(0));
            Console.WriteLine(integerList + "; Count = " + integerList.GetCount());
            Console.WriteLine("RemoveAt(4) => удаленное значение = " + integerList.RemoveAt(4));
            Console.WriteLine(integerList + "; Count = " + integerList.GetCount());
            Console.WriteLine();

            Console.WriteLine("RemoveHead() => " + integerList.RemoveHead());
            Console.WriteLine(integerList + "; Count = " + integerList.GetCount());
            Console.WriteLine("Remove(1) => " + integerList.Remove(1));
            Console.WriteLine(integerList + "; Count = " + integerList.GetCount());
            Console.WriteLine("Remove(2) => " + integerList.Remove(2));
            Console.WriteLine(integerList + "; Count = " + integerList.GetCount());
            Console.WriteLine();

            integerList.Insert(0, 1);
            integerList.Insert(1, 2);
            Console.WriteLine(integerList);
            integerList.Reverse();
            Console.WriteLine("Reverse() => " + integerList + "; Count = " + integerList.GetCount());
            Console.WriteLine();

            SinglyLinkedList<int> integerList2 = integerList.GetCopy();
            Console.WriteLine("GetCopy() => " + integerList2 + "; Count = " + integerList2.GetCount());
        }
    }
}