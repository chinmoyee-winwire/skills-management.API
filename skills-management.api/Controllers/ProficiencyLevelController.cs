using Microsoft.AspNetCore.Mvc;
using skills_management.api.Domain.Interfaces.Queries;
using skills_management.api.Logging;
using System.Net;

namespace skills_management.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProficiencyLevelController : ControllerBase
    {
        private readonly IProficiencyLevel _proficiencyLevel;
        private static readonly ILogger Log = LogManager.CreateLogger(typeof(ProficiencyLevelController).FullName);

        public ProficiencyLevelController(IProficiencyLevel proficiencyLevel)
        {
            this._proficiencyLevel = proficiencyLevel;
        }

        [HttpGet("Get")]

        public async Task<ActionResult> GetAllProficiencyLevels()
        {
            try
            {
                var result = await this._proficiencyLevel.Execute();
                return Ok(result);
            }
            catch (Exception e)
            {
                // Log.LogError($"Failed to get proficiencyLevel. Exception: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
