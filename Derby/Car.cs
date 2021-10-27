using System;
namespace Derby
{
    public class Car
    {
        private int locationX;
        public int LocationX
        {
            get
            {
                return locationX;
            }
            set
            {
                if (value < 1)
                {
                    locationX = 1;
                }
                else if (value > 77)
                {
                    locationX = 77;
                }
                else
                {
                    locationX = value;
                }
            }
        }

        private int locationY;
        public int LocationY
        {
            get
            {
                return locationY;
            }
            set
            {
                if (value < 1)
                {
                    locationY = 1;
                }
                else if (value > 22)
                {
                    locationY = 22;
                }
                else
                {
                    locationY = value;
                }
            }
        }

        private static Random randomGenerator = new Random();

        //public double TankCapacity { get; set; }
        //public double Gas { get; set; }
        public bool IsEngineRunning { get; set; }
        //public int Speed { get; set; }
        public string Direction { get; set; }

        private int carNumber;

        private static int carCount = 0;

        public bool IsPlayer { get; set; }

        private int speed;
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value > 0)
                {
                    speed = value;
                }
                else  // ensures speed will be 0 if negative value is assigned
                {
                    speed = 0;
                }
            }
        }

        private double tankCapacity;
        public double TankCapacity
        {
            get
            {
                return tankCapacity;
            }
            set
            {
                if (value >= 0)
                {
                    tankCapacity = value;
                } // ignores negative values altogether
            }
        }

        public double GasToFull
        {
            get
            {
                return TankCapacity - Gas;
            }
        }

        public Car(double tankCapacity)
        {
            Direction = "North";
            TankCapacity = tankCapacity;
            FillTank();
            carCount++;
            carNumber = carCount;
            LocationX = randomGenerator.Next(1, 78);
            LocationY = randomGenerator.Next(1, 24);
        }

        public void StartEngine()
        {
            IsEngineRunning = true;
        }

        public void StopEngine()
        {
            IsEngineRunning = false;
            Speed = 0;
        }

        public void Accelerate()
        {
            if (IsEngineRunning)
            {
                Speed++;
                switch (Direction)
                {
                    case "North":
                        LocationY--;
                        break;
                    case "South":
                        LocationY++;
                        break;
                    case "East":
                        LocationX++;
                        break;
                    case "West":
                        LocationX--;
                        break;

                }
                Gas--;
                if (Gas == 0)
                {
                    StopEngine();
                }
            }
        }

        private double gas;
        public double Gas
        {
            get
            {
                return gas;
            }
            set
            {
                if (value >= 0)
                {
                    gas = value;
                }
            }
        }
        public void FillTank()
        {
            Gas = TankCapacity;
        }

        public void TurnRight()
        {
            if (Direction == "North")
            {
                Direction = "East";
            }
            else if (Direction == "East")
            {
                Direction = "South";
            }
            else if (Direction == "South")
            {
                Direction = "West";
            }
            else
            {
                Direction = "North";
            }
        }

        public void TurnLeft()
        {
            if (Direction == "North")
            {
                Direction = "West";
            }
            else if (Direction == "East")
            {
                Direction = "North";
            }
            else if (Direction == "South")
            {
                Direction = "East";
            }
            else
            {
                Direction = "South";
            }
        }

        public void Display()
        {
            
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;
            Console.SetCursorPosition(LocationX, LocationY);
            if (IsPlayer)
            {
                Console.Write("P");
            }
            else
            {
                Console.Write($"{carNumber}");
            }
            Console.SetCursorPosition(cursorLeft, cursorTop);
        }

        public void MakeRandomMovement()
        {
            switch (randomGenerator.Next(1, 6))
            {
                case int roll when roll >= 1 && roll <= 3:
                    Accelerate();
                    break;
                case 4:
                    TurnLeft();
                    break;
                case 5:
                    TurnRight();
                    break;
            }
    }
        }

    
  
}
