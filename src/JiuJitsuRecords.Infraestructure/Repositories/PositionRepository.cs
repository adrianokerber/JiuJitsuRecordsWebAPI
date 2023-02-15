using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;

namespace JiuJitsuRecords.Infraestructure.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly List<Posicao> _posicoes;
        private int _currentInsertedItemId = 0;

        private readonly object _idLock = new object();

        public PositionRepository()
        {
            _posicoes = new List<Posicao> {
                new Posicao(0, "Armlock", "Se caracteriza por ser uma alavanca de braço ao travar o braço entre as pernas e puxar para o rosto"),
                new Posicao(1, "Triângulo", "Se caracteriza por criar a forma de um triângulo por entre as pernas ao cruzar o joelho sobre um dos pés")
            };
            _currentInsertedItemId = _posicoes.Count;
        }

        public async Task<Posicao?> InsertPosition(Posicao posicaoInput)
        {
            if (posicaoInput == null) return null;

            Posicao? posicao = null;
            if (posicaoInput.Id >= 0)
            {
                posicao = await GetPositionById(posicaoInput.Id);
                if (posicao != null)
                    return null;
            }
            
            posicao = FakeDatabaseInsertionOfPositionObject(posicaoInput);

            return posicao;
        }

        private Posicao FakeDatabaseInsertionOfPositionObject(Posicao posicaoInput)
        {
            var posicaoId = posicaoInput.Id;
            if (posicaoId < 0)
            {
                lock (_idLock)
                {
                    posicaoId = _currentInsertedItemId++;
                }
            }

            var posicao = new Posicao(posicaoId,
                                      posicaoInput.Nome,
                                      posicaoInput.Descricao);
            _posicoes.Add(posicao);

            return posicao;
        }

        public async Task<Posicao?> GetPositionById(int id) => await Task.Run(() => _posicoes.Find(x => x.Id == id));

        public async Task<IEnumerable<Posicao>> GetPositionsByIds(IEnumerable<int> ids) => await Task.Run(() => _posicoes.Where(x => ids.Any(id => id == x.Id)));

        public async Task<IEnumerable<Posicao>> GetPositions() => await Task.Run(() => _posicoes);

        public async Task<Posicao?> GetPositionByName(string nome) => await Task.Run(() => _posicoes.Find(x => x.Nome == nome));
    }
}
