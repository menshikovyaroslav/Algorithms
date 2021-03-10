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

            // Left and right labirithm bounds
            for (int i = 0; i < mapH; i++)
            {
                map[i, 0] = -1;
                map[i, mapW - 1] = -1;
            }

            // Up and down labirithm bounds
            for (int i = 0; i < mapW; i++)
            {
                map[0, i] = -1;
                map[mapH - 1, i] = -1;
            }

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

            var aField = new Field(rnd.Next(1, mapH - 1), rnd.Next(1, mapW - 1), 1);
            var bField = new Field(rnd.Next(1, mapH - 1), rnd.Next(1, mapW - 1), 1);

            map[aField.I, aField.J] = 1;

            var queue = new Queue<Field>();
            queue.Enqueue(aField);

            while (queue.Count > 0)
            {
                var field = queue.Dequeue();

                if (map[field.I - 1, field.J] == 0) queue.Enqueue(new Field(field.I - 1, field.J, field.V + 1));
                if (map[field.I, field.J + 1] == 0) queue.Enqueue(new Field(field.I, field.J + 1, field.V + 1));
                if (map[field.I + 1, field.J] == 0) queue.Enqueue(new Field(field.I + 1, field.J, field.V + 1));
                if (map[field.I, field.J - 1] == 0) queue.Enqueue(new Field(field.I, field.J - 1, field.V + 1));

                if (map[field.I, field.J] == 0) map[field.I, field.J] = field.V;

                if (field.I == bField.I && field.J == bField.J) break;
            }

        }
    }

    public class Field
    {
        private int _i;
        private int _j;
        private int _v;

        public int I
        {
            get { return _i; }
            set { _i = value; }
        }

        public int J
        {
            get { return _j; }
            set { _j = value; }
        }

        public int V
        {
            get { return _v; }
            set { _v = value; }
        }

        public Field(int i, int j, int v)
        {
            I = i;
            J = j;
            V = v;
        }
    }
}
