using DrawPoint.Models;
using DrawPoint.Models.Get;
using System.Collections.Generic;

namespace DrawPoint.Repositories
{
    public interface ISortPointsRepository
    {
        List<PointMass> CreateListPointMass(GetArrayPoints[] arrayPoints);

        List<PointMass> SortPointsToLine(List<PointMass> points);
        List<CurvedLine> SortPointsToCurvedLine(List<PointMass> points, double angle);
    }
}