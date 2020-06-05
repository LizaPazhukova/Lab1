using System;

namespace Matrix
{
    public class Matrix : ICloneable
    {
        private readonly double[,] data;
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public Matrix(int rows, int columns)
        {
            if (rows < 0 || columns < 0)
                throw new ArgumentException();
            this.Rows = rows;
            this.Columns = columns;
            this.data = new double[rows, columns];
        }
        public Matrix(double[,] data)
        {
            if (data==null)
                throw new ArgumentException();
            this.Rows = data.GetLength(0);
            this.Columns = data.GetLength(1);
            this.data = data;
        }
        public double this[int index1, int index2]
        {
            get
            {
                if (index1 < 0 || index2 < 0 || index1 >= Rows || index2 >= Columns)
                    throw new IndexOutOfRangeException();
                return data[index1, index2];
            }
            set
            {
                if (index1 < 0 || index2 < 0 || index1 >= Rows || index2 >= Columns)
                    throw new IndexOutOfRangeException();
                data[index1, index2] = value;
            }
        }
        public override bool Equals(Object obj)
        {
            var matrix = obj as Matrix;

            return matrix != null && matrix == this;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix(this.data);
        }

        public static bool operator ==(Matrix a, Matrix b)
        {
            if (a is null)
            {
                return b is null;
            }

            if (b is null)
            {
                return a is null;
            }

            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                return false;
            }
            
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    if (a[i, j] != b[i, j]) return false;
                }
            }
            return true;
        }
        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new IncorrectDimensionOfMatrixException("Addition is not possible. Dimension of matrices should be equal");
            }
            var result = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if(a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new IncorrectDimensionOfMatrixException("Subtraction is not possible. Dimension of matrices should be equal");
            }
            var result = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Rows != b.Columns)
            {
                throw new IncorrectDimensionOfMatrixException("Multiplication is not possible. The number of columns in the first matrix should be equal to the number of rows in the second");
            }
            var result = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    for (int k = 0; k < a.Rows; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }

                }
            }
            return result;
        }

    }

}
 