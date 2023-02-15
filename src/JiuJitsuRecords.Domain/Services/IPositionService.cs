using JiuJitsuRecords.Domain.Entities;

namespace JiuJitsuRecords.Domain.Services
{
    public interface IPositionService
    {
        Task<IEnumerable<Posicao>> GetPositions();
        Task<IEnumerable<Posicao>> GetPositionsByIds(IEnumerable<int> ids);
        Task<Posicao?> GetPositionById(int id);
        Task<Posicao?> GetPositionByName(string name);
        Task<Posicao?> RegisterPosition(Posicao posicao);
    }
}
