using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUI
{
    public class InputHandler
    {
        public double firstNumber;

        public CalculatorOperation requestedOperation;

        public double secondNumber;
    }
    
    public enum CalculatorOperation
    {
        Add = 0,
        Subtract,
        Multiply,
        Divide,
        None
    }
}
