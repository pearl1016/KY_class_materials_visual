using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _042_Calculator
{
    //간단한 계산기를 나타내는 'Calculator'클래스를 정의
    public class Calculator
    {
        public static int Add(int num1, int num2)
        {
            return num1 + num2;
        }
        public static int Subtract(int num1, int num2)
        {
            return num1 - num2;
        }
        public static int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }
        public static double Divide(int num1, int num2)
        {
            return (double) num1 / num2;
        }
    }
    

    internal class Program
    {
        
        static void Main(string[] args)
        {
            int num1 = 5;
            int num2 = 10;

       
            int sum = Calculator.Add(num1, num2);
            int difference = Calculator.Subtract(num1, num2);
            int product = Calculator.Multiply(num1, num2);
            double quotient = Calculator.Divide(num1, num2);


            Console.WriteLine("덧셈 : " + sum);
            Console.WriteLine("뺄셈 : " + difference);
            Console.WriteLine("곱셈 : " + product);
            Console.WriteLine("나눗셈 : " + quotient);

        }
        
    }
}
