using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;

namespace JiuJitsuRecords.Infraestructure.Repositories
{
    public class PosicaoRepository : IPositionRepository
    {
        public readonly List<Posicao> _posicoes;

        public PosicaoRepository()
        {
            _posicoes = new List<Posicao> {
                new Posicao(1, "Armlock", "Se caracteriza por ser uma alavanca de braço ao travar o braço entre as pernas e puxar para o rosto"),
                new Posicao(2, "Triângulo", "Se caracteriza por criar a forma de um triângulo por entre as pernas ao cruzar o joelho sobre um dos pés")
            };
        }

        public async Task InsertPosition(Posicao posicao) => await Task.Run(() => _posicoes.Add(posicao));

        public async Task<Posicao?> GetPositionById(int id) => await Task.Run(() => _posicoes.Find(x => x.Id == id));

        public async Task<IEnumerable<Posicao>> GetPositionsByIds(IEnumerable<int> ids) => await Task.Run(() => _posicoes.Where(x => ids.Any(id => id == x.Id)));

        public async Task<IEnumerable<Posicao>> GetPositions() => await Task.Run(() => _posicoes);

        public async Task<Posicao?> GetPositionByName(string nome) => await Task.Run(() => _posicoes.Find(x => x.Nome == nome));
    }
}
