using Arkashova.VectorTask;
using System.Text;

namespace Arkashova.MatrixTask
{
    public class Matrix
    {
        private Vector[] rows;

        public int RowsCount
        {
            get { return GetRowsCount(); }
        }

        public int ColumnsCount
        {
            get { return GetColumnsCount(); }
        }

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0 || columnsCount <= 0)
            {
                throw new ArgumentException($"Ошибка: Размеры матрицы должны быть больше нуля. Задана матрица с размерами {rowsCount} и {columnsCount}.",
                                            $"{nameof(rowsCount)}, {nameof(columnsCount)}");
            }

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = new Vector(columnsCount);
            }
        }

        public Matrix(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Нельзя создать матрицу путем копирования null.");
            }

            int rowsCount = matrix.RowsCount;

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = matrix.GetRow(i);
            }
        }

        public Matrix(double[,] numbers)
        {
            if (numbers is null)
            {
                throw new ArgumentNullException(nameof(numbers), "Нельзя создать матрицу из массива null.");
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException("Не удалось создать матрицу из массива чисел. Переданный массив чисел не содержит элементов.", nameof(numbers));
            }

            int rowsCount = numbers.GetLength(0);
            int columnsCount = numbers.GetLength(1);

            rows = new Vector[rowsCount];

            double[] numbersRow = new double[columnsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    numbersRow[j] = numbers[i, j];
                }

                rows[i] = new Vector(numbersRow);
            }
        }

        public Matrix(Vector[] rows)
        {
            if (rows is null)
            {
                throw new ArgumentNullException(nameof(rows), "Нельзя создать матрицу из массива строк null.");
            }

            if (rows.Length == 0)
            {
                throw new ArgumentException("Не удалось создать матрицу из массива векторов. Переданный массив векторов не содержит элементов.", nameof(rows));
            }

            int rowsCount = rows.GetLength(0);

            int maxColumnsCount = 0;

            for (int i = 0; i < rowsCount; i++)
            {
                if (rows[i].GetSize() > maxColumnsCount)
                {
                    maxColumnsCount = rows[i].GetSize();
                }
            }

            this.rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                this.rows[i] = new Vector(maxColumnsCount);

                this.rows[i].Add(rows[i]);
            }
        }

        public int GetRowsCount()
        {
            return rows.Length;
        }

        public int GetColumnsCount()
        {
            return rows[0].GetSize();
        }

        public Vector GetRow(int index)
        {
            if (index < 0 || index >= RowsCount)
            {
                throw new ArgumentException($"Нельзя получить строку {index} матрицы. Индекс строки должен быть от 0 до {RowsCount - 1}.", nameof(index));
            }

            return new Vector(rows[index]);  // Заметка для себя: нужно выдавать копию вектора, а не ссылку на вектор. Иначе если поменяется вектор, то изменится строка матрицы.
        }

        public void SetRow(int index, Vector row)
        {
            if (index < 0 || index >= RowsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс строки должен быть от 0 до {RowsCount - 1}. Задан индекс: {index}.");
            }

            if (row is null)
            {
                throw new ArgumentNullException(nameof(row), "Нельзя задать строку матрицы, равной null.");
            }

            if (row.GetSize() != ColumnsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(row), $"Размер вектора-строки должен быть равен {ColumnsCount}." +
                                                                   $"Передан вектор-строка размера {row.GetSize()}");
            }

            rows[index] = new Vector(row);
        }

        public Vector GetColumn(int index)
        {
            if (index < 0 || index >= ColumnsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Нельзя получить столбец {index} матрицы. Индекс столбца должен быть от 0 до {ColumnsCount - 1}.");
            }

            Vector vector = new Vector(RowsCount);

            for (int i = 0; i < RowsCount; i++)
            {
                vector.SetComponent(i, rows[i].GetComponent(index));
            }

            return vector;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{");

            foreach (Vector row in rows)
            {
                stringBuilder.Append(row.ToString())
                             .Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append("}");

            return stringBuilder.ToString();
        }

        public void Transpose()
        {
            Matrix sourceMatrix = new Matrix(this);

            int rowsCount = sourceMatrix.ColumnsCount;

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = sourceMatrix.GetColumn(i);
            }
        }

        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < RowsCount; i++)
            {
                rows[i].MultiplyByScalar(scalar);
            }
        }

        public double GetDeterminant()
        {
            if (RowsCount != ColumnsCount)
            {
                throw new InvalidOperationException("Определитель можно вычислить только у квадратной матрицы." +
                                                   $"Переданная матрица имеет размеры {RowsCount} на {ColumnsCount}.");
            }

            int matricolumnsCount = ColumnsCount;

            if (matricolumnsCount == 1)
            {
                return GetRow(0).GetComponent(0);
            }

            if (matricolumnsCount == 2)
            {
                return GetRow(0).GetComponent(0) * GetRow(1).GetComponent(1) - GetRow(0).GetComponent(1) * GetRow(1).GetComponent(0);
            }

            int sign = 1;
            double sum = 0;

            for (int i = 0; i < matricolumnsCount; i++)
            {
                sum += sign * GetRow(0).GetComponent(i) * GetMatrixWithoutZeroRowAndCertainColumn(this, i).GetDeterminant();

                sign *= -1;
            }

            return sum;
        }

        private static Matrix GetMatrixWithoutZeroRowAndCertainColumn(Matrix sourceMatrix, int columnIndex)  // Заметка для себя: метод статический, т.к. он не работает с полями текущего объекта
        {
            int shortenSize = sourceMatrix.ColumnsCount - 1;

            double[,] shortenMatrixArray = new double[shortenSize, shortenSize];

            for (int i = 0; i < shortenSize; i++)
            {
                for (int j = 0; j < columnIndex; j++)
                {
                    shortenMatrixArray[i, j] = sourceMatrix.GetRow(i + 1).GetComponent(j);
                }

                for (int j = columnIndex; j < shortenSize; j++)
                {
                    shortenMatrixArray[i, j] = sourceMatrix.GetRow(i + 1).GetComponent(j + 1);
                }
            }

            return new Matrix(shortenMatrixArray);
        }

        public void Add(Matrix matrix)
        {
            if (HaveDifferentSizes(this, matrix))
            {
                throw new ArgumentException("Нельзя сложить две матрицы, т.к. их размеры не совпадают. " +
                                            $"Размеры первой матрицы: {RowsCount} на {ColumnsCount}. " +
                                            $"Размеры второй матрицы: {matrix.RowsCount} на {matrix.ColumnsCount}.", nameof(matrix));
            }

            for (int i = 0; i < RowsCount; i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            if (HaveDifferentSizes(this, matrix))
            {
                throw new ArgumentException("Нельзя получить разность матриц, т.к. их размеры не совпадают. " +
                                            $"Размеры первой матрицы: {RowsCount} на {ColumnsCount}. " +
                                            $"Размеры второй матрицы: {matrix.RowsCount} на {matrix.ColumnsCount}.", nameof(matrix));
            }

            for (int i = 0; i < RowsCount; i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }
        }

        private static bool HaveDifferentSizes(Matrix matrix1, Matrix matrix2)
        {
            return matrix1.RowsCount != matrix2.RowsCount || matrix1.ColumnsCount != matrix2.ColumnsCount;
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (ColumnsCount != vector.GetSize())
            {
                throw new ArgumentException($"Нельзя умножить матрицу на вектор, т.к. количество столбцов в матрице ({ColumnsCount}) не равно " +
                                            $"размерности вектора ({vector.GetSize()}).", nameof(vector));
            }

            double[] numbers = new double[RowsCount];

            for (int i = 0; i < RowsCount; i++)
            {
                numbers[i] = Vector.GetVectorsDotProduct(rows[i], vector);
            }

            return new Vector(numbers);
        }

        public static Matrix GetMatriсesSum(Matrix matrix1, Matrix matrix2)
        {
            if (HaveDifferentSizes(matrix1, matrix2))
            {
                throw new ArgumentException("Нельзя сложить две матрицы, т.к. их размеры не совпадают. " +
                                           $"Размеры первой матрицы: {matrix1.RowsCount} на {matrix1.ColumnsCount}. " +
                                           $"Размеры второй матрицы: {matrix2.RowsCount} на {matrix2.ColumnsCount}.",
                                           $"{nameof(matrix1)}, {nameof(matrix2)}");
            }

            Matrix resultMatrix = new Matrix(matrix1);

            for (int i = 0; i < matrix1.RowsCount; i++)
            {
                resultMatrix.rows[i].Add(matrix2.rows[i]);
            }

            return resultMatrix;
        }

        public static Matrix GetMatriсesDifference(Matrix matrix1, Matrix matrix2)
        {
            if (HaveDifferentSizes(matrix1, matrix2))
            {
                throw new ArgumentException("Нельзя вычесть две матрицы, т.к. их размеры не совпадают. " +
                                           $"Размеры первой матрицы: {matrix1.RowsCount} на {matrix1.ColumnsCount}. " +
                                           $"Размеры второй матрицы: {matrix2.RowsCount} на {matrix2.ColumnsCount}.",
                                           $"{nameof(matrix1)}, {nameof(matrix2)}");
            }

            Matrix resultMatrix = new Matrix(matrix1);

            for (int i = 0; i < matrix1.RowsCount; i++)
            {
                resultMatrix.rows[i].Subtract(matrix2.rows[i]);
            }

            return resultMatrix;
        }

        public static Matrix GetMatricesProduct(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnsCount != matrix2.RowsCount)
            {
                throw new ArgumentException($"Нельзя перемножить две матрицы, т.к. количество столбцов в первой матрице ({matrix1.ColumnsCount}) " +
                                            $"не равно количеству строк во второй ({matrix2.RowsCount}). " +
                                            $"Размеры первой матрицы: {matrix1.RowsCount} на {matrix1.ColumnsCount}. " +
                                            $"Размеры второй матрицы: {matrix2.RowsCount} на {matrix2.ColumnsCount}." +
                                            $"{nameof(matrix1)}, {nameof(matrix2)}");
            }

            double[,] numbers = new double[matrix1.RowsCount, matrix2.ColumnsCount];

            for (int i = 0; i < matrix1.RowsCount; i++)
            {
                for (int j = 0; j < matrix2.ColumnsCount; j++)
                {
                    numbers[i, j] = Vector.GetVectorsDotProduct(matrix1.rows[i], matrix2.GetColumn(j));
                }
            }

            return new Matrix(numbers);
        }
    }
}