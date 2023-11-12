using Laborator3;

using OpenTK.Graphics.OpenGL;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator4
{
    internal class Cub3D
    {
        Randomizer ran;
        Color color;
        VertexPoint A, B, C,D;
        public Cub3D(Randomizer ran)
        {
            this.ran = ran;
            color = Color.Silver;
            A = new VertexPoint(5, -5, -5, Color.DeepPink);
            B = new VertexPoint(5, 5, -5, Color.DeepPink);
            C = new VertexPoint(5, 5, 5, Color.DeepPink);
            D = new VertexPoint(5, -5, 5, Color.DeepPink);
        }
     

        public void DrawCube()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.ForestGreen);
            GL.Vertex3(-5.0f , -5.0f, -5.0f);
            GL.Vertex3(-5.0f , 5.0f, -5.0f);
            GL.Vertex3(5.0f, 5.0f, -5.0f);
            GL.Vertex3(5.0f, -5.0f, -5.0f);

            GL.Color3(Color.Honeydew);
            GL.Vertex3(5.0f, -5.0f, -5.0f);
            GL.Vertex3(5.0f, -5.0f, -5.0f);
            GL.Vertex3(5.0f, -5.0f, 5.0f);
            GL.Vertex3(-5.0f, -5.0f, 5.0f);

            GL.Color3(Color.Moccasin);
            GL.Vertex3(-5.0f, -5.0f, -5.0f);
            GL.Vertex3(-5.0f, -5.0f, 5.0f);
            GL.Vertex3(-5.0f, 5.0f, 5.0f);
            GL.Vertex3(-5.0f, 5.0f, -5.0f);

            GL.Color3(Color.IndianRed);
            GL.Vertex3(-5.0f, -5.0f, 5.0f);
            GL.Vertex3(5.0f, -5.0f, 5.0f);
            GL.Vertex3(5.0f, 5.0f, 5.0f);
            GL.Vertex3(-5.0f, 5.0f, 5.0f);

            GL.Color3(color);
            GL.Vertex3(-5.0f, 5.0f, -5.0f);
            GL.Vertex3(-5.0f, 5.0f, 5.0f);
            GL.Vertex3(5.0f, 5.0f, 5.0f);
            GL.Vertex3(5.0f, 5.0f, -5.0f);

            GL.Color3(Color.Blue);
            GL.Vertex3(A.coordX, A.coordY, A.coordY);
            GL.Vertex3(B.coordX, B.coordY, B.coordZ);
            GL.Vertex3(C.coordX, C.coordY, C.coordZ);
            GL.Vertex3(D.coordX, D.coordY, D.coordZ);
            
            GL.End();
        }


        public void setR(int r)
        {
            color = Color.FromArgb(color.A, r, color.G, color.B);
          

        }
        public void setG(int g)
        {
            color = Color.FromArgb(color.A, color.R, g, color.B);
            
           
        }
        public void setB(int b)
        {
            color = Color.FromArgb(color.A, color.R, color.G, b);
            
        }
        public void setA(int a)
        {
            color = Color.FromArgb(a, color.R, color.G, color.B);
            
        }

        public void changeVertex()
        {
            A.SetColor(ran.generateRandomColor());
            B.SetColor(ran.generateRandomColor());
            C.SetColor(ran.generateRandomColor());

        }
    }
}
