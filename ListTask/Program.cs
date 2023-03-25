namespace Arkashova.ListTask
{
    internal class Program
    {
        static void Main(string[] args)
        {


            ListItem<int> item1 = new ListItem<int>(100);
            SinglyLinkedList<int> integerList = new SinglyLinkedList<int>(item1);

            ListItem<int> item2 = new ListItem<int>(99);
            integerList.InsertNewHead(item2);

            ListItem<int> item3 = new ListItem<int>(98);
            integerList.InsertNewHead(item3);

            Console.WriteLine(integerList.ToString());

            Console.WriteLine("GetCount -> " + integerList.GetCount());

            Console.WriteLine("GetHeadData -> " + integerList.GetHeadData());
        }
    }
}