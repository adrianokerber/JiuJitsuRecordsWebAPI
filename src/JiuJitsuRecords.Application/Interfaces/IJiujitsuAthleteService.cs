using JiuJitsuRecords.Application.Entities;
using JiuJitsuRecords.Domain.Entities;

namespace JiuJitsuRecords.Application.Interfaces
{
    public interface IJiujitsuAthleteService
    {
        Task<IEnumerable<Jiujiteiro>> GetJiujitsuAthletes();
        Task<Jiujiteiro?> GetJiujitsuAthleteByNickname(string nickname);
        Task<Jiujiteiro?> RegisterJiujitsuAthleteWithPositions(AthleteDto athlete, List<Posicao> posicoesInput);
    }
}
