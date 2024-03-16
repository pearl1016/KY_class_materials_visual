using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _041_Student
{
    public class Student
    {
            private string name;
            private int age;
            private string major;

        public Student(string name, int age, string major)
        {
            this.name = name;
            this.age = age;
            this.major = major; 
            //매개변수랑 이름이 같기때문에 this를 사용하여 구별하게 된다. 
        }

        public void DisplayInfor() //return값이 없어서 void
        {
            Console.WriteLine("이름 : " + name);
            Console.WriteLine("나이 : " + age);
            Console.WriteLine("전공 : " + major);
        }
    }

    internal class Program
    { 
        static void Main(string[] args)
        {
            Student student = new Student("성진주", 21, "의료IT공학");
            student.DisplayInfor();
        }
    }
}
