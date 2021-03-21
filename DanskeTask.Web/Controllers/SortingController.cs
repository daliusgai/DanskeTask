using DanskeTask.Core.DTO;
using DanskeTask.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DanskeTask.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortingController : Controller
    {
        private readonly ISortingService _sortingService;

        public SortingController(ISortingService sortingService)
        {
            _sortingService = sortingService;
        }

        /// <summary>
        /// Sorts given string of numbers using multiple sorting algorithms
        /// </summary>
        /// <returns>Sorted string of numbers and sorting time in miliseconds for each algorithm</returns>
        /// <response code="200">Sorted string of numbers and sorting time in miliseconds for each algorithm</response>
        /// <response code="400">If string of numbers is null or empty</response>
        /// <response code="500">If internal error occured</response>
        [HttpPost("Sort")]
        public IActionResult Sort([FromBody] SortRequestDTO requestDTO)
        {
            var result = _sortingService.Sort(requestDTO.Numbers);

            if (result is null)
                return StatusCode(500);
            else
                return Ok(result);
        }

        /// <summary>
        /// Retrieves most recent saved sorted numbers
        /// </summary>
        /// <returns>Most recent saved sorted numbers</returns>
        /// <response code="200">Most recent saved sorted numbers</response>
        /// <response code="500">If internal error occured</response>
        [HttpGet("Latest")]
        public IActionResult GetLatestSortResult()
        {
            var result = _sortingService.GetLatestSortResult();

            if (result is null)
                return StatusCode(500);
            else
                return Ok(result);
        }
    }
}