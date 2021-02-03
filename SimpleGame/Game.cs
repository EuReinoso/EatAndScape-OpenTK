using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;

namespace SimpleGame
{
    class Game
    {
        GameWindow window;

        Player player = new Player(15, 15, 30, 45, 255, 255, 255);
        public Enemy enemy = new Enemy(60, 60, 0,0,255,0,0);
        public Fruit fruit = new Fruit(15, 15, -4, 10, 0, 255, 0);
        public int vezes = 1;
        public Game(GameWindow window)
        {
            this.window = window;
            
            Start();
        }

        void Start()
        {
            window.Load += Window_Load;
            window.Resize += Window_Resize;
            window.RenderFrame += Window_RenderFrame;
            window.UpdateFrame += Window_UpdateFrame;
            
            window.Run(15);
        }

        private void Window_UpdateFrame(object sender, FrameEventArgs e)
        {
            playerGrow();
            playerDecrease();
            
        }

        private void Window_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0.0f,0.0f,0.0f,0.0f);
        }

        private void Window_RenderFrame(object sender, FrameEventArgs e)
        {
            
            GL.Clear(ClearBufferMask.ColorBufferBit);

            fruit.Update(window);
            player.Update();
            enemy.Update(window);

            window.SwapBuffers();
        }
        private void Window_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-window.Width/2,window.Width/2,-window.Height/2,window.Height/2,-1.0,1.0);
            GL.MatrixMode(MatrixMode.Modelview);
        }
       
        bool collision(Obj obj1, Obj obj2)
        {
            int left1 = obj1.pos.x - obj1.width/2;
            int left2 = obj2.pos.x - obj2.width / 2;

            int up1 = obj1.pos.y + obj1.height / 2;
            int up2 = obj2.pos.y + obj2.height / 2;

            int right1 = obj1.pos.x + obj1.width / 2;
            int right2 = obj2.pos.x + obj2.width / 2;

            int down1 = obj1.pos.y - obj1.height / 2;
            int down2 = obj2.pos.y - obj2.height / 2;

            
            if (right1 >= left2 && right1 <= right2)
            {
                if (up1 >= down2 && down1 <= up2) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(left1 <= right2 && left1 >= left2)
            {
                if (up1 >= down2 && down1 <= up2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            else if (right2 >= left1 && right2 <= right1)
            {
                if (up2 >= down1 && down2 <= up1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (left2 <= right1 && left2 >= left1)
            {
                if (up2 >= down1 && down2 <= up1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
          

        }

        void playerGrow()
        {
            if (collision(player,fruit))
            {
                player.grow();
                fruit.randPos(window);
            }
        }

        void playerDecrease()
        {
            if (collision(player, enemy))
            {
                player.decrease();
            }
        }
    }
}
