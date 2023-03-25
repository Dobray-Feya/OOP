using System.Text;

namespace Arkashova.ListTask
{
    public class SinglyLinkedList<T>
    {
        private ListItem<T> head;

        private int count = 0;

        public SinglyLinkedList(ListItem<T> head)
        {
            if (head is null)
            {
                throw new ArgumentNullException(nameof(head), "Невозможно создать список. В качестве головы спсика передано значение null.");
            }

            this.head = head;

            count = 1;
        }

        public int GetCount()
        {
            return count;
        }

        public T GetHeadData()
        {
            return head.Data;
        }

        public void InsertNewHead(ListItem<T> item)
        {
            //ListItem<T> oldHead = head;  head = item;  head.Next = oldHead;

            item.Next = head;
            head = item;

            count++;
        }

        public override string ToString()
        {
            if (count == 0)
            {
                return "";
            }

            StringBuilder stringBuilder = new StringBuilder();

            for (ListItem<T> p = head; p != null; p = p.Next)
            {
                stringBuilder.Append(p.Data.ToString())
                             .Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);

            return stringBuilder.ToString();
        }
    }
}
