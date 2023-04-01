using System.Runtime.Serialization;

namespace Serialization
{
    [Serializable]
    internal class SymmetricMatrix //: ISerializable - здесь можно было бы реализовать интерфейс ISerializable, но это сложно
    {
        private int size;

        public double[,] matrix;

        public SymmetricMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Не удалось создать матрицу. Размер матрицы должен быть больше нуля.", nameof(size));
            }

            this.size = size;

            matrix = new double[size, size];

            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                matrix[i, i] = random.Next(0, 101);

                for (int j = i + 1; j < size; j++)
                {
                    matrix[i, j] = random.Next(0, 101);
                    matrix[j, i] = matrix[i, j];
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }

                Console.WriteLine();
            }
        }

        [OnSerializing] // если спрятать под комментарием этот и следующий метод, то будет применена стандартная сериализация.
        // У моей сериализации должен был получится файл меньшего размера, чем у стандартной, но получилось наоборот...НЕ знаю, как правильно.
        internal void OnSerializingMethod(StreamingContext context)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    matrix[i, j] = matrix[j, i];
                }
            }
        }
    }
}
