using Arkashova.VectorTask;
using System.Text;

namespace Arkashova.MatrixTask
{
    public class Matrix
    {
        private Vector[] rows;

        public int RowsCount => rows.Length; // Заметка для себя: это краткий синтаксис коротких вычисляемых свойств только с геттером { get { return ... } }

        public int ColumnsCount => rows[0].GetSize();

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0 || columnsCount <= 0)
            {
                throw new ArgumentException($"Ошибка: Размеры матрицы должны быть больше нуля. Передана матрица с {rowsCount} строками и {columnsCount} столбцами.",
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
                throw new ArgumentNullException(nameof(matrix), "Нельзя скопировать матрицу. В качестве копируемой матрицы передано значение null.");
            }

            rows = new Vector[matrix.RowsCount];

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                rows[i] = matrix.GetRow(i);
            }
        }

        public Matrix(double[,] matrixComponents)
        {
            if (matrixComponents is null)
            {
                throw new ArgumentNullException(nameof(matrixComponents), "Не удалось создать матрицу из массива чисел. Переданный массив равен null.");
            }

            if (matrixComponents.Length == 0)
            {
                throw new ArgumentException("Не удалось создать матрицу из массива чисел. Переданный массив не содержит элементов.", nameof(matrixComponents));
            }

            int rowsCount = matrixComponents.GetLength(0);
            int columnsCount = matrixComponents.GetLength(1);

            rows = new Vector[rowsCount];

            double[] vectorComponents = new double[columnsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    vectorComponents[j] = matrixComponents[i, j];
                }

                rows[i] = new Vector(vectorComponents);
            }
        }

        public Matrix(Vector[] rows)
        {
            if (rows is null)
            {
                throw new ArgumentNullException(nameof(rows), "Не удалось создать матрицу из массива векторов. Переданный массив равен null.");
            }

            if (rows.Length == 0)
            {
                throw new ArgumentException("Не удалось создать матрицу из массива векторов. Переданный массив не содержит элементов.", nameof(rows));
            }

            int rowsCount = rows.Length;

            int maxColumnsCount = 0;

            foreach (Vector row in rows)
            {
                if (row.GetSize() > maxColumnsCount)
                {
                    maxColumnsCount = row.GetSize();
                }
            }

            this.rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                this.rows[i] = new Vector(maxColumnsCount);

                this.rows[i].Add(rows[i]);
            }
        }

        public Vector GetRow(int index)
        {
            if (index < 0 || index >= RowsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Не удалось получить строку матрицы с индексом {index}. Индекс строки должен быть от 0 до {RowsCount - 1}.");
            }

            return new Vector(rows[index]);  // Заметка для себя: нужно выдавать копию вектора, а не ссылку на вектор. Иначе если поменяется вектор, то изменится строка матрицы.
        }

        public void SetRow(int index, Vector row)
        {
            if (row is null)
            {
                throw new ArgumentNullException(nameof(row), "Нельзя задать строку матрицы равной null.");
            }

            if (row.GetSize() != ColumnsCount)
            {
                throw new ArgumentException($"Размер вектора-строки должен быть равен {ColumnsCount}. Передан вектор-строка размера {row.GetSize()}", nameof(row));
            }

            if (index < 0 || index >= RowsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Не удалось задать строку матрицы с индексом {index}. Индекс строки должен быть от 0 до {RowsCount - 1}.");
            }

            rows[index] = new Vector(row);
        }

        public Vector GetColumn(int index)
        {
            if (index < 0 || index >= ColumnsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Нельзя получить столбец матрицы с индексом {index}. Индекс столбца должен быть от 0 до {ColumnsCount - 1}.");
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
            stringBuilder.Append('{');

            foreach (Vector row in rows)
            {
                stringBuilder.Append(row)
                             .Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append('}');

            return stringBuilder.ToString();
        }

        public void Transpose()
        {
            Vector[] vectors = new Vector[ColumnsCount];

            for (int i = 0; i < ColumnsCount; i++)
            {
                vectors[i] = GetColumn(i);
            }

            rows = vectors;
        }

        public void MultiplyByScalar(double scalar)
        {
            foreach (Vector row in rows)
            {
                row.MultiplyByScalar(scalar);
            }
        }

        public double GetDeterminant()
        {
            if (RowsCount != ColumnsCount)
            {
                throw new InvalidOperationException("Определитель можно вычислить только у квадратной матрицы." +
                                                   $"Переданная матрица имеет размеры {RowsCount} на {ColumnsCount}.");
            }

            int matrixColumnsCount = ColumnsCount;

            if (matrixColumnsCount == 1)
            {
                return rows[0].GetComponent(0);
            }

            if (matrixColumnsCount == 2)
            {
                return rows[0].GetComponent(0) * rows[1].GetComponent(1) - rows[0].GetComponent(1) * rows[1].GetComponent(0);
            }

            int sign = 1;
            double sum = 0;

            for (int i = 0; i < matrixColumnsCount; i++)
            {
                sum += sign * rows[0].GetComponent(i) * GetMatrixWithoutZeroRowAndCertainColumn(this, i).GetDeterminant();

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
            CheckSizesEquation(this, matrix);

            for (int i = 0; i < RowsCount; i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            CheckSizesEquation(this, matrix);

            for (int i = 0; i < RowsCount; i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }
        }

        private static void CheckSizesEquation(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.RowsCount != matrix2.RowsCount || matrix1.ColumnsCount != matrix2.ColumnsCount)
            {
                throw new ArgumentException("Не удалось выполнить операцию над матрицами, т.к. их размеры не совпадают. " +
                                            $"Первая матрица: строк - {matrix1.RowsCount}, столбцов - {matrix1.ColumnsCount}. " +
                                            $"Вторая матрица: строк - {matrix2.RowsCount}, столбцов - {matrix2.ColumnsCount}.",
                                            $"{nameof(matrix1)}, {nameof(matrix2)}");
            }
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (ColumnsCount != vector.GetSize())
            {
                throw new ArgumentException($"Нельзя умножить матрицу на вектор, т.к. количество столбцов в матрице ({ColumnsCount}) не равно " +
                                            $"размерности вектора ({vector.GetSize()}).", nameof(vector));
            }

            double[] vectorComponents = new double[RowsCount];

            for (int i = 0; i < RowsCount; i++)
            {
                vectorComponents[i] = Vector.GetDotProduct(rows[i], vector);
            }

            return new Vector(vectorComponents);
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            Matrix resultMatrix = new Matrix(matrix1);

            resultMatrix.Add(matrix2);

            return resultMatrix;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            Matrix resultMatrix = new Matrix(matrix1);

            resultMatrix.Subtract(matrix2);

            return resultMatrix;
        }

        public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnsCount != matrix2.RowsCount)
            {
                throw new ArgumentException($"Нельзя перемножить две матрицы, т.к. количество столбцов в первой матрице ({matrix1.ColumnsCount}) " +
                                            $"не равно количеству строк во второй ({matrix2.RowsCount}). " +
                                            $"Размеры первой матрицы: {matrix1.RowsCount} на {matrix1.ColumnsCount}. " +
                                            $"Размеры второй матрицы: {matrix2.RowsCount} на {matrix2.ColumnsCount}." +
                                            $"{nameof(matrix1)}, {nameof(matrix2)}");
            }

            double[,] matrixComponents = new double[matrix1.RowsCount, matrix2.ColumnsCount];

            for (int i = 0; i < matrix1.RowsCount; i++)
            {
                for (int j = 0; j < matrix2.ColumnsCount; j++)
                {
                    matrixComponents[i, j] = Vector.GetDotProduct(matrix1.rows[i], matrix2.GetColumn(j));
                }
            }

            return new Matrix(matrixComponents);
        }
    }
}