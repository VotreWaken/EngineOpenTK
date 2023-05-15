using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using Program;
using System.Drawing;
using System.Reflection.Metadata;
using System.Threading;

namespace Tests
{

    internal static class Program
    {
        private static void Main()
        {
            var game = new Game(1000, 1000, "Test", 60.0);
            game.Render3DObjects();
            //game.OpenObj("cube.obj", Color4.AliceBlue);
            //game.CreateCube(Color4.AliceBlue, 100, 100, 5);
            game.Run();
            
        }
    }

    public class Game : MainRenderWindow
    {
        public Game(int width, int height, string title, double FPS) : base(width, height, title, FPS)
        {
        }

        protected override void OnLoad()
        {
            CenterWindow();
            SetClearColor(new Color4(1.0f, 1.0f, 1.0f, 1.0f)); //Sets Background Color
            UseDepthTest = true; //Enables Depth Testing for 3D
            UseAlpha = true; //Enables alpha use
            KeyboardAndMouseInput = false; //Enables keyboard and mouse input for 3D movement
            base.OnLoad();
            //a = OpenObj("sphere-lowpoly.obj", Color4.Red);
            
            a = OpenTexturedObj("CubeSize.obj", "crate_1.jpg");
        }
        int a;
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            Clear();
            //fill(0f, 0.3f, 0.7f, 0.7f);
            //stroke(0f, 0f, 0f, 1f);
            //strokeWeight(1);
            RotateObjectNew();
            Render3DObjects();
            base.OnRenderFrame(e);
        }
        float x = 0;
        void RotateObjectNew()
        {

            RotateTexturedObject(x, x, x, a);
            x += 0.01f;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            Title = $"Test app, FPS: {1 / e.Time}";
            base.OnUpdateFrame(e);
        }
    }
}