using DrawPoint.Models;
using DrawPoint.Models.Get;
using System.Collections.Generic;

namespace DrawPoint.Repositories
{
    public class SortPointsRepository : ISortPointsRepository
    {
        public List<PointMass> CreateListPointMass(GetArrayPoints[] arrayPoints)
        {
            var points = new List<PointMass>();

            foreach (var point in arrayPoints)
            {
                points.Add(new PointMass(point.X, point.Y));
            }

            return points;
        }

        public List<PointMass> SortPointsToLine(List<PointMass> points)
        {
            points.Sort();
            return points;
        }

        public List<CurvedLine> SortPointsToCurvedLine(List<PointMass> points, double angle)
        {
            Point centerPoint = GetCenterPoint(points);
            List<CurvedLine> curvedLine = CreateCurvedLine(points, centerPoint, angle);
            
            return curvedLine;
        }

        private Point GetCenterPoint(List<PointMass> points)
        {
            List<PointMass> sortPoints = new List<PointMass>(points);
            int len = sortPoints.Count;
            int center = (len % 2 == 1) ? (len / 2) : (len / 2 - 1);

            return sortPoints[center];
        }

        private List<CurvedLine> CreateCurvedLine(List<PointMass> points, Point centerPoint, double angle)
        {
            List<CurvedLine> curvedLine = new List<CurvedLine>();
            
            for (int i = 1; i < points.Count; i++)
            {
                Point startPoint = new Point(points[i - 1].X, points[i - 1].Y);
                Point endPoint = new Point(points[i].X, points[i].Y);
                curvedLine.Add(new CurvedLine(startPoint, endPoint, centerPoint, angle));
            }

            return curvedLine;
        }
    }
}