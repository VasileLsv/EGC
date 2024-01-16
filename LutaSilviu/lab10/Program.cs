
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

namespace lab10
{
    internal class Program : GameWindow
    {
        Cub3D cub;
        Cub3D cub2;
        Cub3D cub3;
        KeyboardState previusKey;
        bool animate=false;
        private float angle = 0.0f;
        private float angle1 = 0.0f;
        private float radius = 10f;
        Program(): base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
    
            cub = new Cub3D(1, Color.Red);
            cub2=new Cub3D(2, Color.Yellow);
            cub3 = new Cub3D(10,1,1,0.5f,Color.Gray);


        }

        static void Main(string[] args)
        {
            using (Program laborator = new Program())
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

            Matrix4 lookat = Matrix4.LookAt(50, 50, 50, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            float xPlaneta;
            float yPlaneta;
            
            GL.PushMatrix();
           
                xPlaneta = radius * (float)Math.Cos(angle);
                yPlaneta = radius * (float)Math.Sin(angle);
                GL.Translate(xPlaneta, yPlaneta, 0);
                cub.DrawCube();
            
           
            GL.PopMatrix();


            GL.PushMatrix();
           
                float x = 5 * (float)Math.Cos(angle1);
                float y = 5 * (float)Math.Sin(angle1);
                cub3.setXYZ(xPlaneta, yPlaneta, 0);
                GL.Translate(x, y, 0);
                cub3.DrawCube();
            
           
            GL.PopMatrix();

            cub2.DrawCube();
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
            if (keyboard[Key.A] && !previusKey[Key.A]) {
                animate = !animate;
            }

            float deltaTime = (float)e.Time;
       
            angle += deltaTime;
            angle1 += deltaTime*2;
            previusKey = keyboard;
        }
    }
}
