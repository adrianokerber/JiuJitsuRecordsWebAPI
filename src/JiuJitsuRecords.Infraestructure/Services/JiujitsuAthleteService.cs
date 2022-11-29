using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;
using JiuJitsuRecords.Domain.Services;

namespace JiuJitsuRecords.Infraestructure.Services
{
    public class JiujitsuAthleteService : IJiujitsuAthleteService
    {
        private readonly IAthleteRepository _athleteRepository;

        public JiujitsuAthleteService(IAthleteRepository athleteRepository)
        {
            _athleteRepository = athleteRepository;
        }

        public async Task<IEnumerable<Jiujiteiro>> GetJiujitsuAthletes() => await _athleteRepository.GetAthletes();

        public Task<Jiujiteiro> GetJiujitsuAthleteByNickname(string nickname)
        {
            // TODO: add way of getting specific athlete
            throw new NotImplementedException();
        }
    }
}
