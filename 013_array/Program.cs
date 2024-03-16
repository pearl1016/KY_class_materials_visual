﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10];

            //10개의 정수를 읽어서 배열에 저장
            for (int i = 0; i<10; i++)
                a[i] = int.Parse(Console.ReadLine()); //입력을 받을때는 무조건

            //배열에 저장된 10개의 정수를 출력
            for (int i = 0; i<10; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
           
           //foreach(a 배열에 있는 원소 x 각각에 대해서)
           foreach(var x in a)
                Console.Write(x + " ");
            Console.WriteLine();
        }
    }
}
//"틀리지 말기..."