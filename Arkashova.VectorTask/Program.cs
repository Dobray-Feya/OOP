namespace Arkashova.VectorTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector testVector = new Vector(new double[] { 1.0, 1.0, 1.0, 1.0 });

            Vector[] vectors =
            {
                new Vector(5),
                new Vector(Array.Empty<double>()),
                new Vector(testVector),
                new Vector(5, new double[] {1.0, 2.0, 3.0 }),
                new Vector(3, new double[] {1.0, -2.0, 3.0, 4.0 })
            };

            Console.WriteLine();
            Console.WriteLine("Размерность вектора и его хэш:");
            foreach (Vector vector in vectors)
            {
                Console.WriteLine($"{vector,-16} - {vector.GetSize()} - {vector.GetHashCode()}");
            }
            Console.WriteLine($"{testVector,-16} - {testVector.GetSize()} - {testVector.GetHashCode()}");

            Console.WriteLine();
            Console.WriteLine($"Результат проверки на равенство вектору {testVector}:");
            foreach (Vector vector in vectors)
            {
                Console.WriteLine($"{vector,-16} - {vector.Equals(testVector)}");
            }

            Console.WriteLine();
            Console.WriteLine("Результат сложения векторов:");
            Console.WriteLine("vector              testVector       vector.Add(testVector)        Vector.AddVectors(vector, testVector)");
            foreach (Vector vector in vectors)
            {
                Console.WriteLine($"{vector,-16} + {testVector,13}  =  {vector.Add(testVector)}  {Vector.AddVectors(vector, testVector),28}");
            }

            Console.WriteLine();
            Console.WriteLine($"Результат вычитания векторов:");
            Console.WriteLine("vector              testVector       vector.Subtract(testVector)   Vector.SubtractVectors(vector, testVector)");
            foreach (Vector vector in vectors)
            {
                Console.WriteLine($"{vector,-16} - {testVector,13}  =  {vector.Subtract(testVector)}  {Vector.SubtractVectors(vector, testVector),28}");
            }

            double scalar = -2.0;
            Console.WriteLine();
            Console.WriteLine("Результат умножения вектора на скаляр:");
            Console.WriteLine("vector              scalar     vector.MultiplyByScalar(scalar)     Vector.MultiplyByScalar(vector, scalar)");
            foreach (Vector vector in vectors)
            {
                Console.WriteLine($"{vector,-16} * {scalar,-7}  =  {vector.MultiplyByScalar(scalar)} {Vector.MultiplyByScalar(vector, scalar),35}");
            }

            Console.WriteLine();
            Console.WriteLine("Результат \"разворота\" вектора:");
            foreach (Vector vector in vectors)
            {
                Console.WriteLine($"{vector,-16}  ->  {vector.Reverse()}");
            }

            Console.WriteLine();
            Console.WriteLine("Длина вектора:");
            foreach (Vector vector in vectors)
            {
                Console.WriteLine($"{vector,-16}  ->  {vector.GetLength()}");
            }

            int index = 44;
            Console.WriteLine();
            Console.WriteLine($"Получить {index}-ую компоненту вектора:");
            foreach (Vector vector in vectors)
            {
                double? component = vector.GetComponent(index);
                Console.WriteLine($"{vector,-16}  ->  {(component is null ? " - " : component),2}");
            }

            double value = 100.0;
            Console.WriteLine();
            Console.WriteLine($"Установить {index}-ую компоненту вектора, равной {value}:");
            foreach (Vector vector in vectors)
            {
                Console.Write($"{vector,-16}  ->  ");
                vector.SetComponent(index, value);
                Console.WriteLine($"{vector,-16}");
            }

            Vector? badVector = null;

            Console.WriteLine();
            Console.WriteLine("Результат сложения вектора с null:");
            Console.WriteLine("vector                     vector.Add(null)      Vector.AddVectors(vector, null) Vector.AddVectors(null, vector)");
            foreach (Vector vector in vectors)
            {
                Console.WriteLine($"{vector,-16} + null =  {vector.Add(badVector)}  {Vector.AddVectors(vector, badVector),20}  {Vector.AddVectors(badVector, vector),30}");
            }

            Console.WriteLine();
            Console.WriteLine("Результат вычитания вектора и null:");
            Console.WriteLine("vector                vector.Subtract(null)      Vector.SubtractVectors(vector, null) Vector.SubtractVectors(null, vector)");
            foreach (Vector vector in vectors)
            {
                Console.WriteLine($"{vector,-16} - null =  {vector.Subtract(badVector)}  {Vector.SubtractVectors(vector, badVector),20}  {Vector.SubtractVectors(badVector, vector),30}");
            }

            Console.WriteLine();

            try
            {
                // tes1
                // Vector badVector1 = new Vector(-5);
                // Console.WriteLine(badVector1);

                // test2
                // Vector? badVector2 = null; 
                // Console.WriteLine(new Vector(badVector2));
                
                // test3
                double[]? badArray = null;
                Console.WriteLine(new Vector(badArray));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}