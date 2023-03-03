using Microsoft.AspNetCore.Mvc;
using skills_management.api.Domain.Interfaces.Queries;
using skills_management.api.Logging;
using skills_management.api.Models;
using System.Net;

namespace skills_management.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategories _getCategories;
        private static readonly ILogger Log = LogManager.CreateLogger(typeof(CategoriesController).FullName);

        public CategoriesController(ICategories getCategories)
        {
            this._getCategories = getCategories;
        }

        [HttpGet("Get")]
        public async Task<ActionResult> GetAllCategories(int practicesId)
        {
            try
            {
                var result = await this._getCategories.Execute(practicesId);
                return Ok(result);
            }
            catch (Exception e)
            {
                // Log.LogError($"Failed to get categories for the practice id {practicesId}. Exception: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
