using System;
using OpenTK;

namespace SimpleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(600, 500);
            Game game = new Game(window);
        }
    }
}
