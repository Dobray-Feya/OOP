using System.Text;

namespace Arkashova.VectorTask
{
    public class Vector
    {
        private double[] components;

        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Размерность вектора должна быть больше, чем 0. Передана размерность: {size}.", nameof(size));
            }

            components = new double[size];  // Заметка для себя: элементам массива чисел не нужно явно присваивать 0, т.к. это значение по умолчанию.
        }

        public Vector(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), "Нельзя скопировать вектор. В качестве копируемого вектора передано значение null.");
            }

            int size = vector.components.Length;

            components = new double[size];
            Array.Copy(vector.components, components, size);
        }

        public Vector(double[] numbers)
        {
            if (numbers is null)
            {
                throw new ArgumentNullException(nameof(numbers), "Нельзя создать вектор из массива, равного null.");
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException("Нельзя создать вектор из массива длины 0.", nameof(numbers));
            }

            components = new double[numbers.Length];
            Array.Copy(numbers, components, numbers.Length);
        }

        public Vector(int size, double[] numbers)
        {
            if (size < 0)
            {
                throw new ArgumentException($"Размерность вектора должна быть > 0. Передана резмерность: {size}.", nameof(size));
            }

            if (numbers is null)
            {
                throw new ArgumentNullException(nameof(numbers), "Нельзя создать вектор из массива, равного null.");
            }

            components = new double[size];
            Array.Copy(numbers, components, Math.Min(size, numbers.Length));
        }

        public int GetSize()
        {
            return components.Length;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('{');

            foreach (double component in components)
            {
                stringBuilder.Append(component)
                             .Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append('}');

            return stringBuilder.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Vector vector = (Vector)obj;

            if (vector.components.Length != components.Length)
            {
                return false;
            }

            for (int i = 0; i < components.Length; i++)
            {
                if (vector.components[i] != components[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            const int prime = 37;

            int hash = prime + components.Length;

            foreach (double component in components)
            {
                hash = hash * prime + component.GetHashCode();
            }

            return hash;
        }

        public void Add(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), $"Нельзя добавить к вектору {this} вектор, равный null.");
            }

            Array.Resize(ref components, Math.Max(components.Length, vector.components.Length));

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] += vector.components[i];
            }
        }

        public void Subtract(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), $"Нельзя вычесть из вектора {this} вектор, равный null.");
            }

            Array.Resize(ref components, Math.Max(components.Length, vector.components.Length));

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] -= vector.components[i];
            }
        }

        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i] *= scalar;
            }
        }

        public void Reverse()
        {
            MultiplyByScalar(-1);
        }

        public double GetLength()
        {
            double sum = 0;

            foreach (double component in components)
            {
                sum += component * component;
            }

            return Math.Sqrt(sum);
        }

        public double GetComponent(int index)
        {
            if (index < 0 || index >= components.Length)
            {
                throw new IndexOutOfRangeException($"Нельзя получить компоненту с индексом {index} вектора {this}. Индекс компоненты должен быть от 0 до {components.Length - 1}.");
            }

            return components[index];
        }

        public void SetComponent(int index, double value)
        {
            if (index < 0 || index >= components.Length)
            {
                throw new IndexOutOfRangeException($"Нельзя задать значение компоненте с индексом {index} вектора {this}. Индекс компоненты должен быть от 0 до {components.Length - 1}.");
            }

            components[index] = value;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            if (vector1 is null)
            {
                throw new ArgumentNullException(nameof(vector1), $"Нельзя складывать векторы, если хотя бы один из них равен null. Переданы векторы {vector1} и {vector2}.");
            }

            if (vector2 is null)
            {
                throw new ArgumentNullException(nameof(vector2), $"Нельзя складывать векторы, если хотя бы один из них равен null. Переданы векторы {vector1} и {vector2}.");
            }

            Vector resultVector = new Vector(vector1);

            resultVector.Add(vector2);

            return resultVector;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            if (vector1 is null)
            {
                throw new ArgumentNullException(nameof(vector1), $"Нельзя вычитать векторы, если хотя бы один из них равен null. Переданы векторы {vector1} и {vector2}.");
            }

            if (vector2 is null)
            {
                throw new ArgumentNullException(nameof(vector2), $"Нельзя вычитать векторы, если хотя бы один из них равен null. Переданы векторы {vector1} и {vector2}.");
            }

            Vector resultVector = new Vector(vector1);

            resultVector.Subtract(vector2);

            return resultVector;
        }

        public static double GetVectorsDotProduct(Vector vector1, Vector vector2)
        {
            double dotProduct = 0;

            int minLength = Math.Min(vector1.components.Length, vector2.components.Length);

            for (int i = 0; i < minLength; i++)
            {
                dotProduct += vector1.components[i] * vector2.components[i];
            }

            return dotProduct;
        }
    }
}
