using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var data1 = new double[,] { { 1, 2 }, { 3, 4, } };
            Matrix matrix1 = new Matrix(data1);
            var data2 = new double[,] { { 1, 2 }, { 3, 4 } };
            Matrix matrix2 = new Matrix(data2);
            

            Matrix matrix3 = matrix1 * matrix2;
            for (int i = 0; i < matrix3.Rows; i++)
            {
                for (int j = 0; j < matrix3.Columns; j++)
                {
                    Console.WriteLine(matrix3[i,j]);
                }
            }

            Console.WriteLine(matrix1.Equals(matrix2));
            Console.ReadKey();
            
        }
    }
}
 