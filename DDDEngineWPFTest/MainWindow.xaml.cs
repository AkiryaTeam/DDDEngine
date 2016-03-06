using System.Windows;
using Line = DDDEngine.Line;
using Point = DDDEngine.Point;

namespace DDDEngineWPFTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawLine();
        }

        private void DrawLine()
        {
            var p1 = new Point {X = 10, Y = 10, Z = 0};
            var p2 = new Point {X = 30, Y = 30, Z = 0};
            var line = new Line {Start = p1, End = p2};
            canvas.Children.Add(line);
        }
    }
}
