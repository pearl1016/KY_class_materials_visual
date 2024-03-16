using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _044_StudentProp
{
    public class Student
    {
        public string Name { get; set; } //대문자
        public int Age { get; set; }
        public string Major { get; set; } //이거 아니면 getter setter써야함
        public Student(string name, int age, string major)
        {
            Name = name;
            Age = age;  
            Major = major;
        }
        public void DisplayInfor()
        {
            Console.WriteLine("이름 : " + Name);
            Console.WriteLine("나이 : " + Age);
            Console.WriteLine("전공 : " + Major);
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
