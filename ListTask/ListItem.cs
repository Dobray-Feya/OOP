namespace Arkashova.ListTask
{
    public class ListItem<T>
    {
        //private T data;

        //private ListItem<T> next;  //'?" del?

        public T Data { get; set; }

        public ListItem<T>? Next { get; set; }

        public ListItem(T data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "В элемент списка в качестве данных передано значение null.");
            }

            Data = data;

            //Next = null;
        }

        public ListItem(T data, ListItem<T> next)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "В элемент списка в качестве данных передано значение null.");
            }

            Data = data;

            Next = next;
        }
    }
}
