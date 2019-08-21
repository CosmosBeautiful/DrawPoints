using System;

namespace DrawPoint.Models
{
    public class PointMass : Point, IComparable<PointMass>
    {
        // Расстояние от координат (0,0) до точки (X,Y). (Радиус)
        public double Mass { get; private set; }

        public PointMass(double x, double y)
            : base (x,y)
        {
            Mass = CalculationMassRelativeZero(x, y);
        }

        private double CalculationMassRelativeZero(double x, double y)
        {
            double mass = Math.Sqrt( Math.Pow(x, 2) + Math.Pow(y, 2) );
            double roundMass = Math.Round(mass, 2);
            return roundMass;
        }

        public int CompareTo(PointMass otherPoint)
        {
            return Convert.ToInt32(Mass - otherPoint.Mass);
        }

        public override bool Equals(object other)
        {
            if (other is PointMass)
            {
                var point = other as PointMass;
                return ((X == point.X) && (Y == point.Y) && (Mass == point.Mass));
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (int)(base.GetHashCode() * Mass);
        }
    }
}