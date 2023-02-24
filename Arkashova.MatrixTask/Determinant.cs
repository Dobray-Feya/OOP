namespace Arkashova.MatrixTask
{
    public class Determinant
    {
        public static double GetDeterminant(Matrix matrix)
        {
            if (matrix.GetXSize() != matrix.GetYSize())
            {
                throw new ArgumentException("Определитель можно вычислить только у квадратной матрицы.");
            }

            int matrixSize = matrix.GetXSize();

            if (matrixSize == 1)
            {
                return matrix.GetRow(0).GetComponent(0);
            }

            if (matrixSize == 2)
            {
                return matrix.GetRow(0).GetComponent(0) * matrix.GetRow(1).GetComponent(1) - matrix.GetRow(0).GetComponent(1) * matrix.GetRow(1).GetComponent(0);
            }

            int sign = 1;
            double sum = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                sum += sign * matrix.GetRow(0).GetComponent(i) * GetDeterminant(GetMatrixWithoutZeroRowAndCertainColumn(matrix, i));

                sign *= -1;
            }

            return sum;
        }

        private static Matrix GetMatrixWithoutZeroRowAndCertainColumn(Matrix sourceMatrix, int columnIndex)
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
    }
}
