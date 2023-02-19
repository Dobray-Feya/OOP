// Вопрос: вместо проверки на null и кидания исключения лучше сделать через .?  см. https://metanit.com/sharp/tutorial/3.26.php

namespace Arkashova.VectorTask
{
    public class Vector
    {
        private int size;
        private double[] components;

        public Vector(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException($"Разменость вектора должна больше нуля. Указана резмерность: {size}.");
            }

            this.size = size;
            components = new double[size];

            for (int i = 0; i < this.size; i++)
            {
                components[i] = 0;
            }
        }

        public Vector(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException($"Нельзя создать вектор путем копирования null.");
            }

            size = vector.size;
            components = new double[size];

            for (int i = 0; i < size; i++)
            {
                components[i] = vector.components[i];
            }
        }

        public Vector(double[] numbers)
        {
            if (numbers is null)
            {
                throw new ArgumentNullException($"Нельзя создать вектор из массива null.");
            }

            size = numbers.Length;
            components = new double[size];

            for (int i = 0; i < size; i++)
            {
                components[i] = numbers[i];
            }
        }

        public Vector(int size, double[] numbers)
        {
            if (size < 0)
            {
                throw new ArgumentException($"Разменость вектора должна больше нуля. Указана резмерность: {size}.");
            }

            if (numbers is null)
            {
                throw new ArgumentNullException($"Нельзя создать вектор из массива null.");
            }

            this.size = size;
            components = new double[size];

            for (int i = 0; i < size && i < numbers.Length; i++)
            {
                components[i] = numbers[i];
            }

            for (int i = numbers.Length; i < size; i++)
            {
                components[i] = 0;
            }
        }

        public int GetSize()
        {
            return size;
        }

        public override string ToString()
        {
            if (components is null)
            {
                return String.Empty;
            }
            
            return "{" + String.Join(", ", components) + "}";
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

            if (vector.size != size)
            {
                return false;
            }

            for (int i = 0; i < size; i++)
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

            int hash = prime + size;

            for (int i = 0; i < size; i++)
            {
                hash = hash * prime + components[i].GetHashCode();
            }

            return hash;
        }

        public Vector Add(Vector vector)
        {
            if (vector is null)
            {
                return new Vector(this);
            }

            int maxSize = Math.Max(size, vector.size);

            Vector vector1 = new Vector(maxSize, components);
            Vector vector2 = new Vector(maxSize, vector.components);

            double[] resultcomponents = new double[maxSize];

            for (int i = 0; i < maxSize; i++)
            {
                resultcomponents[i] = vector1.components[i] + vector2.components[i];
            }

            return new Vector(resultcomponents);
        }

        public Vector Subtract(Vector vector)
        {
            if (vector is null)
            {
                return new Vector(this);
            }

            int maxSize = Math.Max(size, vector.size);

            Vector vector1 = new Vector(maxSize, this.components);
            Vector vector2 = new Vector(maxSize, vector.components);

            double[] resultcomponents = new double[maxSize];

            for (int i = 0; i < maxSize; i++)
            {
                resultcomponents[i] = vector1.components[i] - vector2.components[i];
            }

            return new Vector(resultcomponents);
        }

        public Vector MultiplyByScalar(double scalar)
        {
            Vector resultVector = new Vector(this);

            for (int i = 0; i < size; i++)
            {
                resultVector.components[i] *= scalar;
            }

            return resultVector;
        }

        public Vector Reverse()
        {
            return new Vector(this.MultiplyByScalar(-1));
        }

        public double GetLength()
        {
            double length = 0;

            for (int i = 0; i < size; i++)
            {
                length += components[i] * components[i];
            }

            return Math.Sqrt(length);
        }

        public double? GetComponent(int index)
        {
            if (index >= 0 && index < size)
            {
                return components[index];
            }

            if (size == 0)
            {
                Console.WriteLine($"Предупреждение: Не удалось получить компоненту {index} вектора {this}, т.к. вектор не содержит компонент.");
            }
            else if (index >= size)
            {
                Console.WriteLine($"Предупреждение: Нельзя получить компоненту {index} вектора {this}. Индекс компоненты должен быть от 0 до {size - 1}.");
            }
            else
            {
                Console.WriteLine($"Ошибка: Нельзя получить компоненту вектора {this} по индексу {index}. Индекс должен быть больше нуля.");
            }

            return null;
        }

        public void SetComponent(int index, double value)
        {
            if (index >= 0 && index < size && size > 0)
            {
                components[index] = value;
            }

            if (size == 0)
            {
                Console.WriteLine($"Предупреждение: Не удалось задать значение компоненте {index} вектора {this}, т.к. вектор не содержит компонент.");
            }
            else if (index > size)
            {
                Console.WriteLine($"Предупреждение: Нельзя задать значение компоненте {index} вектора {this}. Индекс компоненты должен быть от 0 до {size - 1}.");
            }
            else
            {
                Console.WriteLine($"Ошибка: Нельзя задать значение компоненте вектора {this} по индексу {index}. Индекс должен быть больше нуля.");
            }
        }

        public static Vector? AddVectors(Vector vector1, Vector vector2)
        {
            if (vector1 is null && vector2 is null)
            {
                return null;
            }

            if (vector1 is null)
            {
                return new Vector(vector2);
            }

            if (vector2 is null)
            {
                return new Vector(vector1);
            }

            return vector1.Add(vector2);
        }

        public static Vector? SubtractVectors(Vector vector1, Vector vector2)
        {
            if (vector1 is null && vector2 is null)
            {
                return null;
            }

            if (vector1 is null)
            {
                return new Vector(vector2.Reverse());
            }

            if (vector2 is null)
            {
                return new Vector(vector1);
            }

            return vector1.Subtract(vector2);
        }

        public static Vector? MultiplyByScalar(Vector vector, double scalar)
        {
            if (vector is null)
            {
                return null;
            }

            return vector.MultiplyByScalar(scalar);
        }
    }
}
