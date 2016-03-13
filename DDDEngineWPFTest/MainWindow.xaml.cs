using System.Windows;
using DDDEngine.Camera;
using Line = DDDEngine.Object.Line;
using Point = DDDEngine.Object.Point;

namespace DDDEngineWPFTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var camera = new Camera();
            DrawPoint(camera);
            DrawLine(camera);
        }

        private void DrawPoint(Camera camera)
        {
            var point = new Point {X = 50, Y = 10, Z = 0};
            point.Draw(canvas, camera);
        }

        private void DrawLine(Camera camera)
        {
            var line = new Line
            {
                Start = new Point {X = 100, Y = 20, Z = 0},
                End = new Point {X = 100, Y = 200, Z = 0}
            };
            line.Draw(canvas, camera);
        }
    }
}
