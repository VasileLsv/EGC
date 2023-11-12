using Laborator3;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator4
{
    internal class Laborator4:GameWindow
    {
        Cub3D cub;
        KeyboardState previusKey;
        Randomizer randomizer;
        Laborator4()
        {
            randomizer = new Randomizer();
            cub=new Cub3D(randomizer);


        }

        static void Main(string[] args)
        {
            using (Laborator4 laborator = new Laborator4())
            {
                laborator.Run(30, 0.0);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.LightBlue);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

            GL.Enable(EnableCap.DepthTest);

            GL.DepthFunc(DepthFunction.Less);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            //creez perspectiva

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Width / (float)Height, 1, 256);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            //creez camera

            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            cub.DrawCube();

            SwapBuffers();
        }


        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = new MouseState();

            if (keyboard[Key.Escape])
            {
                Exit();
            }
            if (keyboard[Key.B] && !previusKey[Key.B])
            {
                cub.setB(randomizer.getRandomPositiveInt(256));
            }
            if (keyboard[Key.A] && !previusKey[Key.A])
            {
                cub.setA(randomizer.getRandomPositiveInt(256));
            }
            if (keyboard[Key.G] && !previusKey[Key.G])
            {
                cub.setG(randomizer.getRandomPositiveInt(256));
            }
            if (keyboard[Key.R] && !previusKey[Key.R])
            {
                cub.setR(randomizer.getRandomPositiveInt(256));
            }
            if (keyboard[Key.V] && !previusKey[Key.V])
            {
                cub.changeVertex();
            }

            previusKey = keyboard;
        }
    }
}
