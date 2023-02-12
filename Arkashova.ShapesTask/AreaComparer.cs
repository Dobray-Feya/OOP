namespace Arkashova.ShapesTask
{
    class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape? shape1, IShape? shape2)
        {
            if (shape1 is null || shape2 is null)
            {
                throw new ArgumentException("ОШИБКА: объект не является фигурой (не реализует интерфейс IShape).");
            }

            return (int)(shape1.GetArea() - shape2.GetArea());
        }
    }
}

// Заметка для себя. Статья о компораторах: https://metanit.com/sharp/tutorial/3.23.php