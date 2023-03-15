namespace Arkashova.ListTask
{
    public class ListItem<T>
    {
        public T Data { get; set; }

        public ListItem<T>? Next { get; set; }

        public ListItem(T data, ListItem<T>? next)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "Невозможно создать элемент списка, т.к. в качестве данных передано значение null.");
            }

            Data = data;

            Next = next;
        }

        public ListItem(T data) : this(data, null) { }
    }
}
