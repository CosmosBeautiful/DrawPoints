using DrawPoint.Models;
using DrawPoint.Models.Get;
using DrawPoint.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace DrawPoint.Controllers
{
    [RoutePrefix("SortPoints")]
    public class SortPointsController : ApiController
    {
        protected ISortPointsRepository sortPointsRepository;

        public SortPointsController(ISortPointsRepository sortPointsRepository)
        {
            this.sortPointsRepository = sortPointsRepository;
        }

        [HttpGet]
        [Route("Line")]
        public IHttpActionResult GetLine([FromBody] GetArrayPoints[] arrayPoints)
        {
            try
            {
                List<PointMass> points = sortPointsRepository.CreateListPointMass(arrayPoints);
                List<PointMass> sortPoints = sortPointsRepository.SortPointsToLine(points);
                return Ok(sortPoints);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("CurvedLine/{angle:double:min(1)}")]
        public IHttpActionResult GetCurvedLine(double angle, [FromBody] GetArrayPoints[] arrayPoints)
        {
            try
            {
                List<PointMass> points = sortPointsRepository.CreateListPointMass(arrayPoints);
                List<CurvedLine> sortCurvedLine = sortPointsRepository.SortPointsToCurvedLine(points, angle);
                return Ok(sortCurvedLine);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
