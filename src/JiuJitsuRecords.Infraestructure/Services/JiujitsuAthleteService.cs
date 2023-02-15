using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;
using JiuJitsuRecords.Domain.Services;

namespace JiuJitsuRecords.Infraestructure.Services
{
    public class JiujitsuAthleteService : IJiujitsuAthleteService
    {
        private readonly IAthleteRepository _athleteRepository;

        public JiujitsuAthleteService(IAthleteRepository athleteRepository, IPositionService positionService)
        {
            _athleteRepository = athleteRepository;
        }

        public async Task<IEnumerable<Jiujiteiro>> GetJiujitsuAthletes() => await _athleteRepository.GetAthletes();

        public async Task<Jiujiteiro> GetJiujitsuAthleteByNickname(string nickname)
        {
            // TODO: add way of getting specific athlete
            throw new NotImplementedException();
        }

        public async Task<Jiujiteiro> RegisterJiujitsuAthlete(Jiujiteiro jiujiteiro)
        {
            // TODO: create method:
            //var athletes = await _athleteRepository.GetAthletes();
            // - GetAthlete by nickname or name
            // - Insert Athlete if it does not exists
            // - If exists, update data or return error
            throw new NotImplementedException();
        }
    }
}
