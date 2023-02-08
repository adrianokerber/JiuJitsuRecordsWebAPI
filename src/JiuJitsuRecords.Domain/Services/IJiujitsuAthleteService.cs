using JiuJitsuRecords.Domain.Entities;

namespace JiuJitsuRecords.Domain.Services
{
    public interface IJiujitsuAthleteService
    {
        Task<IEnumerable<Jiujiteiro>> GetJiujitsuAthletes();
        Task<Jiujiteiro> GetJiujitsuAthleteByNickname(string nickname);
        Task<Jiujiteiro> RegisterJiujitsuAthlete(Jiujiteiro jiujiteiro);
    }
}
