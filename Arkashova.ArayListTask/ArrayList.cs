using System.Collections;
using System.Text;

namespace Arkashova.ArayListTask
{
    public class ArrayList<T> : IList<T>
    {
        private int count;

        private int modCount;

        private const int defaultCapacity = 4;

        private T[] items;

        public int Count
        {
            get { return count; }
        }

        /// <summary>
        ///     Gets or sets the total number of elements the internal data structure can hold without resizing.
        /// </summary>
        /// <returns>
        ///     Returns the number of elements that the list can contain before resizing is required.
        /// </returns>
        /// <exception>ArgumentOutOfRangeException</exception>
        public int Capacity
        {
            get
            {
                return items.Length;
            }

            set
            {
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Нельзя сделать вместимость списка равной 0.");
                }

                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"Нельзя сделать вместимость списка равной {value}, " +
                                                                         $"т.к. это меньше, чем текущее количество элементов в списке ({Count})");
                }

                Array.Resize(ref items, value);
            }
        }

        public bool IsReadOnly => throw new NotImplementedException(); // Пока не знаю, как реализовать

        public ArrayList()
        {
            count = 0;

            modCount = 0;

            items = new T[defaultCapacity];
        }

        public ArrayList(int capacity)
        {
            count = 0;

            modCount = 0;

            items = new T[capacity];
        }

        public T this[int index]
        {

            get
            {
                if (count == 0)
                {
                    throw new ArgumentException("Нельзя получить элемент списка. Список не содержит элементов.");
                }

                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException($" Нельзя получить элемент списка по индексу {index}. " +
                                                       $" Индекс элемента должен быть от 0 до {count - 1}.");
                }

                return items[index];
            }

            set
            {
                if (count == 0)
                {
                    throw new ArgumentException("Нельзя задать значение элементу списка. Список не содержит элементов.");
                }

                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException($" Нельзя задать элемент списка по индексу {index}. " +
                                                       $"Индекс элемента должен быть от 0 до {count - 1}.");
                }

                items[index] = value;

                modCount++;
            }
        }

        public void Add(T item)
        {
            if (count >= items.Length)
            {
                IncreaseCapacity();
            }

            items[count] = item;

            count++;

            modCount++;
        }

        private void IncreaseCapacity()
        {
            Array.Resize(ref items, items.Length * 2);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException($"Нельзя удалить элемент списка по индексу {index}. " +
                                                   $"Индекс элемента должен быть от 0 до {count - 1}.");
            }

            if (index < count - 1)
            {
                Array.Copy(items, index + 1, items, index, count - index - 1);
            }

#pragma warning disable CS8601 // Possible null reference assignment. // Пришлось отключить warning (и ниже в одном месте)
            items[count - 1] = default;  // Заметка для себя: default для ссылочных типов выдает null, а для value - типов – экземпляр структуры, созданный через конструктор без аргументов
#pragma warning restore CS8601 // Possible null reference assignment.

            count--;

            modCount++;
        }

        public bool Remove(T item)
        {
            int index = 0;

            while (index < count)
            {
                if (items[index] is null && item is null)
                {
                    RemoveAt(index);

                    return true;
                }

                if (items[index] is not null && items[index]!.Equals(item)) // Пришлось поставить !, чтобы не было warning'а (и ниже в трех подобных местах)
                {
                    RemoveAt(index);

                    return true;
                }

                index++;
            }

            modCount++;

            return false;
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                items[i] = default;
#pragma warning restore CS8601 // Possible null reference assignment.
            }

            count = 0;

            modCount++;
        }

        public void Insert(int index, T item)
        {
            if (Capacity == count)
            {
                IncreaseCapacity();
            }

            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException($"Нельзя вставить элемент списка по индексу {index}. " +
                                                   $"Индекс элемента должен быть от 0 до {count}.");
            }

            if (index < count)
            {
                Array.Copy(items, index, items, index + 1, count - index + 1);
            }

            items[index] = item;

            count++;

            modCount++;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Вставка списка в массив невозможна. Целевой массив равен null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Вставка списка в массив невозможна. Целевой массив пуст.",
                                           $"{nameof(array.Length)}");
            }

            if (arrayIndex + count > array.Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(array.Length)}, {nameof(Count)}, {nameof(arrayIndex)}",
                                                      $"Превышен размер маcсива {array.Length}. Список длины {count} не может быть вставлен в массив по индексу {arrayIndex}.");
            }

            for (int i = 0; i < count; i++)
            {
                array[i + arrayIndex] = items[i];
            }
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] is null && item is null)
                {
                    return true;
                }

                if (items[i] is not null && items[i]!.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] is null && item is null)
                {
                    return i;
                }

                if (items[i] is not null && items[i]!.Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            if (count == 0)
            {
                return "";
            }

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                stringBuilder.Append(this[i])
                             .Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Changes array capacity to elements in list count, if this count is less than 90 % of array capacity.
        /// </summary>
        public void TrimExcess()
        {
            if (count < 0.9 * Capacity)
            {
                Capacity = count;
            };
        }

        public IEnumerator<T> GetEnumerator()
        {
            int beginModCount = modCount;

            for (int i = 0; i < count; i++)
            {
                if (modCount != beginModCount)
                {
                    throw new InvalidOperationException("Проход итератором по списку не возможен, потому что с момента начала обхода список был изменен.");
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

