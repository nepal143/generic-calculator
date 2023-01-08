using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericCalculator;

namespace CalculatorConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input first Number");
            var firstInputArg = Console.ReadLine();
            Console.WriteLine("Input second Number");
            var secondInputArg = Console.ReadLine();
            Console.WriteLine("Input operation Type: 1) Add 2) Subtract 3) Multiply 4) Divide");
            var operation = Console.ReadLine();

            var cal = new Calculate();
            double output = 0;
            switch (System.Convert.ToInt16(operation))
            {
                case 1:
                    output = cal.Add(System.Convert.ToDouble(firstInputArg), System.Convert.ToDouble(secondInputArg));
                    break;
                case 2:
                    output = cal.Subtract(System.Convert.ToDouble(firstInputArg), System.Convert.ToDouble(secondInputArg));
                    break;
                case 3:
                    output = cal.Multiply(System.Convert.ToDouble(firstInputArg), System.Convert.ToDouble(secondInputArg));
                    break;
                case 4:
                    output = cal.Divide(System.Convert.ToDouble(firstInputArg), System.Convert.ToDouble(secondInputArg));
                    break;
                default:
                    Console.WriteLine("Sorry I do not understand the operation");
                    break;
            }

            Console.WriteLine(output);
            Console.ReadLine();
        }


    }
    
}
