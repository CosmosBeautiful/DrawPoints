using System;

namespace DrawPoint.Models
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object other)
        {
            if (other is Point)
            {
                var point = other as Point;
                return ((X == point.X) && (Y == point.Y));
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (int)(X * Y);
        }
    }
}