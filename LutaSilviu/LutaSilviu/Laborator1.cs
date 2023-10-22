using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGC
{
    internal class Laborator1 : GameWindow
    {
        private float x = 1.0f;
        public Laborator1() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
        }

        static void Main(string[] args)
        {
            using (Laborator1 example = new Laborator1())
            {


                example.Run(30.0, 0.0);
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);


        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Blue);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);


            DrawCube();

            SwapBuffers();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 100);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard[Key.D])
            {
                x++;
            }
            if (keyboard[Key.A])
            {
                x--;
            }
        }

        private void DrawCube()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Silver);
            GL.Vertex3(-x, -1.0f, -1.0f);
            GL.Vertex3(-x, 1.0f, -1.0f);
            GL.Vertex3(x, 1.0f, -1.0f);
            GL.Vertex3(x, -1.0f, -1.0f);

            GL.Color3(Color.Honeydew);
            GL.Vertex3(x, -1.0f, -1.0f);
            GL.Vertex3(x, -1.0f, -1.0f);
            GL.Vertex3(x, -1.0f, 1.0f);
            GL.Vertex3(-x, -1.0f, 1.0f);

            GL.Color3(Color.Moccasin);

            GL.Vertex3(-x, -1.0f, -1.0f);
            GL.Vertex3(-x, -1.0f, 1.0f);
            GL.Vertex3(-x, 1.0f, 1.0f);
            GL.Vertex3(-x, 1.0f, -1.0f);

            GL.Color3(Color.IndianRed);
            GL.Vertex3(-x, -1.0f, 1.0f);
            GL.Vertex3(x, -1.0f, 1.0f);
            GL.Vertex3(x, 1.0f, 1.0f);
            GL.Vertex3(-x, 1.0f, 1.0f);

            GL.Color3(Color.PaleVioletRed);
            GL.Vertex3(-x, 1.0f, -1.0f);
            GL.Vertex3(-x, 1.0f, 1.0f);
            GL.Vertex3(x, 1.0f, 1.0f);
            GL.Vertex3(x, 1.0f, -1.0f);

            GL.Color3(Color.ForestGreen);
            GL.Vertex3(x, -1.0f, -1.0f);
            GL.Vertex3(x, 1.0f, -1.0f);
            GL.Vertex3(x, 1.0f, 1.0f);
            GL.Vertex3(x, -1.0f, 1.0f);

            GL.End();
        }

    }
}
