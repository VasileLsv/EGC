using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator3
{


    /*
     Clasa Triunghi va genera un triunghi,si va oferi posibilitatea
     de a putea schimba culoarea acestuia folosindu-se de clasa Randomizer  
     */
    internal class Triangle3D
    {
        Color color;
        
        List<Color> colors;
        List<Vector3> coordonate;
        Randomizer ran;
        public Triangle3D(Randomizer ran)
        {

            coordonate = new List<Vector3>();
            colors = new List<Color>();

            color = ran.generateRandomColor();
            this.ran = ran;
            colors.Add(color);
            colors.Add(color);
            colors.Add(color);

            printRGB();

            StreamReader stream = new StreamReader("coord.txt");
            string line;
            while ((line = stream.ReadLine()) != null)
            {

                string[] strings = line.Split(',');
                float x, y, z;
                x = float.Parse(strings[0]);
                y = float.Parse(strings[1]);
                z = float.Parse(strings[2]);

                coordonate.Add(new Vector3(x, y, z));
            }

        }

        private void printRGB()
        {
            foreach (Color c in colors)
            {
                Console.WriteLine("R:" + c.R + ",G:" + c.G + ",B:" + c.B);

            }
            Console.WriteLine();
        }

        /// <summary>
        /// DrawTriangle va desena triunghiul cu ajutorul coordonatelor din fisierul coord.txt aflat in
        /// folderul debug din Laborator3
        /// </summary>


        public void DrawTriangle()
        {
            GL.Begin(PrimitiveType.Triangles);
          
            for (int i=0;i<3;i++)
            {
                GL.Color3(colors[i]);
                GL.Vertex3(coordonate[i]);
                
            }
            
           GL.End();
        }

        /// <summary>
        /// functia va inlocui culorile vertexurilor cu o culoare unica primita ca parametru
        /// </summary>
        /// <param name="color"></param>
        public void regenColor(Color color) {

            colors.Clear();
            colors.Add(color);
            colors.Add(color);
            colors.Add(color);
            printRGB();
        }

        /// <summary>
        /// functia va renera culori random pentru fiecare vertex
        /// </summary>
        public void regenerateRandomColors() {

            colors.Clear();
            colors.Add(ran.generateRandomColor());
            colors.Add(ran.generateRandomColor());
            colors.Add(ran.generateRandomColor());
            printRGB();
        }
        public void setR(int r) {
            color = Color.FromArgb(color.A, r, color.G, color.B);
            colors.Clear();
            colors.Add(color);
            colors.Add(color);
            colors.Add(color);
            printRGB();
        }
        public void setG(int g)
        {
            color = Color.FromArgb(color.A, color.R, g, color.B);
            colors.Clear();
            colors.Add(color);
            colors.Add(color);
            colors.Add(color);
            printRGB();
        }
        public void setB(int b)
        {
            color = Color.FromArgb(color.A, color.R, color.G, b);
            colors.Clear();
            colors.Add(color);
            colors.Add(color);
            colors.Add(color);
            printRGB();
        }
        public void setA(int a)
        {
            color = Color.FromArgb(a,color.R, color.G, color.B);
            colors.Clear();
            colors.Add(color);
            colors.Add(color);
            colors.Add(color);
            printRGB();
        }
    }
}
