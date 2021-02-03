using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace SimpleGame
{
    class Player:Obj
    {

        
        public int vel = new int();
        public int point = 5;
        public Player(int width, int height, int x, int y, float r, float g, float b) : base(width, height, x, y, r, g, b)
        {
            this.vel = 5;

            
        }

        public void Update()
        {
            Draw();
            Move();
            
        }

        void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Key.Up))
            {
                pos.y += vel;
            }
            if (Keyboard.GetState().IsKeyDown(Key.Right))
            {
                pos.x += vel;
            }
            if (Keyboard.GetState().IsKeyDown(Key.Down))
            {
                pos.y -= vel;
            }
            if (Keyboard.GetState().IsKeyDown(Key.Left))
            {
                pos.x -= vel;
            }
        }

        public void grow()
        {
            width += point;
            height += point;
        }

        public void decrease()
        {
            width -= point;
            height -= point;
        }
    }
}
