using Microsoft.AspNetCore.Mvc;
using skills_management.api.Domain.Interfaces.Queries;
using skills_management.api.Logging;
using System.Net;

namespace skills_management.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticesController : ControllerBase
    {
        private readonly IPractices _getPractices;
        private static readonly ILogger Log = LogManager.CreateLogger(typeof(PracticesController).FullName);
        public PracticesController(IPractices getPractices)
        {
            this._getPractices = getPractices;
        }


        [HttpGet("Get")]

        public async Task<ActionResult> GetAllPractices()
        {
            try
            {
                var result = await this._getPractices.Execute();
                return Ok(result);
            }
            catch (Exception e)
            {
                // Log.LogError($"Failed to get practices. Exception: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
