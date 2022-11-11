using JiuJitsuRecords.Domain.Entities;

namespace JiuJitsuRecords.Domain.Repositories
{
    public interface IAthleteRepository
    {
        Task<IEnumerable<Jiujiteiro>> GetAthletes();
        Task InsertAthlete(Jiujiteiro jiujiteiro);
    }
}