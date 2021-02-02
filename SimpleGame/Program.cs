using System;
using OpenTK;

namespace SimpleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(500, 300);
            Game game = new Game(window);
        }
    }
}
