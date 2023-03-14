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
                new Vector(new double[] { 10 }),
                new Vector(testVector),
                new Vector(5, new double[] { 1.0, 2.0, 3.0 }),
                new Vector(3, new double[] { 1.0, -2.0, 3.0, 4.0 })
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
            Console.WriteLine("Скалярное произведение векторов:");
            Console.WriteLine("vector              testVector       Vector.GetDotProduct(vector, testVector)");

            foreach (Vector vector in vectors)
            {
                Console.WriteLine($"{vector,-16}  x {testVector,13}  =  {Vector.GetDotProduct(vector, testVector),5}");
            }

            Console.WriteLine();
            Console.WriteLine("Результат сложения векторов:");
            Console.WriteLine("vector              testVector       vector.Add(testVector)        testVector       Vector.AddVectors(vector, testVector)");

            foreach (Vector vector in vectors)
            {
                Console.Write($"{vector,-16}  + {testVector,13}  = ");
                vector.Add(testVector);
                Console.WriteLine($"{vector,16}  + {testVector,16} = {Vector.GetSum(vector, testVector),20}");
            }

            Console.WriteLine();
            Console.WriteLine("Результат вычитания векторов:");
            Console.WriteLine("vector              testVector       vector.Subtract(testVector)   testVector       Vector.SubtractVectors(vector, testVector)");

            foreach (Vector vector in vectors)
            {
                Console.Write($"{vector,-16}  - {testVector,13}  =  ");
                vector.Subtract(testVector);
                Console.WriteLine($"{vector,16}  - {testVector,16} = {Vector.GetDifference(vector, testVector),20}");
            }

            double scalar = -2.0;
            Console.WriteLine();
            Console.WriteLine("Результат умножения вектора на скаляр:");
            Console.WriteLine("vector              scalar     vector.MultiplyByScalar(scalar)");

            foreach (Vector vector in vectors)
            {
                Console.Write($"{vector,-16} * {scalar,-7}  =  ");
                vector.MultiplyByScalar(scalar);
                Console.WriteLine($"{vector,16}");
            }

            Console.WriteLine();
            Console.WriteLine("Результат \"разворота\" вектора:");

            foreach (Vector vector in vectors)
            {
                Console.Write($"{vector,-20}  ->  ");
                vector.Reverse();
                Console.WriteLine($"{vector}");
            }

            Console.WriteLine();
            Console.WriteLine("Длина вектора:");

            foreach (Vector vector in vectors)
            {
                Console.WriteLine($"{vector,-16}  ->  {vector.GetLength()}");
            }

            int index = 4;
            Console.WriteLine();
            Console.WriteLine($"Получить {index}-ую компоненту вектора:");

            foreach (Vector vector in vectors)
            {
                Console.Write($"{vector,-16}  ->  ");

                try
                {
                    Console.WriteLine(vector.GetComponent(index));
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            double value = 100.0;
            Console.WriteLine();
            Console.WriteLine($"Установить {index}-ую компоненту вектора, равной {value}:");

            foreach (Vector vector in vectors)
            {
                Console.Write($"{vector,-16}  ->  ");

                try
                {
                    vector.SetComponent(index, value);
                    Console.WriteLine($"{vector}");
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine();

            try
            {
                Vector? badVector = null;
                Vector? goodVector = new Vector(new double[] { 1.0, 2.0, 3.0 });

                Console.WriteLine($"{goodVector} + {badVector} =");
                Console.WriteLine(Vector.GetSum(goodVector, badVector));
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Произошла ошибка в параметре {e.ParamName}.");
                Console.WriteLine("Описание ошибки:");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();

            try
            {
                Console.WriteLine("Vector(-5) =");
                Console.Write(new Vector(-5));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Произошла ошибка в параметре {e.ParamName}.");
                Console.WriteLine("Описание ошибки:");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();

            try
            {
                Vector? badVector1 = null;

                Console.WriteLine("new Vector(null vector) =");
                Console.WriteLine(new Vector(badVector1));
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Произошла ошибка в параметре {e.ParamName}.");
                Console.WriteLine("Описание ошибки:");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();

            try
            {
                double[] badArray = { };

                Console.WriteLine("new Vector({ }) =");
                Console.WriteLine(new Vector(badArray));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Произошла ошибка в параметре {e.ParamName}.");
                Console.WriteLine("Описание ошибки:");
                Console.WriteLine(e.Message);
            }
        }
    }
}