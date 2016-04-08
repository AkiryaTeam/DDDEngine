using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using DDDEngine.Camera;
using DDDEngine.Model;
using DDDEngine.Model.LineDrawingStrategy;
using DDDEngine.World;
using Line = DDDEngine.Model.Line;

namespace DDDEngineWPFTest
{
    public partial class MainWindow : Window
    {
        private readonly Camera _camera;
        private readonly World _world;
        private readonly LineFactory _lineFactory;

        public MainWindow()
        {
            InitializeComponent();
            _camera = new OrthographicCamera();
            _world = new World(_camera);
            var lineDrawingStrategy = new DefaultLineDrawingStrategy();
            _lineFactory = new LineFactory(lineDrawingStrategy);

            var lines = CreateLines();
            lines.ForEach(line => _world.AddObject(line, new Point3D(0, 0, 0)));
        }

        private List<Line> CreateLines()
        {
            var p1 = new Point3D(0, 0, 0);
            var p2 = new Point3D(40, 0, 0);
            var p3 = new Point3D(40, 0, 40);
            var p4 = new Point3D(0, 0, 40);
            var p5 = new Point3D(0, 40, 0);
            var p6 = new Point3D(40, 40, 0);
            var p7 = new Point3D(40, 40, 40);
            var p8 = new Point3D(0, 40, 40);
            var lines = new List<Line>
            {
                _lineFactory.Create(p1, p2),
                _lineFactory.Create(p2, p3),
                _lineFactory.Create(p3, p4),
                _lineFactory.Create(p4, p1),
                _lineFactory.Create(p5, p6),
                _lineFactory.Create(p6, p7),
                _lineFactory.Create(p7, p8),
                _lineFactory.Create(p8, p5),
                _lineFactory.Create(p1, p5),
                _lineFactory.Create(p2, p6),
                _lineFactory.Create(p3, p7),
                _lineFactory.Create(p4, p8)
            };
            return lines;
        }

        private void DrawWorld()
        {
            _world.Draw(canvas);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    for (var i = 0; i < 999999; ++i)
                    {
                        _camera.AngleY = i%360;
                        _camera.AngleX = i%360;
                        _camera.AngleZ = i%360;
                        Dispatcher.Invoke(DrawWorld);
                        Thread.Sleep(10);
                    }
                }
                catch (TaskCanceledException)
                {
                    //ignore
                }
            });
        }
    }
}
