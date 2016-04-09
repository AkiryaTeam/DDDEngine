using System.Windows.Input;

namespace DDDEngineDemo
{
    internal enum State { Game, Stop }

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CubeDemo(object sender, MouseButtonEventArgs e)
        {
            var cubeDemoWindow = new CubeDemoWindow();
            cubeDemoWindow.ShowDialog();
        }

        private void CubeTransformationDemo(object sender, MouseButtonEventArgs e)
        {
            var cubeTransformationDemoWindow = new CubeTransformationDemoWindow();
            cubeTransformationDemoWindow.ShowDialog();
        }
    }
}
