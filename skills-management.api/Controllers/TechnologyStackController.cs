using Microsoft.AspNetCore.Mvc;
using skills_management.api.Domain.Interfaces.Queries;
using skills_management.api.Logging;
using System.Net;

namespace skills_management.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyStackController : ControllerBase
    {
        private readonly ITechnologyStack _technologystack;
        private static readonly ILogger Log = LogManager.CreateLogger(typeof(TechnologyStackController).FullName);
        public TechnologyStackController(ITechnologyStack technologystack)
        {
            this._technologystack = technologystack;
        }

        [HttpGet("GetTechnologyStack")]
        public async Task<ActionResult> GetTechnology(int? categoryId)
        {
            try
            {
                var result = await this._technologystack.ExecuteByCategoryId(categoryId);

                if (result == null)
                {
                    throw new Exception($"Technology Stack for the CategoryId {categoryId} is not found.");
                }

                return Ok(result);
            }

            catch (Exception e)
            {
                // Log.LogError($"Failed to get Technology stack. Exception: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

    }
}
