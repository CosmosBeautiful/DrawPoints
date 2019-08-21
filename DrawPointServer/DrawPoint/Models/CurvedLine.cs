using System;

namespace DrawPoint.Models
{
    public class CurvedLine
    {
        public Point StartPoint { get; private set; }
        public Point EndPoint { get; private set; }
        public Point BezEPoint { get; private set; }
        public double Mass { get; private set; }

        public CurvedLine(Point startPoint, Point endPoint, Point centerPoint, double angle)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Mass = CalculationMassRelativeCenter(centerPoint);
            BezEPoint = CalculationBezEPoint(angle);
        }

        private double CalculationMassRelativeCenter(Point centerPoint)
        {
            double mass = Math.Sqrt(Math.Pow((StartPoint.X - centerPoint.X), 2) + Math.Pow((StartPoint.Y - centerPoint.Y), 2));
            double roundMass = Math.Round(mass, 2);
            return roundMass;
        }

        private Point CalculationBezEPoint(double angle)
        {
            double radian = (angle * Math.PI / 180);

            double centerLineX = (StartPoint.X + EndPoint.X) / 2;
            double centerLineY = (StartPoint.Y + EndPoint.Y) / 2;

            double BezEX = Math.Round(centerLineX + (StartPoint.X - centerLineX) * Math.Cos(radian) - (StartPoint.Y - centerLineY) * Math.Sin(radian), 2);
            double BezEY = Math.Round(centerLineY + (StartPoint.X - centerLineX) * Math.Sin(radian) + (StartPoint.Y - centerLineY) * Math.Cos(radian), 2);

            return new Point(BezEX, BezEY);
        }

        public override bool Equals(object other)
        {
            if (other is CurvedLine)
            {
                var line = other as CurvedLine;
                return (StartPoint.Equals(line.StartPoint) && EndPoint.Equals(line.EndPoint) && BezEPoint.Equals(line.BezEPoint) && (Mass == line.Mass));
            }
            
            return false;
        }

        public override int GetHashCode()
        {
            return (int)(StartPoint.GetHashCode() * EndPoint.GetHashCode() * BezEPoint.GetHashCode() * Mass);
        }
    }
}