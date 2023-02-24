using Arkashova.VectorTask;

namespace Arkashova.MatrixTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(1, 1);
            Console.WriteLine(matrix1);

            Console.Write("GetRow(0) = ");
            Console.WriteLine(matrix1.GetRow(0));
            Console.WriteLine();

            double[,] numbers =
            {
                {1, 2},
                {3, 4},
                {5, 6},
            };

            Matrix matrix2 = new Matrix(numbers);
            Console.WriteLine(matrix2);

            Console.Write("GetRow(0) = ");
            Console.WriteLine(matrix2.GetRow(0));
            Console.WriteLine();

            Vector[] vectors =
            {
                new Vector(5),
                new Vector(Array.Empty<double>()),
                new Vector(5, new double[] {1.0, 2.0, 3.0 }),
                new Vector(3, new double[] {1.0, -2.0, 3.0, 4.0 })
            };

            Matrix matrix3 = new Matrix(vectors);
            Console.WriteLine(matrix3);

            Console.Write("GetRow(1) = ");
            Console.WriteLine(matrix3.GetRow(1));

            Console.Write("GetXSize() = ");
            Console.WriteLine(matrix3.GetXSize());

            Console.Write("GetYSize() = ");
            Console.WriteLine(matrix3.GetYSize());
            Console.WriteLine();

            Matrix matrix4 = new Matrix(matrix3);
            Console.WriteLine(matrix4);

            Vector testVector = new Vector(5, new double[] { 1.0, 2.0, 3.0 });
            Console.WriteLine($"SetRow(0, {testVector}");
            matrix4.SetRow(0, testVector);
            Console.WriteLine(matrix4);

            Console.Write("GetColumn(1) = ");
            Console.WriteLine(matrix4.GetColumn(1));
            Console.WriteLine();

            Console.WriteLine("Транспонированная матрица:");
            Console.WriteLine(matrix4.Transpose());
            Console.WriteLine();

            double scalar = 3;
            Console.WriteLine($"Матрица, умноженная на скаляр {scalar}:");
            Console.WriteLine(matrix4.MultiplyByScalar(scalar));
            Console.WriteLine();

            double[,] numbers5 =
            {
                { 10,  5, 1 },
                {  1,  3, 4 },
                { -1, -1, 2 }
            };

            Matrix matrix5 = new Matrix(numbers5);
            Console.WriteLine("Для матрицы:");
            Console.WriteLine(matrix5);
            Console.Write("определитель равен: ");
            Console.WriteLine(matrix5.GetDeterminant());

            Vector vector5 = new Vector((new double[] { 1, 2, 3 }));

            Console.WriteLine($"А при умножении на вектор {vector5} получится матрица:");
            Console.WriteLine(matrix5.MultiplyByVector(vector5));
            Console.WriteLine();

            double[,] numbers6 =
            {
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 }
            };

            Matrix matrix6 = new Matrix(numbers6);

            Console.Write("Матрица A =     ");
            Console.WriteLine(matrix6);

            double[,] numbers7 =
            {
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 }
            };

            Matrix matrix7 = new Matrix(numbers7);

            Console.Write("Матрица B =     ");
            Console.WriteLine(matrix7);

            Console.Write("Матрица A + B = ");
            Console.WriteLine(matrix7.Add(matrix6));

            Console.Write("Матрица A + B = ");
            Console.WriteLine(Matrix.Add(matrix7, matrix6));

            Console.Write("Матрица A - B = ");
            Console.WriteLine(matrix7.Subtract(matrix6));

            Console.Write("Матрица A - B = ");
            Console.WriteLine(Matrix.Subtract(matrix7, matrix6));
        }
    }
}