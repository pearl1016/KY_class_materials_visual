using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading; //DispatcherTimer

namespace _032_MatchingGame
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random r= new Random();
        private string[] icon = { "딸기", "레몬", "모과", "배", "사과", "수박", "파인애플", "포도" };
        private int[] rnd = new int[16]; //0으로 초기화된다
        private Button first = null;
        private Button second = null;
        
        //
        //타이머 사용시 주의점
        //WindowForm : Timer t = new Timer()
        //WPF : DispatcherTimer t = new DispatcherTimer()

        DispatcherTimer myTimer = new DispatcherTimer();  //타이머

        int matched = 0;   //맞춘 카드의 숫자


        public MainWindow() //생성자함수
        {
            InitializeComponent();
            BoardSet();

            //타이머 처리
            myTimer.Interval = new TimeSpan(0, 0, 0, 0, 750); //0.75초
            myTimer.Tick += MyTimer_Tick;
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            myTimer.Stop();
            first.Content = MakeImage("../../Images/check.png");
            second.Content = MakeImage("../../Images/check.png");
            first = null;
            second = null;
        }

        private void BoardSet() 
        {
            for(int i=0; i<16; i++)
            {
                Button btn = new Button();
                btn.Background = Brushes.White;
                btn.Margin = new Thickness(10); //모든 방향의 여백을 10

                btn.Tag = TagSet();  //2개씩만 들어가있게.. 중요한 함수이다.
                // btn.Content = (int)(btn.Tag); //Tag 테스트용
                btn.Content = MakeImage("../../Images/check.png"); 
                btn.Click += Btn_Click;
                board.Children.Add(btn);
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button; //sender을 btn으로 변환시킨다

            string fruit = "../../Images/" + icon[(int)btn.Tag];
            btn.Content = MakeImage(fruit+".png");

            if (first==null) //지금 눌린 버튼이 첫번째 버튼이라면
            {
                first = btn;
                btn.Content = MakeImage(fruit + ".png");
                return;
            }
            else if (second ==null)
            {
                second = btn;
                btn.Content = MakeImage(fruit + ".png");
            }
            else
                return;

            //first와 second가 매칭되는지를 체크(Tag로 체크한다)
            if((int)first.Tag == (int)second.Tag)
            {
                first = null;
                second = null;

                //매칭이 다 되면 프로그램이 꺼져야 함으로 
                matched += 2;
                if(matched >= 16) // 모두 다 맞추었으면
                {
                   MessageBoxResult result=
                        MessageBox.Show("성공! 다시 할까요?", "Success!", MessageBoxButton.YesNo);
 
                    if (result == MessageBoxResult.Yes)//Yes라면 처음부터 다시시작
                    { 
                        
                        ResetRnd(); //1.rnd[]배열을 초기화
                        board.Children.Clear();//2.board를 초기화(board 안에 있는 Children을 삭제)
                        BoardSet();//3.BoardSet() 
                        matched = 0;//4.matched = 0 초기화

                    }
                    else
                        this.Close();
                }
            }
            else
            {
                myTimer.Start();
            }
        }

        private void ResetRnd() //rnd[]배열을 초기화한다
        {
            for (int i = 0; i<16; i++)
            {
                rnd[i]=0;
            }
        }

        //v로 넘어온 이미지 파일을 img객체로 만들어서 리턴하는 메소드
        private object MakeImage(string v)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(v, UriKind.Relative);
            bi.EndInit();

            Image img = new Image();
            img.Margin = new Thickness(10);
            img.Stretch = Stretch.Fill;
            img.Source = bi;
            return img;
        }

        // 0~15까지의 숫자를 한번씩만 만들어 리턴한다. 
        private int TagSet() //중요한 문제! 교수님이 콕 찝으신 시험문제 !!
        {
            int i;

            while(true)
            {
                i=r.Next(16);
                if (rnd[i] ==0) //처음 이 숫자가 나왔다는 의미
                {
                    break;
                }
            }
            return i%8; //0~7까지의 숫자 = 과일을 구분

        }


    }
}
//시험내기 딱 좋다