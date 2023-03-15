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
                throw new ArgumentNullException(nameof(head), "Невозможно создать список. В качестве головы списка передано значение null.");
            }

            this.head = head;

            count = 1;
        }

        public T this[int index]
        {
            get
            {
                return GetData(index);
            }

            set
            {
                SetData(index, value);
            }
        }

        public int GetCount()
        {
            return count;
        }

        public T GetHeadData()
        {
            return head.Data;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException($"Невозможно вставить элемент в список по индексу {index}. " +
                                                   $"Индекс элемента должен быть от 0 до {count}.");
            }

            if (index == 0)
            {
                InsertHead(data);

                return;
            }

            if (index == count)
            {
                InsertTail(data);

                return;
            }

            InsertMiddle(index, data);
        }

        public void InsertHead(T newHeadData)
        {
            ListItem<T> newHead = new ListItem<T>(newHeadData);

            newHead.Next = head;

            head = newHead;

            count++;
        }

        public void InsertTail(T data)
        {
            ListItem<T> p = head;

            while (p.Next != null)
            {
                p = p.Next;
            }

            ListItem<T> insertedItem = new ListItem<T>(data);

            p.Next = insertedItem;

            count++;
        }

        private void InsertMiddle(int index, T data)  // Из Insert передается index: 0 < index < count
        {
            int curentIndex = 1;

            for (ListItem<T>? p = head.Next, prev = head; p != null; prev = p, p = p.Next)
            {
                if (curentIndex == index)
                {
                    ListItem<T> insertedItem = new ListItem<T>(data);

                    prev.Next = insertedItem;

                    insertedItem.Next = p;

                    count++;

                    break;
                }

                curentIndex++;
            }
        }

        public T GetData(int index)
        {
            ThrowIfIndexOutOfRange(this, index);

            int curentIndex = 0;

            T desiredData = head.Data;

            for (ListItem<T>? p = head; p != null; p = p.Next)
            {
                if (curentIndex == index)
                {
                    desiredData = p.Data;

                    break;
                }

                curentIndex++;
            }

            return desiredData;
        }

        public T SetData(int index, T value)
        {
            ThrowIfIndexOutOfRange(this, index);

            int curentIndex = 0;

            T oldValue = head.Data;

            for (ListItem<T>? p = head; p != null; p = p.Next)
            {
                if (curentIndex == index)
                {
                    oldValue = p.Data;

                    p.Data = value;

                    break;
                }

                curentIndex++;
            }

            return oldValue;
        }

        public T RemoveAt(int index)
        {
            ThrowIfIndexOutOfRange(this, index);
            TrowIfDeleteItemWhenCountIsOne(this);

            T removedItemValue = head.Data;

            if (index == 0)
            {
                head = head.Next!;

                count--;

                return removedItemValue;
            }

            int curentIndex = 1;

            for (ListItem<T>? p = head.Next, prev = head; p != null; prev = p, p = p.Next)
            {
                if (curentIndex == index)
                {
                    removedItemValue = p.Data;

                    prev.Next = p.Next;

                    count--;

                    break;
                }

                curentIndex++;
            }

            return removedItemValue;
        }

        private static void ThrowIfIndexOutOfRange(SinglyLinkedList<T> list, int index)
        {
            if (index < 0 || index >= list.count)
            {
                throw new IndexOutOfRangeException($"Невозможно получить доступ к элементу списка по индексу {index}. " +
                                                   $"Индекс элемента должен быть от 0 до {list.count - 1}.");
            }
        }

        private static void TrowIfDeleteItemWhenCountIsOne(SinglyLinkedList<T> list)
        {
            if (list.count == 1)
            {
                throw new ArgumentException(" Нельзя удалить элемент из списка. Список состоит всего из одного элемента.", nameof(count));
            }
        }

        public T RemoveHead()
        {
            TrowIfDeleteItemWhenCountIsOne(this);

            T removedItemValue = head.Data;

            head = head.Next!;

            count--;

            return removedItemValue;
        }

        public bool Remove(T data)
        {
            TrowIfDeleteItemWhenCountIsOne(this);

            if (head.Data!.Equals(data))
            {
                head = head.Next!;

                count--;

                return true;
            }

            for (ListItem<T>? p = head.Next, prev = head; p != null; prev = p, p = p.Next)
            {
                if (p.Data!.Equals(data))
                {
                    prev.Next = p.Next;

                    count--;

                    return true;
                }
            }

            return false;
        }

        public void Reverse()
        {
            ListItem<T> reversedListHead = new ListItem<T>(head.Data);

            SinglyLinkedList<T> reversedList = new SinglyLinkedList<T>(reversedListHead);

            for (ListItem<T>? p = head.Next; p != null; p = p.Next)
            {
                reversedList.InsertHead(p.Data);
            }

            head = reversedList.head;
        }

        public SinglyLinkedList<T> GetCopy()
        {
            ListItem<T> copyListHead = new ListItem<T>(head.Data);

            ListItem<T> previousCopyListItem = copyListHead;

            for (ListItem<T>? p = head.Next; p != null; p = p.Next)
            {
                ListItem<T> copyListItem = new ListItem<T>(p.Data);
                previousCopyListItem.Next = copyListItem;
                previousCopyListItem = copyListItem;
            }

            SinglyLinkedList<T> copyList = new SinglyLinkedList<T>(copyListHead);

            copyList.count = count;

            return copyList;
        }

        public override string ToString()
        {
            if (count == 0)
            {
                return "";
            }

            StringBuilder stringBuilder = new StringBuilder();

            for (ListItem<T>? p = head; p != null; p = p.Next)
            {
                stringBuilder.Append(p.Data)
                             .Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);

            return stringBuilder.ToString();
        }
    }
}