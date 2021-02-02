using System;
using OpenTK;

namespace SimpleGame
{
    class Fruit:Obj
    {
        public int velx = new int();
        public int vely = new int();
        public Fruit(int width,int height,int x, int y, float r, float g, float b) : base(width, height, x, y, r, g, b)
        {
            this.velx = 3;
            this.vely = 3;

            
        }

        public void Update(GameWindow window)
        {
            Draw();
            Move();
            WallCollision(window);
        }

        void WallCollision(GameWindow window)
        { 
            if (pos.x >= window.Width/2 || pos.x <= -window.Width/2)
            {
                velx = -velx;
            }
            if (pos.y >= window.Height/2 || pos.y <= -window.Height/2)
            {
                vely = -vely;
            }
        }

        void Move()
        {
            pos.x += velx;
            pos.y += vely;
        }

        public void randPos(GameWindow window)
        {
            Random aux = new Random();
            pos.x = aux.Next(-window.Width / 2 + width / 2, window.Width / 2 - width / 2);
            pos.y = aux.Next(-window.Height / 2 + height / 2, window.Height / 2 - height / 2);
        }
    }
}
