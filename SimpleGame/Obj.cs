using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace SimpleGame
{
    class Obj
    {
        public int width = new int();
        public int height = new int();

        public float r = new float();
        public float g = new float();
        public float b = new float();

        public Position pos;

        public Obj(int width,int height,int x, int y,float r, float g, float b)
        {
            this.pos = new Position(x, y);

            this.width = width;
            this.height = height;
            this.r = r;
            this.g = g;
            this.b = b;

        }

        public void Draw()
        {
            GL.Color3(r,g,b);

            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(-0.5f * width + pos.x,-0.5f * height + pos.y);
            GL.Vertex2(0.5f * width + pos.x, -0.5f * height + pos.y);
            GL.Vertex2(0.5f * width + pos.x, 0.5f * height + pos.y);
            GL.Vertex2(-0.5f * width + pos.x, 0.5f * height + pos.y);
            GL.End();

        }

        
    }
}
