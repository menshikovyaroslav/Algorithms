using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            #region Map Bounds

            int mapH, mapW, blockPercent = 20;
            Int32.TryParse(MapHeightTb.Text, out mapH);
            Int32.TryParse(MapWidthTb.Text, out mapW);
            Int32.TryParse(MapBlockPercent.Text, out blockPercent);

            if (mapH == 0) mapH = 20;
            if (mapW == 0) mapW = 20;
            if (blockPercent == 0) mapH = 20;

            var map = new int?[mapH, mapW];
            var blockCount = (mapH - 2) * (mapW - 2) * blockPercent / 100;

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
                if (map[rndH, rndW] == null)
                {
                    map[rndH, rndW] = -1;
                    blockCount--;
                }
            }

            #endregion

            #region Creating A and B points

            Field aField = null;
            Field bField = null;

            while (true)
            {
                var h = rnd.Next(1, mapH - 1);
                var w = rnd.Next(1, mapW - 1);

                if (map[h, w] == null)
                {
                    aField = new Field(h, w, 0);
                    break;
                }
            }

            while (true)
            {
                var h = rnd.Next(1, mapH - 1);
                var w = rnd.Next(1, mapW - 1);

                if (map[h, w] == null && !(h == aField.I && w == aField.J))
                {
                    bField = new Field(h, w, null);
                    break;
                }
            }

            #endregion

            #region Filling the map

            var queue = new Queue<Field>();
            queue.Enqueue(aField);

            while (queue.Count > 0)
            {
                var field = queue.Dequeue();

                if (map[field.I, field.J] > 0) continue;

                if (map[field.I - 1, field.J] == null) queue.Enqueue(new Field(field.I - 1, field.J, field.V + 1));
                if (map[field.I, field.J + 1] == null) queue.Enqueue(new Field(field.I, field.J + 1, field.V + 1));
                if (map[field.I + 1, field.J] == null) queue.Enqueue(new Field(field.I + 1, field.J, field.V + 1));
                if (map[field.I, field.J - 1] == null) queue.Enqueue(new Field(field.I, field.J - 1, field.V + 1));

                if (map[field.I, field.J] == null) map[field.I, field.J] = field.V;

                if (field.Equals(bField))
                {
                    bField.V = field.V;
                    break;
                }
            }

            queue.Clear();

            #endregion

            #region Finding the right shortest path

            var list = new List<Field>();

            if (bField.V == null)
            {
                MessageBox.Show("There is now path from A to B");
            }
            else
            {
                queue.Enqueue(bField);
                while (true)
                {
                    var field = queue.Dequeue();

                    list.Add(field);

                    if (field.V == 0) break;

                    if (map[field.I - 1, field.J] == field.V - 1)
                    {
                        queue.Enqueue(new Field(field.I - 1, field.J, field.V - 1));
                        continue;
                    }

                    if (map[field.I, field.J + 1] == field.V - 1)
                    {
                        queue.Enqueue(new Field(field.I, field.J + 1, field.V - 1));
                        continue;
                    }

                    if (map[field.I + 1, field.J] == field.V - 1)
                    {
                        queue.Enqueue(new Field(field.I + 1, field.J, field.V - 1));
                        continue;
                    }

                    if (map[field.I, field.J - 1] == field.V - 1)
                    {
                        queue.Enqueue(new Field(field.I, field.J - 1, field.V - 1));
                        continue;
                    }

                }
            }

            #endregion

            #region Show map on the main window

            Map.Children.Clear();

            for (int i = 0; i < mapH; i++)
            {
                for (int j = 0; j < mapW; j++)
                {
                    Rectangle rect = new Rectangle
                    {
                        Width = 19,
                        Height = 19
                    };

                    Label label = new Label
                    {
                        Content = map[i, j],
                        FontSize = 16,
                        Foreground = Brushes.Red,
                        Padding = new Thickness(0)
                    };

                    Map.Children.Add(rect);
                    Canvas.SetTop(rect, i * 20);
                    Canvas.SetLeft(rect, j * 20);

                    if (map[i, j] == -1) rect.Fill = Brushes.Gray;
                    else
                    {
                        rect.Fill = Brushes.White;
                    }

                    if (map[i, j] >= 0)
                    {
                        Map.Children.Add(label);
                        Canvas.SetTop(label, i * 20);
                        Canvas.SetLeft(label, j * 20);
                    }

                    var field = list.SingleOrDefault(el => el.I == i && el.J == j);

                    if (field != null)
                    {
                        label.Foreground = Brushes.Green;
                        label.FontWeight = FontWeights.Bold;

                        if (field.Equals(bField)) label.Content = "B";
                    }


                }
            }

            #endregion
        }

        private void ZoomPlus_Click(object sender, RoutedEventArgs e)
        {
            CanvasTransform.ScaleX += 0.2;
            CanvasTransform.ScaleY += 0.2;
        }

        private void ZoomMinus_Click(object sender, RoutedEventArgs e)
        {
            CanvasTransform.ScaleX -= 0.2;
            CanvasTransform.ScaleY -= 0.2;
        }
    }

    /// <summary>
    /// Field on the Map
    /// </summary>
    public class Field : IEquatable<Field>
    {
        /// <summary>
        /// Field row
        /// </summary>
        private int _i;

        /// <summary>
        /// Field column
        /// </summary>
        private int _j;

        /// <summary>
        /// Field value
        /// </summary>
        private int? _v;

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

        public int? V
        {
            get { return _v; }
            set { _v = value; }
        }

        public Field(int i, int j, int? v)
        {
            I = i;
            J = j;
            V = v;
        }

        public bool Equals([AllowNull] Field other)
        {
            return I == other.I && J == other.J;
        }
    }
}
