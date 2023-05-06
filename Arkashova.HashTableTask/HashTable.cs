using System.Collections;
using System.Text;

namespace Arkashova.HashTableTask
{
    public class HashTable<T> : ICollection<T>
    {
        private const int DefaultSize = 20;

        private readonly List<T>?[] lists;

        private int modCount;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public HashTable(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), $"Невозможно создать хэш-таблицу размера {size}. Размер должен быть больше нуля.");
            }

            lists = new List<T>[size];
        }

        public HashTable()
        {
            lists = new List<T>[DefaultSize];
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (lists[index] is null)
            {
                lists[index] = new List<T>();
            }

            lists[index]!.Add(item);

            Count++;
            modCount++;
        }

        private int GetIndex(T item)
        {
            return item is null ? 0 : Math.Abs(item.GetHashCode() % lists.Length);
        }

        public bool Remove(T item)
        {
            int index = GetIndex(item);

            if (lists[index] is not null && lists[index]!.Remove(item))
            {
                Count--;
                modCount++;

                return true;
            }

            return false;
        }

        public void Clear()
        {
            if (Count == 0)
            {
                return;
            }

            Array.Clear(lists);

            Count = 0;
            modCount++;
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

            return (lists[index] is not null) && lists[index]!.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Вставка хэш-таблицы в массив невозможна. Целевой массив равен null.");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(arrayIndex)}", $"Вставка хэш-таблицы в массив по индексу {arrayIndex} невозможна. " +
                                                      "Индекс должен быть больше или равен 0.");
            }

            if (arrayIndex + Count > array.Length)
            {
                throw new ArgumentException($"Превышен размер массива {array.Length}. Хэш-таблица с числом элементов {Count} не может быть вставлена в массив по индексу {arrayIndex}.",
                                            $"{nameof(array.Length)}, {nameof(Count)}, {nameof(arrayIndex)}");
            }

            int i = arrayIndex;

            foreach (List<T>? list in lists)
            {
                if (list is not null)
                {
                    list.CopyTo(array, i);

                    i += list.Count;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (List<T>? list in lists)
            {
                if (list is null)
                {
                    stringBuilder.Append("null");
                    stringBuilder.Append(Environment.NewLine);

                    continue;
                }

                if (list.Count == 0)
                {
                    stringBuilder.Append("[]");
                    stringBuilder.Append(Environment.NewLine);

                    continue;
                }

                stringBuilder.Append('[');

                foreach (T? item in list)
                {
                    if (item is null)
                    {
                        stringBuilder.Append("null; ");
                    }
                    else
                    {
                        stringBuilder.Append(item).Append("; ");
                    }
                }

                stringBuilder.Remove(stringBuilder.Length - 2, 2);

                stringBuilder.Append(']');
                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCount = modCount;

            foreach (List<T>? list in lists)
            {
                if (list is not null)
                {
                    foreach (T item in list)
                    {
                        if (modCount != initialModCount)
                        {
                            throw new InvalidOperationException("Проход итератором по хэш-таблице невозможен, потому что с момента начала обхода хэш-таблица была изменена.");
                        }

                        yield return item;
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
