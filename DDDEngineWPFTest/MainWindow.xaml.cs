using System.Windows;
using System.Windows.Documents;
using DDDEngine.Camera;
using DDDEngine.Object;
using Line = DDDEngine.Object.Line;

namespace DDDEngineWPFTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var camera = new Camera(Camera.Type.Orthographic);
            DrawPoint(camera);
            Draw2DLine(camera);
            Draw3DLine(camera);
        }

        private void Draw3DLine(Camera camera)
        {
            var line = new Line(new Point3D(200, 200, 0), new Point3D(200, 250, 100));
            line.Draw(canvas, camera);
        }

        private void DrawPoint(Camera camera)
        {
            var point = new Point3D {X = 50, Y = 10, Z = 0};
            point.Draw(canvas, camera);
        }

        private void Draw2DLine(Camera camera)
        {
            var line = new Line
            {
                Start = new Point3D {X = 100, Y = 20, Z = 0},
                End = new Point3D {X = 100, Y = 200, Z = 0}
            };
            line.Draw(canvas, camera);
        }

    }
}
