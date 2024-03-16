using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _040_class_Rectangle
{
    //1.사각형을 나타내는 'Rectangle'클래스를 정의합니다. 
    internal class Program
    {
        //2. width와 height는 사각형의 가로와 세로의 길이를 나타낸다
        public class Rectangle
        {
            private double width;
            private double height;

            //Getter, Setter은 필요없다

            //3. 생성자를 사용하여 객체를 초기화
            public Rectangle(int w, int h)
            {
                width = w;
                height = h;
            }

            public double GetArea()
            {
            return width * height; 
            }

            public double GetPerimeter()
            {
            return 2*(width+height);
            }
        }     
        

        static void Main(string[] args)
        {

            Rectangle r = new Rectangle(5, 3);
            double area = r.GetArea();
            double perimeter =r.GetPerimeter();

            Console.WriteLine("넓이 : " + area);
            Console.WriteLine("둘레 : " + perimeter);


           
        }
    }
}
