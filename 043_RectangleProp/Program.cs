﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _043_RectangleProp
{
    public class Rectangle
    {
        //private double width; //필드
        //public double Width { get; set; } //속성
        //public double Height { get; set; }
        private double width;

        public double Width
        {
            get { return width; }
            set
            {
                if (value>=0)
                    width = value;
                else
                    throw new Exception("Width는 음수일 수 없습니다"); //에러를 던지자
            }
        }
        private double height;

        public double Height

        {
            get { return height; }
            set
            {
                if (value>=0)
                    height = value;
                else
                    throw new Exception("Height는 음수일 수 없습니다");
            }
        }
        


        public Rectangle(double w, double h) 
        {
            Width = w;
            Height = h;
        }
        public double GetArea()
        {
            return Width * Height;
        }

        public double GetPerimeter()
        {
            return 2*(Width+Height);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(5, 3);
            //r.Width 로 쓸 수 있음
            double area = r.GetArea();
            double perimeter = r.GetPerimeter();

            Console.WriteLine("넓이 : " + area);
            Console.WriteLine("둘레 : " + perimeter);

            //r.Width = -10;을 쓰면 음수는 안된다는 출력이 나옴

            try
            {
                r.Width=-10;
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
