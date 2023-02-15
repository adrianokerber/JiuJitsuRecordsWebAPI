using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;
using JiuJitsuRecords.Domain.Services;

namespace JiuJitsuRecords.Infraestructure.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<Posicao?> GetPositionById(int id)
            => await _positionRepository.GetPositionById(id);

        public async Task<Posicao?> GetPositionByName(string name)
            => await _positionRepository.GetPositionByName(name);

        public async Task<IEnumerable<Posicao>> GetPositions()
            => await _positionRepository.GetPositions();

        public async Task<IEnumerable<Posicao>> GetPositionsByIds(IEnumerable<int> ids)
            => await _positionRepository.GetPositionsByIds(ids);

        public async Task<Posicao?> RegisterPosition(Posicao posicaoInput)
        {
            if (posicaoInput == null) return null;

            var posicao = await _positionRepository.GetPositionByName(posicaoInput.Nome);
            if (posicao != null) return posicao;

            posicao = await _positionRepository.InsertPosition(posicaoInput);

            return posicao;
        }
    }
}
