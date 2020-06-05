using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class IncorrectDimensionOfMatrixException:Exception
    {
        public IncorrectDimensionOfMatrixException() { }

        public IncorrectDimensionOfMatrixException(string message)
            : base(message) { }
    }
}
