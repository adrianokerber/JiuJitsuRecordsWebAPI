using JiuJitsuRecords.Application.Entities;
using JiuJitsuRecords.Application.Interfaces;
using JiuJitsuRecords.Application.Mappers;
using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;
using JiuJitsuRecords.Domain.Services;

namespace JiuJitsuRecords.Application.Services
{
    // TODO: this should be an ApplicationService
    public class JiujitsuAthleteService : IJiujitsuAthleteService
    {
        private readonly IAthleteRepository _athleteRepository;
        private readonly IPositionService _positionService;

        public JiujitsuAthleteService(IAthleteRepository athleteRepository, IPositionService positionService)
        {
            _athleteRepository = athleteRepository;
            _positionService = positionService;
        }

        public async Task<IEnumerable<Jiujiteiro>> GetJiujitsuAthletes()
            => await _athleteRepository.GetAthletes();

        public async Task<Jiujiteiro?> GetJiujitsuAthleteByNickname(string nickname)
            => await _athleteRepository.GetAthleteByNickname(nickname);

        public async Task<Jiujiteiro?> RegisterJiujitsuAthleteWithPositions(AthleteDto athlete, List<Posicao> posicoesInput)
        {
            if (athlete == null) return null;

            var jiujiteiro = await _athleteRepository.GetAthlete(athlete.ToDomain());
            if (jiujiteiro != null) return jiujiteiro;

            var posicoes = await RegisterPositionsAndReturnIds(posicoesInput);

            jiujiteiro = await _athleteRepository.InsertAthlete(athlete.ToDomain(posicoes));

            return jiujiteiro;
        }

        private async Task<List<int>> RegisterPositionsAndReturnIds(List<Posicao> posicoesInput)
        {
            var posicaoIds = new List<int>();
            foreach (var posicaoInput in posicoesInput)
            {
                var posicao = await _positionService.GetPositionByName(posicaoInput.Nome);
                if (posicao == null)
                    posicao = await _positionService.RegisterPosition(posicaoInput);
                if (posicao != null)
                    posicaoIds.Add(posicao.Id);
            }
            return posicaoIds;
        }
    }
}
