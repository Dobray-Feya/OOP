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
            head = null;
        }

        public T? this[int index]
        {
            get
            {
                CheckIndex(index);

                return Skip(index)!.Data;
            }

            set
            {
                CheckIndex(index);

                ListItem<T>? desiredItem = Skip(index);

                T? oldData = desiredItem!.Data;

                desiredItem.Data = value;
            }
        }

        public T? GetFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Нельзя получить первый элемент списка, т.к. список пуст.");
            }

            return head!.Data;
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

            ListItem<T>? previousItem = Skip(index - 1);
            ListItem<T>? nextItem = previousItem!.Next;
            ListItem<T> insertedItem = new ListItem<T>(data);

            previousItem.Next = insertedItem;
            insertedItem.Next = nextItem;

            Count++;
        }

        public void InsertFirst(T? data)
        {
            head = new ListItem<T>(data, head);

            Count++;
        }

        private ListItem<T>? Skip(int index)
        {
            int i = 0;

            ListItem<T>? item;

            for (item = head; item != null; item = item.Next)
            {
                if (i == index)
                {
                    break;
                }

                i++;
            }

            return item;
        }

        public T? RemoveAt(int index)
        {
            CheckIndex(index);

            T? removedData = head!.Data;

            if (index == 0)
            {
                head = head!.Next;

                Count--;

                return removedData;
            }

            ListItem<T>? previousItem = Skip(index - 1);
            ListItem<T>? removedItem = previousItem!.Next;

            previousItem.Next = removedItem!.Next;

            Count--;

            return removedItem.Data;
        }

        private void CheckIndex(int index)
        {
            if (Count == 0)
            {
                throw new NullReferenceException("Невозможно получить доступ к элементу списка по индексу. Список пуст.");
            }

            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException($"Невозможно получить доступ к элементу списка по индексу {index}. " +
                                                   $"Индекс элемента должен быть от 0 до {Count - 1}.");
            }
        }

        public T? RemoveFirst()
        {
            return RemoveAt(0);
        }

        public bool Remove(T data)
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Невозможно удалить элемент списка. Список пуст.");
            }

            if (Equals(head!.Data, data))
            {
                head = head.Next;

                Count--;

                return true;
            }

            for (ListItem<T>? item = head!.Next, previousItem = head; item != null; previousItem = item, item = item.Next)
            {
                if (Equals(item.Data, data))
                {
                    previousItem!.Next = item.Next;

                    Count--;

                    return true;
                }
            }

            return false;
        }

        public void Reverse()
        {
            if (Count == 0 || Count == 1)
            {
                return;
            }

            if (Count == 2)
            {
                ListItem<T>? oldHead = head;

                head = head!.Next;
                oldHead!.Next = null;
                head!.Next = oldHead;

                return;
            }

            ListItem<T>? previousItem = head;
            ListItem<T>? item = head!.Next;
            ListItem<T>? nextItem = item!.Next;

            head.Next = null;

            for (; nextItem != null; previousItem = item, item = nextItem, nextItem = nextItem.Next)
            {
                item.Next = previousItem;
            }

            item.Next = previousItem;

            head = item;
        }

        public SinglyLinkedList<T> GetCopy()
        {
            if (Count == 0)
            {
                return new SinglyLinkedList<T>();
            }

            SinglyLinkedList<T> copyList = new SinglyLinkedList<T>(head!.Data);

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
                stringBuilder.Append(item.Data)
                             .Append("; ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append(']');

            return stringBuilder.ToString();
        }
    }
}