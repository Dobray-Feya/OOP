using System.Collections;
using System.Text;
using Arkashova.ArayListTask;

namespace Arkashova.HashTableTask
{
    public class HashTable<T> : ICollection<T>
    {
        private ArrayList<T>[] lists; //Заметка для себя: здесь можно любой список, например, стандартный List, но я взяла свой ArrayList 

        public int Count { get; private set; }

        int modCount;

        public HashTable(int size)
        {
            lists = new ArrayList<T>[size];
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            int index = GetItemIndex(item);

            if (lists[index] is null)
            {
                lists[index] = new ArrayList<T>();
            }

            lists[index].Add(item);

            Count++;
            modCount++;
        }

        // Считаю, что в хэш-таблице могут быть элементы null и для них зарезервирован 0-й элемент массива.
        private int GetItemIndex(T item)
        {
            return item is null ? 0 : 1 + Math.Abs(item.GetHashCode() % (lists.Length - 1));
        }

        public bool Remove(T item)
        {
            bool IsRemoved = lists[GetItemIndex(item)].Remove(item);

            if (IsRemoved)
            {
                Count--;
                modCount++;
            }

            return IsRemoved;
        }

        public void Clear()
        {
            if (lists.Length == 0)
            {
                return;
            }

            Array.Clear(lists, 0, lists.Length);

            Count = 0;
            modCount++;
        }

        public bool Contains(T item)
        {
            return lists[GetItemIndex(item)].Contains(item);
        }

        public void CopyTo(T?[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Вставка хэш-таблицы в массив невозможна. Целевой массив равен null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(array.Length)}, {nameof(Count)}, {nameof(arrayIndex)}",
                                                      "Вставка хэш-таблицы в массив невозможна. Целевой массив пуст.");
            }

            if (arrayIndex + Count > array.Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(array.Length)}, {nameof(Count)}, {nameof(arrayIndex)}",
                                                      $"Превышен размер маcсива {array.Length}. Хэш-таблица размера {Count} " +
                                                      $"не может быть вставлена в массив по индексу {arrayIndex}.");
            }

            int insertedItemsCount = arrayIndex;

            foreach (ArrayList<T> list in lists)
            {
                if (list is not null)
                {
                    list.CopyTo(array, insertedItemsCount);

                    insertedItemsCount += list.Count;
                }
            }
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "[]";
            }

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < lists.Length; i++)
            {
                stringBuilder.Append("[");

                if (lists[i] is not null)
                {
                    for (int j = 0; j < lists[i].Count; j++)
                    {
                        if (lists[i][j] is null)
                        {
                            stringBuilder.Append("null");
                        }
                        else
                        {
                            stringBuilder.Append(lists[i][j]!.ToString());
                        }

                        stringBuilder.Append("; ");
                    }

                    stringBuilder.Remove(stringBuilder.Length - 2, 2);
                }

                stringBuilder.Append("]\n\r");
            }

            return stringBuilder.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCount = modCount;

            for (int i = 0; i < lists.Length; i++)
            {
                ArrayList<T> currentList = lists[i];

                if (currentList is not null)
                {
                    for (int j = 0; j < currentList.Count; j++)
                    {
                        if (modCount != initialModCount)
                        {
                            throw new InvalidOperationException("Проход итератором по хэш-таблице невозможен, потому что с момента начала обхода хэш-таблица была изменена.");
                        }

                        yield return currentList[j];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
