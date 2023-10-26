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
using System.Xml.Linq;




/*
* Luta Silviu Vasilica,3131b
*
* 22.10.2023
*
* Se rezolva laboratorul 2
* se creeaza un cub,si se controleaza cu ajutorul tastelor a,d,w,s
*
* daca apesi pe butonul stanga al mouse vei controla cu mouse
*
 */


namespace EGC
{
    internal class Laborator1 : GameWindow
    {
        private float x = 1.0f;
        private float y = 1.0f;
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
            MouseState mouseState = Mouse.GetState();
            if (mouseState[MouseButton.Left])
                if (mouseState.X != e.X || mouseState.Y != e.Y)
                {

                    x = (2.0f * mouseState.X / Width) - 1.0f;
                    y = 1.0f - (2.0f * mouseState.Y / Height);


                }
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
            //Verificam ce tasta am apasat,si vom modifica x in functie de nevoie
            if (keyboard[Key.D])
            {
                x++;

            }
            if (keyboard[Key.A])
            {
                x--;
            }

            if (keyboard[Key.W])
            {
                y++;
            }
            if (keyboard[Key.S])
            {
                y--;
            }
            Console.WriteLine(x);

        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            //  Console.WriteLine(e.X);
        }

        private void DrawCube()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Silver);
            GL.Vertex3(x - 2, y - 2, -1.0f);
            GL.Vertex3(x - 2, y, -1.0f);
            GL.Vertex3(x, y, -1.0f);
            GL.Vertex3(x, y - 2, -1.0f);
            /*
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
                        GL.Vertex3(-x , 1.0f, -1.0f);
                        GL.Vertex3(-x, 1.0f, 1.0f);
                        GL.Vertex3(x, 1.0f, 1.0f);
                        GL.Vertex3(x, 1.0f, -1.0f);

                        GL.Color3(Color.ForestGreen);
                        GL.Vertex3(x, -1.0f, -1.0f);
                        GL.Vertex3(x, 1.0f, -1.0f);
                        GL.Vertex3(x, 1.0f, 1.0f);
                        GL.Vertex3(x, -1.0f, 1.0f);
                        */
            GL.End();
        }


    }
}
