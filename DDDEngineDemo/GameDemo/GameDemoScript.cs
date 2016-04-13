using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using DDDEngine.Configuration;
using DDDEngine.Game;
using DDDEngine.Model;
using DDDEngine.Physics;
using DDDEngine.View;
using DDDEngine.World;
using Point3D = DDDEngine.Model.Point3D;

namespace DDDEngineDemo.GameDemo
{
    public class GameDemoScript: GameScript
    {
        private readonly Label _label;

        private readonly RigidBody _plane;
        private readonly RigidBody _basket;

        private int _gamePoints;
        private RigidBody _body;
        private const int WinPoints = 10;
        private const int LosePoints = -10;

        public GameDemoScript(Window context, Canvas canvas) : base(context)
        {
            _label = (Label) Config.Get("Label");

            var camera = new RigidBody(new PerspectiveCamera(canvas), new Position(new Point3D(0, 0, 1500)), Behaviour.Static);
            _plane = new RigidBody(new Plane(1000, 1000), new Position(new Point3D(0, -400, 0)), Behaviour.Static);
            _basket = new RigidBody(new Parallelepiped(200, 20, 200), new Position(new Point3D(0, -370, 0)), Behaviour.Static);
            World = new World3D();
            World.AddCamera(camera);
            World.AddBody(_plane);
            World.AddBody(_basket);

            World.PhysicsProcessor.Subscribe(new CollisionObserver(this));

            CreateObject();
        }

        public override void Action(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Thread.Sleep(10);
        }

        public void CreateObject()
        {
            var r = new Random();
            World.RemoveBody(_body);
            _body = new RigidBody(new Tetrahedron(100), new Position(new Point3D(r.Next(-500, 500), r.Next(-300, 900), r.Next(-500, 500))), Behaviour.Dynamic);
            World.AddBody(_body);
        }

        public void CollisionDetected(Collision collision)
        {
            if (collision.One == _basket || collision.Two == _basket)
            {
                if(collision.One == _basket) World.RemoveBody(collision.Two);
                else if(collision.Two == _basket) World.RemoveBody(collision.One);
                _gamePoints++;
            }
            else if (collision.One == _plane || collision.Two == _plane)
            {
                if(collision.One == _plane) World.RemoveBody(collision.Two);
                else if(collision.Two == _plane) World.RemoveBody(collision.One);
                _gamePoints--;
            }
            Update();
        }

        private void Update()
        {
            _label.Content = _gamePoints.ToString();
            if (_gamePoints >= WinPoints) Win();
            else if (_gamePoints <= LosePoints) Lose();
            else CreateObject();
        }

        private void Win()
        {
            MessageBox.Show("Win!");
        }

        private void Lose()
        {
            MessageBox.Show("Lose!");
        }

        public void MoveBasket(Point2D start, Point2D end)
        {
            var point = end.Substract(start);
            _basket.Position.Point.X += point.X + Sign(point.X)*2;
            _basket.Position.Point.Z -= point.Y + Sign(point.Y)*2;
        }

        private int Sign(double n)
        {
            return (int) (n/Math.Abs(n));
        }
    }
}