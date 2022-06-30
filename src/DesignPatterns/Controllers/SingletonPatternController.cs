using API.Services.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SingletonPatternController : ControllerBase
    {
        private readonly ILogger<SingletonPatternController> _logger;

        public SingletonPatternController(
            ILogger<SingletonPatternController> logger
            )
        {
            _logger = logger;
        }
    }
}