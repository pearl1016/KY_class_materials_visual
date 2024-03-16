using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _039_student
{
    public class Student
    {

        //private int id;
        //private string name;
        //private int sub1;
        //private int sub2;
        //private int sub3;

        //속성 만들기 (대문자로)
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sub1 { get; set; }
        public int Sub2 { get; set; }
        public int Sub3 { get; set; }

        //Id는 음수일 수 없다는 조건
        private int id;

        public int MyProperty
        {
            get { return id; }
            set { if (id > 0) id = value; }
        }

        public Student(int id, string name, int sub1, int sub2, int sub3)
        {
            this.id = id;
            this.Name = name;   
            this.Sub1 = sub1;
            this.Sub2 = sub2;
            this.Sub3 = sub3;
        }


        static void Main(string[] args)
        {
            //(1)학생의 학번, 이름, 3개 과목의 점수를 저장하는 클래스를 만들어라(속성: getter, setter자동)
            //(2)s1과 s2객체를 만들고 생성자로 초기화해라
            //(3)학번, 이름, 평균점수를 출력하는 메소드를 만들고 s1과 s2객체를 출력하라
            Student s1 = new Student();
          

            s1.Id = 22615027;
            s1.Name = "성진주";
            s1.Sub1 = 100;
            s1.Sub2 = 100;
            s1.Sub3 = 100;

            Student s2 = new Student(22615027, "성진주", 100, 100 , 100);

            s1.Print();
            s2.Print();

        }
        public Student()
        {

        }
        public void Print()
        {
            Console.WriteLine("{0} {1} {2:F2}", Id, Name, (Sub1+Sub2+Sub3) / 3.0);
        }
    }
}
