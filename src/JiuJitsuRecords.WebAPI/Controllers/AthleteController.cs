using JiuJitsuRecords.Application.Interfaces;
using JiuJitsuRecords.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JiuJitsuRecords.WebAPI.Controllers
{
    [ApiController]
    [Route("Athletes")]
    public class AthleteController : ControllerBase
    {
        private readonly ILogger<AthleteController> _logger;
        private readonly IJiujitsuAthleteService _jiujitsuAthleteService;

        public AthleteController(ILogger<AthleteController> logger, IJiujitsuAthleteService jiujitsuAthleteService)
        {
            _logger = logger;
            _jiujitsuAthleteService = jiujitsuAthleteService;
        }

        [HttpGet(Name = "GetAthletes")]
        public async Task<IEnumerable<Jiujiteiro>> Get()
        {
            _logger.LogDebug("GET:/ahtletes requested!");
            return await _jiujitsuAthleteService.GetJiujitsuAthletes();
        }
    }
}
