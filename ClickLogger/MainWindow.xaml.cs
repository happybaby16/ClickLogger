using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace ClickLogger
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int[,] coor = new int[,] { { 100,100},{ 1,1},{ 800,600}};
        static double screenHeigth = SystemParameters.PrimaryScreenHeight;
        static double screenWidth = SystemParameters.PrimaryScreenWidth;
        static int row = (int)(screenHeigth / (3*4));//y
        static int column = (int)(screenWidth / (4*4));//x
        Canvas[,] FrameList = new Canvas[row, column];
        Brush currentColor = Brushes.Red;
        bool isMouseDown = false;
        public MainWindow()
        {
            
            InitializeComponent();
            for (int i = 0; i < row; i++)
            {

                var temp = new ColumnDefinition();
                //GridLength settings = new GridLength(100, GridUnitType.Star);
                //temp.Width = settings;
                gridOut.ColumnDefinitions.Add(temp);
            }
            for (int i = 0; i < column; i++)
            {
                var temp = new RowDefinition();
                //GridLength settings = new GridLength(100, GridUnitType.Star);
                //temp.Height = settings;
                gridOut.RowDefinitions.Add(temp);
            }
            int c = 0;
            for (int i = 0; i < row; i++)
            {
                for (int k = 0; k < column; k++)
                {
                    Brush startColor = new SolidColorBrush(Color.FromRgb(255,255,255));
                    Canvas tempFrame = new Canvas();
                    tempFrame.MouseEnter += Draw;
                    tempFrame.Background = startColor;
                    gridOut.Children.Add(tempFrame);
                    Grid.SetRow(tempFrame, i);
                    Grid.SetColumn(tempFrame, k);
                    FrameList[i, k] = tempFrame;
                    c++;
                }
            }
            //ColorChanger();

            //for (int i = 0; i < 3; i++)
            //{
            //    int x = (coor[i, 0] / 20);
            //    int y = (coor[i, 1] / 15);
            //    FrameList[x, y].Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            //}
        }



        public void Draw(object sender, EventArgs e)
        {
            if (isMouseDown)
            {
                Canvas f = (Canvas)sender;
                f.Background = currentColor;
            }
        }
        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var windowPosition = Mouse.GetPosition(this);
            this.Title = string.Format("{0} --- {1}", windowPosition.X, windowPosition.Y);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = true;
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = false;
        }

        private void Frame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Frame ob = (Frame)sender;
            string parseLine = ob.Uid;
            string[] rgbColor = parseLine.Split(',');
            currentColor = new SolidColorBrush(Color.FromRgb(Convert.ToByte(rgbColor[0]), Convert.ToByte(rgbColor[1]), Convert.ToByte(rgbColor[2])));

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < row; i++)
            {
                for (int k = 0; k < column; k++)
                {
                    FrameList[i, k].Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                }
            }
        }

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < row; i++)
            {
                for (int k = 0; k < column; k++)
                {
                    FrameList[i, k].Background = currentColor;
                }
            }
        }

        private void btnRandomBack_Click(object sender, RoutedEventArgs e)
        {
            Random rd = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    byte r, g, b;
                    r = (byte)rd.Next(0, 255);
                    g = (byte)rd.Next(0, 255);
                    b = (byte)rd.Next(0, 255);
                    Brush tColor = new SolidColorBrush(Color.FromRgb(r, g, b));
                    FrameList[i, j].Background = tColor;
                }
            }
        }
    }
}
