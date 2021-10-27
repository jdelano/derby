using System;
namespace Derby
{
    public class Game
    {
        private bool isPlaying = true;

        public Car Player { get; set; }
        public Car[] Opponents { get; set; }

        public void Run()
        {
            InitializeGame();
            do
            {
                ProcessInput();
                UpdateGame();
                RenderOutput();
            } while (isPlaying);
        }

        private void RenderOutput()
        {
            if (invalidated)
            {
                Console.Clear();
                DrawMap(79, 24);
                Player.Display();
                for (int i = 0; i < Opponents.Length; i++)
                {
                    Opponents[i].Display();

                }
                invalidated = false;
            }
        }

        private DateTime gameTime = DateTime.Now;
        private void UpdateGame()
        {
            int updateInterval = 250; // 1/2 a second
            if (DateTime.Now.Subtract(gameTime) >
                TimeSpan.FromMilliseconds(updateInterval))
            {
                for (int i = 0; i < Opponents.Length; i++)
                {
                    Opponents[i].MakeRandomMovement();

                }
                invalidated = true;
                gameTime = DateTime.Now;
            }
        }

        private bool invalidated = true;

        private void ProcessInput()
        {
            ConsoleKeyInfo keyInfo;
            
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Player.Accelerate();
                        invalidated = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        Player.TurnLeft();
                        invalidated = true;
                        break;
                    case ConsoleKey.RightArrow:
                        Player.TurnRight();
                        invalidated = true;
                        break;
                    case ConsoleKey.Q:
                        isPlaying = false;
                        break;
                }
            }
        }

        private void InitializeGame()
        {
            Player = new Car(300);
            Player.IsPlayer = true;
            Player.StartEngine();
            Opponents = new Car[8];
            for (int i = 0; i < Opponents.Length; i++)
            {
                Opponents[i] = new Car(300);
                Opponents[i].StartEngine();
            }
            

        }

        public void DrawMap(int width, int height)
        {
            for (int rowsPrinted = 1; rowsPrinted <= height; rowsPrinted++)
            {
                for (int columnsPrinted = 1; columnsPrinted <= width; columnsPrinted++)
                {
                    if (rowsPrinted == 1 || rowsPrinted == height ||
                        columnsPrinted == 1 || columnsPrinted == width)
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
