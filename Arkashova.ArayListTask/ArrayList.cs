using System.Collections;
using System.Text;

namespace Arkashova.ArayListTask
{
    public class ArrayList<T> : IList<T>
    {
        private const int DefaultCapacity = 4;

        private int modCount;

        private T?[] items;

        public int Count { get; private set; }

        /// <summary>
        ///     Gets or sets the total number of elements the internal data structure can hold without resizing.
        /// </summary>
        /// <returns>
        ///     Returns the number of elements that the list can contain before resizing is required.
        /// </returns>
        /// <exception>ArgumentOutOfRangeException</exception>
        public int Capacity
        {
            get => items.Length;

            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"Нельзя сделать вместимость списка равной {value}, " +
                                                                         $"т.к. это меньше, чем текущее количество элементов в списке ({Count})");
                }

                Array.Resize(ref items, value);
            }
        }

        public bool IsReadOnly => false;

        public ArrayList()
        {
            items = new T[DefaultCapacity];
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), $"Нельзя сделать вместимость списка равной {capacity}. " +
                                                                        "Вместимость списка должна быть больше или равна 0.");
            }

            items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);

                return items[index]!;
            }

            set
            {
                CheckIndex(index);

                items[index] = value;

                modCount++;
            }
        }

        private void CheckIndex(int index)
        {
            if (Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Нельзя получить элемент списка. Список не содержит элементов.");
            }

            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Нельзя получить элемент списка по индексу {index}. " +
                                                                     $"Индекс элемента должен быть от 0 до {Count - 1}.");
            }
        }

        public void Add(T? item)
        {
            Insert(Count, item);
        }

        public void Insert(int index, T? item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Нельзя вставить элемент списка по индексу {index}. " +
                                                                     $"Индекс элемента должен быть от 0 до {Count}.");
            }

            if (Capacity == Count)
            {
                IncreaseCapacity();
            }

            if (index < Count)
            {
                Array.Copy(items, index, items, index + 1, Count - index);
            }

            items[index] = item;

            Count++;
            modCount++;
        }

        private void IncreaseCapacity()
        {
            if (Capacity == 0)
            {
                Capacity = DefaultCapacity;
            }
            else
            {
                Capacity = 2 * Capacity;
            }
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            if (index < Count - 1)
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
            }

            items[Count - 1] = default;  // Заметка для себя: default для ссылочных типов выдает null, а для value - типов – экземпляр структуры, созданный через конструктор без аргументов

            Count--;
            modCount++;
        }

        public bool Remove(T? item)
        {
            int index = IndexOf(item);

            if (index != -1)
            {
                RemoveAt(index);

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

            Array.Clear(items, 0, Count);

            Count = 0;
            modCount++;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Вставка списка в массив невозможна. Целевой массив равен null.");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(arrayIndex)}", $"Вставка списка в массив по индексу {arrayIndex} невозможна. " +
                                                      "Индекс должен быть больше или равен 0.");
            }

            if (arrayIndex + Count > array.Length)
            {
                throw new ArgumentException($"Превышен размер массива {array.Length}. Список длины {Count} не может быть вставлен в массив по индексу {arrayIndex}.",
                                            $"{nameof(arrayIndex)},  {nameof(Count)}, {nameof(array.Length)}");
            }

            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public bool Contains(T? item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T? item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "[]";
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('[');

            foreach (T? item in this)
            {
                if (item is null)
                {
                    stringBuilder.Append("{null}");
                }
                else
                {
                    stringBuilder.Append(item);
                }

                stringBuilder.Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append(']');

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Changes array capacity to elements in list Count, if this Count is less than 90 % of array capacity.
        /// </summary>
        public void TrimExcess()
        {
            if (Count < 0.9 * Capacity)
            {
                Capacity = Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCount = modCount;

            for (int i = 0; i < Count; i++)
            {
                if (modCount != initialModCount)
                {
                    throw new InvalidOperationException("Проход итератором по списку невозможен, потому что с момента начала обхода список был изменен.");
                }

                yield return items[i]!;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
