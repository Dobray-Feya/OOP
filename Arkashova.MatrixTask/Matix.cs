using Arkashova.VectorTask;

namespace Arkashova.MatrixTask
{
    public class Matrix
    {
        private int xSize;
        private int ySize;
        private Vector[] rows;

        public Matrix(int xSize, int ySize)
        {
            if (xSize < 0 || ySize < 0)
            {
                throw new ArgumentException($"Ошибка: Размеры матрицы должны быть больше нуля. Задана матрица с размерами {xSize} и {ySize}.");
            }

            if ((xSize * ySize) == 0 && (xSize + ySize != 0))
            {
                throw new ArgumentException($"Ошибка: нельзя задать матрицу, у которой один размер  равен нулю, а второй отличен от нуля." +
                    $" Задана матрица с размерами {xSize} и {ySize}.");
            }

            this.xSize = xSize;
            this.ySize = ySize;

            rows = new Vector[ySize];

            for (int i = 0; i < ySize; i++)
            {
                rows[i] = new Vector(xSize);
            }
        }

        public Matrix(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException($"Нельзя создать матрицу путем копирования null.");
            }

            xSize = matrix.xSize;
            ySize = matrix.ySize;

            rows = new Vector[ySize];

            for (int i = 0; i < ySize; i++)
            {
                rows[i] = matrix.GetRow(i);
            }
        }

        public Matrix(double[,] numbers)
        {
            if (numbers is null)
            {
                throw new ArgumentNullException($"Нельзя создать матрицу из массива null.");
            }

            xSize = numbers.GetLength(1);
            ySize = numbers.GetLength(0);

            rows = new Vector[ySize];

            for (int i = 0; i < ySize; i++)
            {
                double[] numbersRow = new double[xSize];

                for (int j = 0; j < xSize; j++)
                {
                    numbersRow[j] = numbers[i, j];
                }

                rows[i] = new Vector(xSize, numbersRow);
            }
        }

        public Matrix(Vector[] vectors)
        {
            if (vectors is null)
            {
                throw new ArgumentNullException($"Нельзя создать матрицу из массива строк null.");
            }

            ySize = vectors.GetLength(0);

            int maxXSize = 0;

            for (int i = 0; i < ySize; i++)
            {
                if (vectors[i].GetSize() > maxXSize)
                {
                    maxXSize = vectors[i].GetSize();
                }
            }

            xSize = maxXSize;

            rows = new Vector[ySize];

            for (int i = 0; i < ySize; i++)
            {
                rows[i] = new Vector(xSize).Add(vectors[i]);
            }
        }

        public Vector GetRow(int index)
        {
            if (ySize == 0)
            {
                throw new ArgumentException($"Нельзя получить строку {index} матрицы, т.к. матрица пуста.");
            }
            
            if (index >= ySize || index < 0)
            {
                throw new ArgumentException($"Нельзя получить строку {index} матрицы. Номер строки должен быть от 0 до {ySize - 1}.");
            }

            return rows[index];
        }

        public void SetRow(int index, Vector vector)
        {
            if (ySize == 0)
            {
                throw new ArgumentException($"Нельзя задать строку {index} матрицы, т.к. матрица пуста.");
            }

            if (index < 0 || index >= ySize)
            {
                throw new ArgumentException($"Номер строки должен быть от 0 до {ySize - 1}. Задан номер: {index}.");
            }

            if (vector is null)
            {
                throw new ArgumentNullException($"Нельзя задать строку матрицы, равной null.");
            }

            if (vector.GetSize() != xSize)
            {
                throw new ArgumentException($"Размер вектора-строки должен быть равен {xSize}. Передана вектор-строка размера {vector.GetSize()}");
            }

            rows[index] = vector;
        }

        public Vector GetColumn(int index)
        {
            if (ySize == 0)
            {
                throw new ArgumentException($"Нельзя получить столбец {index} матрицы, т.к. матрица пуста.");
            }

            if (index >= xSize || index < 0) 
            {
                throw new ArgumentException($"Нельзя получить столбец {index} матрицы. Номер столбца должен быть от 0 до {xSize - 1}.");
            }

            Vector vector = new Vector(ySize);

            for (int i = 0; i < ySize; i++)
            {
                vector.SetComponent(i, rows[i].GetComponent(index));
            }

            return vector;
        }

        public override string ToString()
        {
            if (rows is null)
            {
                return String.Empty;
            }

            string[] matrixString = new string[ySize];

            for (int i = 0; i < ySize; i++)
            {
                matrixString[i] = rows[i].ToString();
            }

            return "{" + String.Join(", ", matrixString) + "}";
        }

        public int GetXSize()
        {
            return xSize;
        }

        public int GetYSize()
        {
            return ySize;
        }

        public Matrix Transpose()
        {
            Vector[] vectors = new Vector[xSize];

            for (int i = 0; i < xSize; i++)
            {
                vectors[i] = GetColumn(i);
            }

            return new Matrix(vectors);
        }

        public Matrix MultiplyByScalar(double scalar)
        {
            Vector[] vectors = new Vector[ySize];

            for (int i = 0; i < ySize; i++)
            {
                vectors[i] = GetRow(i).MultiplyByScalar(scalar);
            }

            return new Matrix(vectors);
        }

        public double GetDeterminant()
        {
            if (GetXSize() != GetYSize())
            {
                throw new ArgumentException($"Определитель можно вычислить только у квадратной матрицы. Переданная матрица имеет размеры {GetXSize()} и {GetYSize()}.");
            }

            int matrixSize = GetXSize();

            if (matrixSize == 1)
            {
                return GetRow(0).GetComponent(0);
            }

            if (matrixSize == 2)
            {
                return GetRow(0).GetComponent(0) * GetRow(1).GetComponent(1) - GetRow(0).GetComponent(1) * GetRow(1).GetComponent(0);
            }

            int sign = 1;
            double sum = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                sum += sign * GetRow(0).GetComponent(i) * GetMatrixWithoutZeroRowAndCertainColumn(this, i).GetDeterminant();

                sign *= -1;
            }

            return sum;
        }

        private Matrix GetMatrixWithoutZeroRowAndCertainColumn(Matrix sourceMatrix, int columnIndex)
        {
            int shortenMatrixSize = sourceMatrix.GetXSize() - 1;

            double[,] shortenMatrix = new double[shortenMatrixSize, shortenMatrixSize];

            for (int i = 0; i < shortenMatrixSize; i++)
            {
                for (int j = 0; j < columnIndex; j++)
                {
                    shortenMatrix[i, j] = sourceMatrix.GetRow(i + 1).GetComponent(j);
                }

                for (int j = columnIndex; j < shortenMatrixSize; j++)
                {
                    shortenMatrix[i, j] = sourceMatrix.GetRow(i + 1).GetComponent(j + 1);
                }
            }

            return new Matrix(shortenMatrix);
        }

        public Matrix Add(Matrix matrix)
        {
            if (GetXSize() != matrix.GetXSize() || GetYSize() != matrix.GetYSize())
            {
                throw new ArgumentException("Нельзя сложить две матрицы, т.к. их размеры не совпадают. " +
                    $"Размеры первой матрицы: {GetXSize()} и {GetYSize()}. " +
                    $"Размеры второй матрицы: {matrix.GetXSize()} и {matrix.GetYSize()}.");
            }

            Vector[] vectors = new Vector[ySize];

            for (int i = 0; i < ySize; i++)
            {
                vectors[i] = GetRow(i).Add(matrix.GetRow(i));
            }

            return new Matrix(vectors);
        }

        public Matrix Subtract(Matrix matrix)
        {
            if (GetXSize() != matrix.GetXSize() || GetYSize() != matrix.GetYSize())
            {
                throw new ArgumentException("Нельзя вычесть две матрицы, т.к. их размеры не совпадают. " +
                    $"Размеры первой матрицы: {GetXSize()} и {GetYSize()}. " +
                    $"Размеры второй матрицы: {matrix.GetXSize()} и {matrix.GetYSize()}.");
            }

            Vector[] vectors = new Vector[ySize];

            for (int i = 0; i < ySize; i++)
            {
                vectors[i] = GetRow(i).Subtract(matrix.GetRow(i));
            }

            return new Matrix(vectors);
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (xSize != vector.GetSize())
            {
                throw new ArgumentException($"Нельзя умножить матрицу на вектор, " +
                    $"т.к. количество столбцов в матрице ({xSize}) не равно размерности вектора ({vector.GetSize()}).");
            }

            double[] numbers = new double[ySize];

            for (int i = 0; i < ySize; i++)
            {
                for (int j = 0; j < xSize; j++)
                {
                    numbers[i] += GetRow(i).GetComponent(j) * vector.GetComponent(j);
                }
                
            }

            return new Vector(numbers);
        }

        public static Matrix Add(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetXSize() != matrix2.GetXSize() || matrix1.GetYSize() != matrix2.GetYSize())
            {
                throw new ArgumentException("Нельзя сложить две матрицы, т.к. их размеры не совпадают. " +
                    $"Размеры первой матрицы: {matrix1.GetXSize()} и {matrix1.GetYSize()}. " +
                    $"Размеры второй матрицы: {matrix2.GetXSize()} и {matrix2.GetYSize()}.");
            }

            Vector[] vectors = new Vector[matrix1.ySize];

            for (int i = 0; i < matrix1.ySize; i++)
            {
                vectors[i] = Vector.AddVectors(matrix1.GetRow(i), matrix2.GetRow(i));
            }

            return new Matrix(vectors);
        }

        public static Matrix Subtract(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetXSize() != matrix2.GetXSize() || matrix1.GetYSize() != matrix2.GetYSize())
            {
                throw new ArgumentException("Нельзя вычесть две матрицы, т.к. их размеры не совпадают. " +
                    $"Размеры первой матрицы: {matrix1.GetXSize()} и {matrix1.GetYSize()}. " +
                    $"Размеры второй матрицы: {matrix2.GetXSize()} и {matrix2.GetYSize()}.");
            }

            Vector[] vectors = new Vector[matrix1.ySize];

            for (int i = 0; i < matrix1.ySize; i++)
            {
                vectors[i] = Vector.SubtractVectors(matrix1.GetRow(i), matrix2.GetRow(i));
            }

            return new Matrix(vectors);
        }

        public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetXSize() != matrix2.GetYSize())
            {
                throw new ArgumentException("Нельзя перемножить две матрицы, т.к. количество столбцов в первой матрице не равно количеству строк во второй. " +
                    $"Размеры первой матрицы: {matrix1.GetXSize()} и {matrix1.GetYSize()}. " +
                    $"Размеры второй матрицы: {matrix2.GetXSize()} и {matrix2.GetYSize()}.");
            }

            Vector[] vectors = new Vector[matrix2.GetXSize()];

            for (int i = 0; i < matrix2.GetXSize(); i++)
            {
                vectors[i] = matrix1.MultiplyByVector(matrix2.GetColumn(i));
            }

            return new Matrix(vectors).Transpose();
        }
    }
}