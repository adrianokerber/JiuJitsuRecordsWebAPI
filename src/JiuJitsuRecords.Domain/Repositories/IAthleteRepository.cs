using JiuJitsuRecords.Domain.Entities;

namespace JiuJitsuRecords.Domain.Repositories
{
    public interface IAthleteRepository
    {
        Task<IEnumerable<Jiujiteiro>> GetAthletes();
        Task<Jiujiteiro> GetAthleteById(int id);
        Task InsertAthlete(Jiujiteiro jiujiteiro);
    }
}