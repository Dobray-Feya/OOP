namespace Arkashova.ListTask
{
    internal class ListItem<T>
    {
        public T? Data { get; set; }

        public ListItem<T>? Next { get; set; }

        public ListItem(T? data, ListItem<T>? next)
        {
            Data = data;
            Next = next;
        }

        public ListItem(T? data)
        {
            Data = data;
        }
    }
}
