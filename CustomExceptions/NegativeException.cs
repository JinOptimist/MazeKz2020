using System;
using System.Collections.Generic;
using System.Text;

namespace MazeKz.CustomExceptions
{
    public class NegativeException : Exception
    {
        public override string Message => "Числа не могут быть меньше 0";
    }
}
