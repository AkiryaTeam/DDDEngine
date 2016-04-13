using System.Windows.Input;
using DDDEngineDemo.GameDemo;
using DDDEngineDemo.PhysicsDemo;

namespace DDDEngineDemo
{
    internal enum State { Game, Stop }

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Demo(object sender, MouseButtonEventArgs e)
        {
            var demoWindow = new ModelsDemoWindow();
            demoWindow.ShowDialog();
        }

        private void CubeTransformationDemo(object sender, MouseButtonEventArgs e)
        {
            var cubeTransformationDemoWindow = new CubeTransformationDemoWindow();
            cubeTransformationDemoWindow.ShowDialog();
        }

        private void PhysicsDemo(object sender, MouseButtonEventArgs e)
        {
            var physicsDemoWindow = new PhysicsDemoWindow();
            physicsDemoWindow.ShowDialog();
        }

        private void GameDemo(object sender, MouseButtonEventArgs e)
        {
            var gameDemoWindow = new GameDemoWindow();
            gameDemoWindow.ShowDialog();
        }
    }
}
