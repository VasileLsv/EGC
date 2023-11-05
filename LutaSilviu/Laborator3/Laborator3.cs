using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator3
{/*
* Luta Silviu Vasilica,3131b
*
* 5.11.2023
*
* Se rezolva laboratorul 3
* se creeaza un triunghi,si se modifica culoarea
*
* 
*
 */
    internal class Laborator3 :GameWindow
    {
        KeyboardState previusKey;
        Triangle3D triangle;
        Randomizer randomizer;
        Vector2 previousMousePosition;

        public Laborator3() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            randomizer=new Randomizer();
            triangle = new Triangle3D(randomizer);
            displayHelp();
           

        }
        static void Main(string[] args)
        {
            using(Laborator3 laborator = new Laborator3())
            {
                laborator.Run(30,0.0);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.LightBlue);

            GL.Hint(HintTarget.PolygonSmoothHint,HintMode.Nicest);

            GL.Enable(EnableCap.DepthTest);

            GL.DepthFunc(DepthFunction.Less);

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //setez viewport
            GL.Viewport(0, 0, Width, Height);

            //creez perspectiva

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4,(float)Width/(float)Height,1,256);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            //creez camera

            Matrix4 lookat = Matrix4.LookAt(30,30,30,0 ,0 ,0,0,1,0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            triangle.DrawTriangle();

            SwapBuffers();
        }

     

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            //logica
            KeyboardState keyboard =  Keyboard.GetState();
            MouseState mouse = new MouseState();
         

            if (keyboard[Key.Escape])
            {         
                Exit();
            }
            if (keyboard[Key.C] && !previusKey[Key.C])
            {
                triangle.regenColor(randomizer.generateRandomColor());
            }
            if (keyboard[Key.B] && !previusKey[Key.B])
            {
                triangle.setB(randomizer.getRandomPositiveInt(256));
            }
            if (keyboard[Key.A] && !previusKey[Key.A])
            {
                triangle.setA(randomizer.getRandomPositiveInt(256));
            }
            if (keyboard[Key.G] && !previusKey[Key.G])
            {
                triangle.setG(randomizer.getRandomPositiveInt(256));
            }
            if (keyboard[Key.R] && !previusKey[Key.R])
            {
                triangle.setR(randomizer.getRandomPositiveInt(256));
            }
            if (keyboard[Key.H] && !previusKey[Key.H])
            {
                displayHelp();
            }
            // salvez ultima apasare a tastaturii
            if (keyboard[Key.P] && !previusKey[Key.P])
            {
                triangle.regenerateRandomColors(); 
            }
          


            previusKey = keyboard;

        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);
            /*
        //    if (e.Mouse.LeftButton == ButtonState.Pressed)
         //   {
                Vector2 currentMousePosition = new Vector2(e.X, e.Y);
                Vector2 mouseDelta = currentMousePosition - lastMousePosition;


                Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0+mouseDelta.X, 0 + mouseDelta.Y, 0, 0, 1, 0);

                // Aplică matricea de vedere a camerei
                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadMatrix(ref lookat);

                // Actualizează ultima poziție a mouse-ului
                lastMousePosition = currentMousePosition;
         //   }
            */
        }

        private void displayHelp()
        {
            Console.WriteLine("       Meniu");
            Console.WriteLine(" Esc - Inchide program");
            Console.WriteLine( " C - Schimba culoare triunghi");
            Console.WriteLine(" H - Afiseaza meniu");
            Console.WriteLine(" R - Schimba culoare canal R triunghi");
            Console.WriteLine(" G - Schimba culoare canal G triunghi");
            Console.WriteLine(" B - Schimba culoare canal B triunghi");
            Console.WriteLine(" A - Schimba culoare canal Alpha triunghi");
            Console.WriteLine(" P - Schimba culoarile pentru fiecare Vertex");
        }
    }
}
