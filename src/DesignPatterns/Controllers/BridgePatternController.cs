using API.Services.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BridgePatternController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<BridgePatternController> _logger;

        public BridgePatternController(
            IMovieService movieService,
            ILogger<BridgePatternController> logger
            )
        {
            _movieService = movieService;
            _logger = logger;
        }

        [HttpPost]
        [Route("PostGetMoviePrices")]
        public IActionResult PostGetMoviePrices()
        {
            var result = _movieService.GetMoviePrices();
            return Ok(result);
        }
    }
}
