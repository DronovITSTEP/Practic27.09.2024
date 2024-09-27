using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic27._09._2024
{
    public delegate double CalcDelegate(double x, double y);
    public delegate T GenericCalsDelegate<T>(T x, T y);
    public class Calculate
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public static double Sub(double x, double y)
        {
            return x - y;
        }
        public double Mul(double x, double y)
        {
            return x * y;
        }
        public double Div(double x, double y)
        {
            if (y != 0)
                return x / y;
            throw new DivideByZeroException();
        }
    }
    internal class Program
    {
        //[модификатор_доступа] delegate тип_данных Имя_делегата(тип_параметров);
        public delegate int FooDelegate(int a, int b);

        public static int FooAdd(int a, int b)
        {
            return a + b;
        }
        public static int FooSub(int a, int b)
        {
            return a - b;
        }

        public static int Result(FooDelegate foo, int x, int y)
        {
            return foo(x, y)*10;
        }
        static void Main(string[] args)
        {
            /*Calculate calculate = new Calculate();
            try
            {
                string expression = ReadLine();
                char sign = ' ';

                foreach (char item in expression)
                {
                    if (item == '+' ||
                        item == '-' ||
                        item == '*' ||
                        item == '/')
                    {
                        sign = item;
                        break;
                    }
                }

                string[] numbers = expression.Split(sign);
                CalcDelegate calcDelegate = null;
                switch (sign)
                {
                    case '+':
                        calcDelegate = new CalcDelegate(calculate.Add);
                        break;
                    case '-':
                        calcDelegate = new CalcDelegate(Calculate.Sub);
                        break;
                    case '*':
                        calcDelegate = calculate.Mul;
                        break;
                    case '/':
                        calcDelegate = calculate.Div;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
                double x = double.Parse(numbers[0]);
                double y = double.Parse(numbers[1]);
                WriteLine($"Результат операции {sign}: " +
                    $"{calcDelegate(x, y)}");

                CalcDelegate calcAll = null;
                calcAll = calculate.Add;
                calcAll += calculate.Div;
                calcAll += calculate.Mul;
                GenericCalsDelegate<double> genCalcAll = null;
                genCalcAll = calculate.Add;
                genCalcAll += calculate.Div;
                genCalcAll += calculate.Mul;

                foreach (CalcDelegate item in calcAll.GetInvocationList())
                {
                    WriteLine($"\nМульти делегат: {item(x, y)}");                 
                }
                calcAll -= calculate.Div;
                WriteLine();
                foreach (CalcDelegate item in calcAll.GetInvocationList())
                {
                    WriteLine($"\nМульти делегат: {item(x, y)}");
                }

            }
            catch (Exception e)
            {
                WriteLine(e.ToString());
            }*/

            Result(FooSub,4, 6);
            Result(FooAdd,4, 6);
        }
    }
}
