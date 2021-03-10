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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlgorithmLee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            int mapH, mapW = 20;
            Int32.TryParse(MapHeight.Text, out mapH);
            Int32.TryParse(MapWidth.Text, out mapW);

            var map = new int[mapH, mapW];
            var blockCount = (mapH - 2) * (mapW - 2) * 15 / 100;

            var rnd = new Random();

            while (blockCount > 0)
            {
                var rndH = rnd.Next(1, mapH - 1);
                var rndW = rnd.Next(1, mapW - 1);
                if (map[rndH, rndW] == 0)
                {
                    map[rndH, rndW] = -1;
                    blockCount--;
                }
            }
        }
    }
}
