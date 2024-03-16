using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _036_SnakeBite
{
    /// <summary>
    /// Game.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Game : Window
    {
        private Ellipse[] snakes = new Ellipse[30];
        private Ellipse egg;
        private Random r = new Random();
        private int visibleCount = 5;     //뱀 중에서 보이는 Ellipse의 갯수
        private int size = 15;            //Ellipse의 크기

        DispatcherTimer timer = new DispatcherTimer();
        Stopwatch sw = new Stopwatch();
        string move = ""; //움직이는 방향을 표시
        int eaten = 0; //내가 먹은 알의 갯수

        private SoundPlayer myPlayer;
        private MediaPlayer bgm;


        public Game() //생성자
        {
            InitializeComponent();
            InitEgg();
            InitSnakes(); //뱀을 만든다
            InitSound();

            timer.Interval = new TimeSpan(0, 0, 0, 0, 100); //0.1초 마다 한번씩
            timer.Tick +=Timer_Tick; 
        }

        private void InitSound()
        {
            myPlayer = new SoundPlayer();
            myPlayer.SoundLocation = "../../Sounds/Windows Notify.wav";

            bgm = new MediaPlayer();
            bgm.Open(new Uri("../../Sounds/stranger.mp3", UriKind.Relative));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (move!= "") //움직일때만 실행이 되야한다
            {


                //몸통 좌표
                for (int i = visibleCount; i>0; i--)
                    snakes[i].Tag = (Point)snakes[i-1].Tag;

                //머리의 좌표
                Point q = (Point)snakes[0].Tag;

                if (move == "U")
                    snakes[0].Tag = new Point(q.X, q.Y-size);
                else if (move == "D")
                    snakes[0].Tag = new Point(q.X, q.Y+size);
                else if (move == "L")
                    snakes[0].Tag = new Point(q.X - size, q.Y);
                else if (move == "R")
                    snakes[0].Tag = new Point(q.X + size, q.Y);

                EatEgg();
                DrawSnakes();
            }
            
            TimeSpan ts = sw.Elapsed;
            //txtTimer.Text = ts.ToString();
            txtTimer.Text = string.Format("Time = {0:00}:{1:00}.{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds);
        }

        private void EatEgg() //알을 먹었는지 체크(뱀의 머리와 egg의 좌표가 같은가)
        {
           Point pS = (Point)snakes[0].Tag;
            Point pE = (Point)egg.Tag;

            if(pS.X == pE.X && pS.Y == pE.Y)
            {
                myPlayer.Play();
                egg.Visibility = Visibility.Hidden;
                visibleCount++;
                snakes[visibleCount-1].Visibility = Visibility.Visible; //꼬리가 하나 늘어났다.
                txtScore.Text = "Eggs = " + ++eaten;
                 
                if(visibleCount == 30)
                {
                    bgm.Stop();
                    timer.Stop();
                    sw.Stop();
                    DrawSnakes();

                    TimeSpan ts = sw.Elapsed;
                    string s = string.Format("Time = {0:00}:{1:00}.{2:00}",
                        ts.Minutes, ts.Seconds, ts.Milliseconds);
                    MessageBox.Show("Success!!!" + s + " sec"); //몇초가 걸렸는지 메세지박스에 뜨게
                    this.Close();
                }

                int x = r.Next(0, (int)field.Width / size - 1);
                int y = r.Next(0, (int)field.Height / size - 1);

                Point p = new Point(x*size, y*size);
                egg.Tag = p;
                egg.Visibility = Visibility.Visible;
                Canvas.SetLeft(egg, p.X);
                Canvas.SetTop (egg, p.Y); 
            }
        }

        private void DrawSnakes()
        {
            //뱀을 그려주는곳
            for(int i=0; i<visibleCount; i++)
            {
                Point p = (Point)snakes[i].Tag;
                Canvas.SetLeft(snakes[i], p.X);
                Canvas.SetTop(snakes[i], p.Y);
            }

        }

        private void InitSnakes() //뱀을 만드는 과정
        {
            int x = r.Next(0, (int)field.Width / size - 1);
            int y = r.Next(0, (int)field.Height / size - 5);  //-5로 하는 이유: 뱀이 다 보이게 하기 위해

            for(int i=0; i<30; i++)
            {
                snakes[i] = new Ellipse();
                snakes[i].Width = size;
                snakes[i].Height = size;
                if (i%5==0)
                    snakes[i].Fill = Brushes.Green;
                else
                    snakes[i].Fill = Brushes.Gold;

                snakes[i].Stroke = Brushes.Black;
                field.Children.Add(snakes[i]);

                snakes[i].Tag = new Point(x*size, (y+i)*size);
                Canvas.SetLeft(snakes[i], x*size);
                Canvas.SetTop(snakes[i], (y+i)*size);
            }
            // 머리
            snakes[0].Fill = Brushes.Chocolate;
            for (int i = visibleCount; i<30; i++)
                snakes[i].Visibility = Visibility.Hidden;
        }

        private void InitEgg() //잡아야하는 점
        {
            egg = new Ellipse();   //egg는 ellipse의 객체
            egg.Width = size;
            egg.Height = size;
            egg.Stroke = Brushes.Black; 
            egg.Fill = Brushes.Red; 

            //캔버스의 크기 Width="420" Height="320"
            int x = r.Next(0, (int)field.Width / size - 1);
            int y = r.Next(0, (int)field.Height / size - 1);

            Point p = new Point(x*size, y*size);
            egg.Tag=p; //x,y의 값을 tag에 넣어줌
            
            field.Children.Add(egg);
            Canvas.SetLeft(egg, x*size);
            Canvas.SetTop(egg, y*size);


        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            timer.Start();
            sw.Start();
            bgm.Play();

            if (e.Key == Key.Left)
                move = "L";
            else if (e.Key == Key.Right)
                move = "R";
            else if (e.Key== Key.Up)
                move = "U";
            else if (e.Key == Key.Down)
                move = "D";
            else if (e.Key == Key.Escape)
            {
                bgm.Pause();
                move = "";
            }
        }
    }
}
