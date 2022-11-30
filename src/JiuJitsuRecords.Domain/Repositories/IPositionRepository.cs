using JiuJitsuRecords.Domain.Entities;

namespace JiuJitsuRecords.Domain.Repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Posicao>> GetPositions();
        Task<IEnumerable<Posicao>> GetPositionsByIds(IEnumerable<int> ids);
        Task<Posicao?> GetPositionById(int id);
        Task InsertPosition(Posicao posicao);
        Task<Posicao?> GetPositionByName(string nome);
    }
}
