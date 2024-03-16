using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _038_Class
{
    public class Rectangle
    {
        private int width;
        private int height;
        private int area;

        //Setter
        public void SetWidth(int w)
        {
            if (w>=0)
                width = w;
            else
                Console.WriteLine("width와 height는 0보다 크거나 같아야합니다.");
        }
        public void SetHeight(int h)
        {
            if (h>=0)
                height = h;
            else
                Console.WriteLine("width와 height는 0보다 크거나 같아야합니다.");
        }
         
        //값을 가져오는 Getter
        public int GetWidth()
        {
            return width;
        }
        public int GetHeight()
        {
            return height;
        }
        public int Area()
        {
            return width * height;
        }
        
       
    }
    public class Date
    {
        private int year, month, day; //public으로 할 시 어긋나는 방법이다
        public void Setyear(int year)
        {
            if(year >= 0)
                this.year = year;
        }
        public void SetMonth(int month)
        {
            if (month > 0 && month < 12)
                this.month = month;
        }
        public void Setday(int day)
        {
            if (day> 0 && day<= 31)
                this.day = day;
        }

        //Getter
        public int Getyear()
        {
           return year;
        }

        public int GetMonth()
        {
           return month;
        }
        public int Getday() 
        {
            return day;
        }

        //날짜를출력하는 메소드
        public void Print()
        {
            Console.WriteLine(year + "/" + month + "/" + day);  
        }

        //생성자: 리턴값이 없고 클래스와 같은 이름을 갖는 함수
        public Date(int y, int m, int d)
        {
            year = y;
            month = m;
            day = d;
        }

        public Date()
        {
            year = 1;
            month = 1;
            day = 1;
        }

    } //클래스 하나가 만들어 진 것

    internal class Program
    {
        static void Main(string[] args)
        {
            //생성자를 이용해서 날짜를 초기화
            Date today = new Date(2023, 6, 7);
            Console.Write("today : ");
            today.Print();

            Date date = new Date(); //date는 Date 클래스의 객체(instance)

            // date.year = 2023;   11줄이 private이기 때문에 안됨
            date.Setyear(2023);
            date.SetMonth(6);
            date.Setday(7);

            //오늘날짜를 출력해보시오
            Console.WriteLine("오늘의 날짜는 = {0}년 {1}월 {2}일 입니다.", date.Getyear(), 
                date.GetMonth(), date.Getday());




 
           Rectangle a = new Rectangle();

           a.SetWidth(10); 
           a.SetHeight(10);


            //Q. 면적을 계산해봐라
            //double area = r.SetWidth * r.SetHeight;

            //int area = a.GetWidth() * a.GetHeight();
            int area = a.Area();
            Console.WriteLine("a의 면적= {0}", area);

            
        }
    }
}
//객체 만드는거 시험 출제

