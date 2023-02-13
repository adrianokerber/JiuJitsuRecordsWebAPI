using JiuJitsuRecords.Domain.Entities;

namespace JiuJitsuRecords.Domain.Repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Posicao>> GetPositions();
        Task<IEnumerable<Posicao>> GetPositionsByIds(IEnumerable<int> ids);
        Task<Posicao?> GetPositionById(int id);
        Task<Posicao?> InsertPosition(Posicao posicao);
        Task<Posicao?> GetPositionByName(string nome);
    }
}
