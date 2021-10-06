using System;
namespace Derby
{
    public class Game
    {
        public Car Player { get; set; }
        public Car Opponent { get; set; }
        public Car Opponent2 { get; set; }

        public void Run()
        {
            DrawMap(78, 23);

            Player = new Car(300);
            Player.StartEngine();
            Player.IsPlayer = true;
            Player.Display();
            
            Opponent = new Car(300);
            Opponent.StartEngine();
            Opponent.Display();

            Opponent2 = new Car(300);
            Opponent2.StartEngine();
            Opponent2.Display();
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
