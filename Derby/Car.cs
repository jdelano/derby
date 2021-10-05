using System;
namespace Derby
{
    public class Car
    {
        //public double TankCapacity { get; set; }
        //public double Gas { get; set; }
        public bool IsEngineRunning { get; set; }
        //public int Speed { get; set; }
        public string Direction { get; set; }

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
        }

        public void StartEngine()
        {
            IsEngineRunning = true;
            Console.WriteLine("Engine started!");
        }

        public void StopEngine()
        {
            IsEngineRunning = false;
            Speed = 0;
            Console.WriteLine("Engine stopped!");

        }

        public void Accelerate()
        {
            if (IsEngineRunning)
            {
                Speed++;
                Console.WriteLine("Vroom");
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
            Console.WriteLine("Gassed up and ready to go!");
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



        private double balance;
        public double Balance
        {
            get
            {
                return balance;
            }
            private set
            {
                balance = value;
            }
   
        }

        private string vote;
        public string Vote
        {
 
            set
            {
                vote = value;
            }
        }
    }


  
}
