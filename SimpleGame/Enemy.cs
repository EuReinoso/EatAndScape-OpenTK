using System;
using OpenTK;

namespace SimpleGame
{
    class Enemy:Obj
    {
        Random rand = new Random();

        public int velx = new int();
        public int vely = new int();
        public Enemy(int width, int height, int x, int y, float r, float g, float b) : base(width, height, x, y, r, g, b)
        {
            this.velx = 5;
            this.vely = 5;

            this.pos.x = rand.Next(-200, 200);
            this.pos.y = rand.Next(-200, 200);

        }
        public void Update(GameWindow window)
        {
            Draw();
            Move();
            WallCollision(window);
        }

        void WallCollision(GameWindow window)
        {
            if (pos.x >= window.Width / 2 - width/2|| pos.x <= -window.Width / 2 + width/2)
            {
                velx = -velx;
            }
            if (pos.y >= window.Height / 2 - height/2 || pos.y <= -window.Height / 2 + height/2)
            {
                vely = -vely;
            }
        }

        void Move()
        {
            pos.x += velx;
            pos.y += vely;
        }
    }
}
