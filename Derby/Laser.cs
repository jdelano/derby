using System;
namespace Derby
{
    public class Laser
    {
        public string Direction { get; set; }
        public bool IsFiring { get; set; }
        private int locationX;
        public int LocationX
        {
            get
            {
                return locationX;
            }
            set
            {
                if (value < 0)
                {
                    IsFiring = false;
                }
                else if (value > 77)
                {
                    IsFiring = false;
                }
                else
                {
                    locationX = value;
                    IsFiring = true;
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
                if (value < 0)
                {
                    IsFiring = false;
                }
                else if (value > 22)
                {
                    IsFiring = false;
                }
                else
                {
                    locationY = value;
                    IsFiring = true;
                }
            }
        }

        public Laser(int x, int y, string direction)
        {
            LocationX = x;
            LocationY = y;
            Direction = direction;
        }

        public void AdvanceLaser()
        {
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
        }

        public void Display()
        {
            if (IsFiring)
            {
                int cursorLeft = Console.CursorLeft;
                int cursorTop = Console.CursorTop;
                Console.SetCursorPosition(LocationX, LocationY);
                switch (Direction)
                {
                    case "North":
                    case "South":
                        Console.Write("|");
                        break;
                    case "East":
                    case "West":
                        Console.Write("-");
                        break;
                }
                Console.SetCursorPosition(cursorLeft, cursorTop);
            }
        }
    }
}
