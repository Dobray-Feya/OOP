namespace Arkashova.VectorTask
{
    internal class Vector
    {
        public int Size { get; set; }

        double[] Components { get; set; } // use "?"

        public Vector(int size)
        {
            Size = size;
            Components = new double[Size];

            //if (size < 0)
            //{ нужно исключение}

            /* if (size == 0)
            {
                Components = Array.Empty<double>();
            }*/

            for (int i = 0; i < Size; i++)
            {
                Components[i] = 0;
            }
        }

        public Vector(Vector vector)
        {
            Size = vector.Size;
            Components = new double[Size];

            for (int i = 0; i < Size; i++)  // Components = vector.Components; - wrong! creates link, not araay
            {
                Components[i] = vector.Components[i];
            }
        }

        public Vector(double[] numbers)
        {
            Size = numbers.Length;
            Components = new double[Size];

            for (int i = 0; i < Size; i++)
            {
                Components[i] = numbers[i];
            }
        }

        public Vector(int size, double[] numbers)
        {
            Size = size;
            Components = new double[Size];

            for (int i = 0; i < Size && i < numbers.Length; i++)
            {
                Components[i] = numbers[i];
            }

            for (int i = numbers.Length; i < Size; i++)
            {
                Components[i] = 0;
            }
        }

        public int GetSize()
        {
            return Size;
        }

        public override string ToString()
        {
            if (Components == null)
            {
                return String.Empty;
            }
            else
            {
                return "{" + String.Join(", ", Components) + "}";
            }
        }

        public override bool Equals(object obj)
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

            if (vector.Size != Size)
            {
                return false;
            }

            for (int i = 0; i < Size; i++)
            {
                if (vector.Components[i] != Components[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            const int prime = 37;

            int hash = prime + Size;

            for (int i = 0; i < Size; i++)
            {
                hash = hash * prime + Components[i].GetHashCode();
            }

            return hash;
        }

        public Vector Add(Vector vector)
        {
            int maxSize = Math.Max(Size, vector.Size);

            Vector vector1 = new Vector(maxSize, Components);
            Vector vector2 = new Vector(maxSize, vector.Components);

            double[] resultComponents = new double[maxSize];

            for (int i = 0; i < maxSize; i++)
            {
                resultComponents[i] = vector1.Components[i] + vector2.Components[i];
            }

            return new Vector(resultComponents);
        }

        public Vector Subtract(Vector vector)
        {
            int maxSize = Math.Max(Size, vector.Size);

            Vector vector1 = new Vector(maxSize, this.Components);
            Vector vector2 = new Vector(maxSize, vector.Components);

            double[] resultComponents = new double[maxSize];

            for (int i = 0; i < maxSize; i++)
            {
                resultComponents[i] = vector1.Components[i] - vector2.Components[i];
            }

            return new Vector(resultComponents);
        }

        public Vector MultiplyByScalar(double scalar)
        {
            Vector resultVector = new Vector(this);

            for (int i = 0; i < Size; i++)
            {
                resultVector.Components[i] *= scalar;
            }

            return resultVector;
        }

        public Vector Reverse()
        {
            return this.MultiplyByScalar(-1);
        }

        public double GetLength()
        {
            double length = 0;

            for (int i = 0; i < Size; i++)
            {
                length += Components[i] * Components[i];
            }

            return Math.Sqrt(length);
        }

        public double? GetComponent(int index)
        {
            if (index >= 0 && index < Size && Size > 0) // Size > 0 - make another case
            {
                return Components[index];
            }

            return null; // must be warning. write test for index < 0 or > Size
        }

        public void SetComponent(int index, double value)
        {
            if (index >= 0 && index < Size && Size > 0) // Size > 0 - make another case
            {
                Components[index] = value;
            }
        }

        public static Vector AddVectors(Vector vector1, Vector vector2)
        {
            return vector1.Add(vector2);
        }

        public static Vector SubtractVectors(Vector vector1, Vector vector2)
        {
            return vector1.Subtract(vector2);
        }

        public static Vector MultiplyByScalar(Vector vector, double scalar)
        {
            return vector.MultiplyByScalar(scalar);
        }
    }
}
