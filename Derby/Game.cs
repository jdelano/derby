using System;
using System.Collections.Generic;
using System.Linq;

namespace Derby
{
    public class Game
    {
        private bool isPlaying = true;
        //private int totalLasers;
        //public Laser[] Lasers { get; set; }
        public Car Player { get; set; }
        //public Car[] Opponents { get; set; }
        public List<Car> Opponents { get; set; }
        public List<Laser> Lasers { get; set; }

        private const int startingOpponents = 8;

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
                //for (int i = 0; i < Opponents.Length; i++)
                //{
                //    Opponents[i].Display();

                //}
                //for (int i = 0; i < totalLasers; i++)
                //{
                //    if (Lasers[i] != null)
                //    {
                //        Lasers[i].Display();
                //    }
                //}
                foreach (var opponent in Opponents)
                {
                    opponent.Display();
                }

                foreach (var laser in Lasers)
                {
                    laser.Display();
                }

                //for (int i = Opponents.Count - 1; i >= 0; i--)
                //{
                //    if (Player.IsCarHitting(Opponents[i]))
                //    {
                //        Opponents.RemoveAt(i);
                //    }
                //}

                var carCollisions = from opponent in Opponents
                                    where Player.IsCarHitting(opponent)
                                    select opponent;

                foreach (var car in carCollisions.ToList())
                {
                    Opponents.Remove(car);
                }

                //for (int i = Opponents.Count - 1; i >= 0; i--)
                //{
                //    for (int j = Lasers.Count - 1; j >= 0; j--)
                //    {
                //        if (Opponents[i].IsLaserHitting(Lasers[j]))
                //        {
                //            Opponents.RemoveAt(i);
                //            Lasers.RemoveAt(j);
                //        }
                //    }
                //}

                var laserCollisions = from opponent in Opponents
                                      from laser in Lasers
                                      where opponent.IsLaserHitting(laser)
                                      select new { Opponent = opponent, Laser = laser };

                foreach (var crash in laserCollisions.ToList())
                {
                    Opponents.Remove(crash.Opponent);
                    Lasers.Remove(crash.Laser);
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
                foreach (var opponent in Opponents)
                {
                    opponent.MakeRandomMovement();
                }
                foreach (var laser in Lasers)
                {
                    laser.AdvanceLaser();
                }
                //for (int i = 0; i < Opponents.Length; i++)
                //{
                //    Opponents[i].MakeRandomMovement();

                //}
                //for (int i = 0; i < Lasers.Length; i++)
                //{
                //    if (Lasers[i] != null)
                //    {
                //        Lasers[i].AdvanceLaser();
                //    }
                //}
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
                    case ConsoleKey.Spacebar:
                        if (Lasers.Count >= 3)
                        {
                            Lasers.Clear();
                        }
                        Lasers.Add(new Laser(Player.LocationX, Player.LocationY, Player.Direction));
                        //if (totalLasers < 3)
                        //{
                        //    Lasers[totalLasers] = new Laser(Player.LocationX, Player.LocationY, Player.Direction);
                        //    totalLasers++;
                        //}
                        //else
                        //{
                        //    Array.Clear(Lasers, 0, Lasers.Length);
                        //    totalLasers = 0;
                        //    Lasers[totalLasers] = new Laser(Player.LocationX, Player.LocationY, Player.Direction);
                        //    totalLasers++;
                        //}
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
            Opponents = new List<Car>();
            Lasers = new List<Laser>();
            for (int i = 0; i < startingOpponents; i++)
            {
                Car opponent = new Car(600);
                opponent.StartEngine();
                Opponents.Add(opponent);
            }

            //Opponents = new Car[8];
            //for (int i = 0; i < Opponents.Length; i++)
            //{
            //    Opponents[i] = new Car(300);
            //    Opponents[i].StartEngine();
            //}
            //Lasers = new Laser[3];

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
