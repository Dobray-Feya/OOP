using System.Text;

namespace Arkashova.ListTask
{
    public class SinglyLinkedList<T>
    {
        private ListItem<T>? head;

        public int Count { get; private set; }

        public SinglyLinkedList(T? data)
        {
            head = new ListItem<T>(data);

            Count = 1;
        }

        public SinglyLinkedList()
        {
        }

        public T? this[int index]
        {
            get
            {
                CheckIndex(index);

                return GetItem(index).Data;
            }

            set
            {
                CheckIndex(index);

                ListItem<T> desiredItem = GetItem(index);

                desiredItem.Data = value;
            }
        }

        private void CheckIndex(int index)
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException($"Невозможно получить доступ к элементу списка по индексу {index}. Список пуст.");
            }

            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException($"Невозможно получить доступ к элементу списка по индексу {index}. " +
                                                   $"Индекс элемента должен быть от 0 до {Count - 1}.");
            }
        }

        public T? GetFirst()
        {
            if (head is null)
            {
                throw new InvalidOperationException("Нельзя получить первый элемент списка, т.к. список пуст.");
            }

            return head.Data;
        }

        public void Insert(int index, T? data)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException($"Невозможно вставить элемент в список по индексу {index}. " +
                                                   $"Индекс элемента должен быть от 0 до {Count}.");
            }

            if (index == 0)
            {
                InsertFirst(data);

                return;
            }

            ListItem<T> previousItem = GetItem(index - 1);
            previousItem.Next = new ListItem<T>(data, previousItem.Next);

            Count++;
        }

        public void InsertFirst(T? data)
        {
            head = new ListItem<T>(data, head);

            Count++;
        }

        private ListItem<T> GetItem(int index) // Считаю, что в этот метод передан индекс, уже проверенный на корректность 
        {
            ListItem<T> item = head!;

            for (int i = 0; i < index; i++)
            {
                item = item.Next!;
            }

            return item;
        }

        public T? RemoveAt(int index)
        {
            CheckIndex(index);

            if (index == 0)
            {
                return RemoveFirst();
            }

            ListItem<T> previousItem = GetItem(index - 1);
            ListItem<T> removedItem = previousItem.Next!;

            previousItem.Next = removedItem.Next;

            Count--;

            return removedItem.Data;
        }

        public T? RemoveFirst()
        {
            if (head is null)
            {
                throw new InvalidOperationException("Невозможно удалить первый элемент списка. Список пуст.");
            }

            T? removedData = head.Data;

            head = head.Next;

            Count--;

            return removedData;

        }

        public bool Remove(T? data)
        {
            if (head is null)
            {
                return false;
            }

            if (Equals(head.Data, data))
            {
                head = head.Next;

                Count--;

                return true;
            }

            for (ListItem<T>? item = head.Next, previousItem = head; item != null; previousItem = item, item = item.Next)
            {
                if (Equals(item.Data, data))
                {
                    previousItem.Next = item.Next;

                    Count--;

                    return true;
                }
            }

            return false;
        }

        public void Reverse()
        {
            if (Count <= 1)
            {
                return;
            }

            ListItem<T> previousItem = head!;
            ListItem<T> item = head!.Next!;
            ListItem<T>? nextItem = item.Next;

            head.Next = null;

            while (nextItem != null)
            {
                item.Next = previousItem;

                previousItem = item;
                item = nextItem;
                nextItem = nextItem.Next;
            }

            item.Next = previousItem;

            head = item;
        }

        public SinglyLinkedList<T> GetCopy()
        {
            if (head is null)
            {
                return new SinglyLinkedList<T>();
            }

            SinglyLinkedList<T> copyList = new SinglyLinkedList<T>(head.Data);

            ListItem<T> previousCopyListItem = copyList.head!;

            for (ListItem<T>? item = head.Next; item != null; item = item.Next)
            {
                ListItem<T> copyListItem = new ListItem<T>(item.Data);
                previousCopyListItem.Next = copyListItem;
                previousCopyListItem = copyListItem;
            }

            copyList.Count = Count;

            return copyList;
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "[]";
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append('[');

            for (ListItem<T>? item = head; item != null; item = item.Next)
            {
                if (item.Data is null)
                {
                    stringBuilder.Append("null, ");
                }
                else
                {
                    stringBuilder.Append(item.Data).Append(", ");
                }
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append(']');

            return stringBuilder.ToString();
        }
    }
}