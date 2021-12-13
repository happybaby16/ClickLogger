using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Shapes;

namespace ClickLogger
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int[,] coor = new int[,] { { 100,100},{ 1,1},{ 800,600} };
        static double screenHeigth = SystemParameters.PrimaryScreenHeight;
        static double screenWidth = SystemParameters.PrimaryScreenWidth;
        static int row = (int)screenHeigth / (9*5);
        static int column = (int)screenWidth / (16*5);
        Frame[,] FrameList = new Frame[row, column];
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
                    Brush startColor = new SolidColorBrush(Color.FromRgb(Convert.ToByte(i*5), Convert.ToByte(k * 5), Convert.ToByte(i * 5)));
                    Frame tempFrame = new Frame();
                    tempFrame.Background = startColor;
                    gridOut.Children.Add(tempFrame);
                    Grid.SetRow(tempFrame, i);
                    Grid.SetColumn(tempFrame, k);
                    FrameList[i, k] = tempFrame;
                    c++;
                }
            }
            for (int i = 0; i < 3; i++)
            {

                int x = (coor[i, 0] /45);
                int y = (coor[i, 1] / 80);
                FrameList[x, y].Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            }
           
            

        }
    }
}
