using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Resources;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            //dispatcherTimer.Tick += dispatcherTimer_tick;
            //dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            //dispatcherTimer.Start();

        }

        private void dispatcherTimer_tick(object sender, EventArgs e)
        {
           
            
            //int[] myArr = (int[])this.FindResource("myArr");
            
            //if (myArr != null && myArr.Length > 0)
            //{
            //    Random rnd = new Random();
            //    int j = rnd.Next(myArr.Length);
            //    DoubleAnimation da = (DoubleAnimation)SB3.Children[0];
            //    da.To = myArr[j];
            //    sb3.Begin(im2);
            //    button1.BeginAnimation(Canvas.TopProperty, da);
            //    BeginAnimation(Canvas.TopProperty, da2);
            //    BeginAnimation(Canvas.TopProperty, da3);
           
            //throw new NotImplementedException();
        }


        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            var rec = this.FindName("rec1") as Rectangle;
            var rec2 = this.FindName("rec2") as Rectangle;
            var rec3 = this.FindName("rec3") as Rectangle;
            var SB2 = this.FindResource("SB2") as Storyboard;
            var SB3 = this.FindResource("SB3") as Storyboard;
            var SB1 = this.FindResource("SB1") as Storyboard;
            //SB1.Begin(rec);
            //SB2.Begin(rec2);
            //SB3.Begin(rec3);

            int[] myArr = (int[])this.FindResource("arr");

            if (myArr != null && myArr.Length > 0)
            {
                int y = randomGen(0, 8);
                DoubleAnimation da = (DoubleAnimation)SB1.Children[0];
                da.To = myArr[y];
                SB1.Begin(rec);
            }

            if (myArr != null && myArr.Length > 0)
            {
                int y = randomGen(0, 8);
                //int j = rnd.Next(myArr.Length);
                DoubleAnimation da2 = (DoubleAnimation)SB2.Children[0];
                da2.To = myArr[y];
                SB2.Begin(rec2);
            }
            if (myArr != null && myArr.Length > 0)
            {
                int y = randomGen(0, 8);
                DoubleAnimation da3 = (DoubleAnimation)SB3.Children[0];
                da3.To = myArr[y];
                SB3.Begin(rec3);
            }

            Timeline tl;
            

            }
        private static readonly Random getrandom = new Random();
        private static readonly object synclock = new object();

        public static int randomGen(int minrange, int maxrange)
        {
            lock (synclock)
            {
                return getrandom.Next(minrange, maxrange);
            }

        }


        //var trans = new TranslateTransform();
        //var anim2 = new DoubleAnimation(0, newY, TimeSpan.FromSeconds(2))
        //{ EasingFunction = new SineEase() };
        //target.RenderTransform = trans;
        //trans.BeginAnimation(TranslateTransform.YProperty, anim2);


    }
}
