
using OpenTK.Graphics.OpenGL;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    internal class Cub3D
    {
       public float x,y, z,size;
        Color color;
        public Cub3D(float size, Color color)
        {
            x = y = z = 1;
            this.size = size;
            this.color = color;
        }

        public Cub3D() {
            x = y = z = 1;
            size = 1;
            this.color = Color.Gray;

        }

        public Cub3D(float x, float y, float z, float size,Color color) 
        {
            this.color = color;

            this.x = x;
            this.y = y;
            this.z = z;
            this.size = size;
        }
        public void setXYZ(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public void DrawCube()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(color);
            GL.Vertex3(x - size , y - size, z - size);
            GL.Vertex3(x - size , y + size, z - size);
            GL.Vertex3(x + size, y + size, z - size);
            GL.Vertex3(x + size, y - size, z - size);

            GL.Color3(color);
            GL.Vertex3(x + size, y-size, z - size);
            GL.Vertex3(x + size, y-size, z - size);
            GL.Vertex3(x + size, y - size, z + size);
            GL.Vertex3(x-size, y - size, z + size);

            GL.Color3(color);
            GL.Vertex3(x-size, y - size, z - size);
            GL.Vertex3(x - size, y - size, z + size);
            GL.Vertex3(x - size, y + size, z + size);
            GL.Vertex3(x - size, y + size, z - size);

            GL.Color3(color);
            GL.Vertex3(x-size, y - size, z + size);
            GL.Vertex3(x + size, y - size, z + size);
            GL.Vertex3(x + size, y + size, z + size);
            GL.Vertex3(x - size, y + size, z + size);

            GL.Color3(color);
            GL.Vertex3(x - size, y + size, z - size);
            GL.Vertex3(x - size, y + size, z + size);
            GL.Vertex3(x + size, y + size, z + size);
            GL.Vertex3(x + size, y + size, z - size);

            GL.Color3(color);
            GL.Vertex3(x + size, y - size, z - size);
            GL.Vertex3(x + size, y + size, z - size);
            GL.Vertex3(x + size, y + size, z + size);
            GL.Vertex3(x + size, y - size, z + size);
            
            GL.End();
        }

      
    }
}
