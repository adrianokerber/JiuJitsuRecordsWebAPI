using HeroesRecordAPI.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HeroesRecordAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AthleteController : ControllerBase
    {
        private readonly ILogger<AthleteController> _logger;

        public AthleteController(ILogger<AthleteController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAthletes")]
        public IEnumerable<Jiujiteiro> Get()
        {
            return Enumerable.Range(1, 5)
                             .Select(index => new Jiujiteiro("Mica",
                                                             "Micael",
                                                             "Galvão",
                                                             new DateTimeOffset(2003, 10, 8, 0, 0, 0, TimeSpan.Zero),
                                                             PosicaoPreferencial.Any,
                                                             "Micael Galvão, também conhecido como Mica (Manaus, 8 de outubro de 2003), é um lutador profissional de Jiu-jitsu campeão mundial em sua categoria e absoluto. Mica é filho e faixa preta do mestre Melqui Galvão, e compete pela academia Fight Sports."))
                             .ToArray();
        }
    }
}
