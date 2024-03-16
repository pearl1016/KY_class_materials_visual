using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012_for
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            
            //1~100합
            for (int i = 1; i <= 100; i++)
                sum += i;
            Console.WriteLine("1~100의 합 : {0}", sum);

            //1~100의 홀수의 합
            sum = 0;
            for (int i = 1; i <= 100; i++)
                if (i % 2 == 1)
                    sum += i;
            Console.WriteLine("1~100의 홀수의 합 : {0}", sum);

            //1~100의 역수의 합
            double rSum = 0;
            for (int i = 1; i <= 100; i++)
                rSum += 1.0 / i;
            Console.WriteLine("1~100의 역수의 합 : {0}", rSum);

            //구구단
            Console.Write("구구단의 단을 입력 : ");
            int x = int.Parse(Console.ReadLine());

            for(int i=1; i <=9; i++)
            {
                Console.WriteLine("{0} X {1} = {2}", x, i, x * i);
            }

            //x의 y승
            int n, m;
            Console.Write("n을 입력: ");
            n = int.Parse(Console.ReadLine());
            Console.Write("m을 입력: ");
            m = int.Parse(Console.ReadLine());

            int pow = 1; 
            for (int i = 1; i <= m; i++)
                pow *= n;

            Console.WriteLine("{0}의 {1}승은 {2}입니다",n,m,pow);

            // 팩토리얼(k! = 1*2*3*k...*k)
            Console.Write("구하고자 하는 팩토리얼 수를 입력: ");
            int k = int.Parse(Console.ReadLine());
            int f = 1;
            for (int i = 1; i <= k; i++)
                f *= i;
            Console.WriteLine("{0}팩토리얼은 {1}", k, f);
        }
    }
}
