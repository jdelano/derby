using System;
namespace Derby
{
    public class Game
    {
        public Car Player { get; set; }

        public void Run()
        {
            DrawMap(78, 23);
            //Player = new Car(14.1);
            //Player.StartEngine();
            //Player.TurnRight();
        }

        public void DrawMap(int width, int height)
        {
            for (int rowsPrinted = 1; rowsPrinted <= height; rowsPrinted++)
            {
                for (int columnsPrinted = 1; columnsPrinted <= width; columnsPrinted++)
                {
                    if (rowsPrinted == 1 || rowsPrinted == height ||
                        columnsPrinted == 1 || columnsPrinted == width - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");

                    }
                }
                Console.WriteLine();
            }
        }
        
    }
}
