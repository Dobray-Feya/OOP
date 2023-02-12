namespace Arkashova.ShapesTask
{
    class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape? shape1, IShape? shape2)
        {
            if (shape1 is null || shape2 is null)
            {
                throw new ArgumentException("ОШИБКА: объект не является фигурой (не реализует интерфейс IShape).");
            }

            return (int)(shape1.GetPerimeter() - shape2.GetPerimeter());
        }
    }
}