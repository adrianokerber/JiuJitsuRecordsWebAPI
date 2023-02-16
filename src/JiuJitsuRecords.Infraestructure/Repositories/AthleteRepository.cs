using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;
using JiuJitsuRecords.Infraestructure.Documents;
using JiuJitsuRecords.Infraestructure.Mappers;

namespace JiuJitsuRecords.Infraestructure.Repositories
{
    public class AthleteRepository : IAthleteRepository
    {
        private readonly List<JiujiteiroDocument> _athletes;
        private int _currentInsertedItemId = 0;

        private readonly object _idLock = new object();

        public AthleteRepository()
        {
            _athletes = CreateFakeData().ToList();
            _currentInsertedItemId = _athletes.Count;
        }

        private IEnumerable<JiujiteiroDocument> CreateFakeData()
        {
            yield return new JiujiteiroDocument(0,
                                                "Mica",
                                                "Micael Ferreira",
                                                "Galvão",
                                                new DateTimeOffset(2003, 10, 8, 0, 0, 0, TimeSpan.Zero),
                                                EstiloPreferencial.Any,
                                                "Micael Galvão, também conhecido como Mica (Manaus, 8 de outubro de 2003), é um lutador profissional de Jiu-jitsu campeão mundial em sua categoria e absoluto. Mica é filho e faixa preta do mestre Melqui Galvão, e compete pela academia Fight Sports.",
                                                new List<int> { 1 });
            yield return new JiujiteiroDocument(1,
                                                "N/A",
                                                "Kade",
                                                "Ruotolo",
                                                new DateTimeOffset(2003, 10, 8, 0, 0, 0, TimeSpan.Zero),
                                                EstiloPreferencial.Pass,
                                                "Kade Ruotolo is a Brazilian jiujitsu submission grappling athlete. A competitor with his brother Tye since the age of 3, Ruotolo is a two-time IBJJF World champion, Pan Am and European Open champion in brown belt. Promoted to black belt in December 2021, Ruotolo won the 2022 ADCC World Championship in the 77kg division, becoming at age 19 the youngest-ever ADCC Submission Fighting World champion",
                                                new List<int>());
        }

        public async Task<IEnumerable<Jiujiteiro>> GetAthletes() => await Task.Run(() => _athletes.ToDomainList());

        public async Task<Jiujiteiro?> GetAthlete(Jiujiteiro jiujiteiro) => await Task.Run(() =>
        {
            var athlete = _athletes.Find(x => x.Apelido == jiujiteiro.Apelido
                                           && x.Nome == jiujiteiro.Nome
                                           && x.Sobrenome == jiujiteiro.Sobrenome
                                           && x.Nascimento == jiujiteiro.Nascimento);

            return athlete?.ToDomain();
        });

        public async Task<Jiujiteiro?> GetAthleteById(int id) => await Task.Run(() => _athletes.Find(x => x.Id == id)?.ToDomain());

        public async Task<Jiujiteiro?> GetAthleteByNickname(string nickname) => await Task.Run(() => _athletes.Find(x => x.Apelido == nickname)?.ToDomain());

        public async Task<Jiujiteiro?> InsertAthlete(Jiujiteiro jiujiteiroInput)
        {
            if (jiujiteiroInput == null) return null;

            Jiujiteiro? jiujiteiro = null;
            if (jiujiteiroInput.Id >= 0)
            {
                jiujiteiro = await GetAthleteById(jiujiteiroInput.Id);
                if (jiujiteiro != null)
                    return null;
            }

            jiujiteiro = FakeDatabaseInsertionOfJiujiteiroObject(jiujiteiroInput);

            return jiujiteiro;
        }

        private Jiujiteiro FakeDatabaseInsertionOfJiujiteiroObject(Jiujiteiro jiujiteiroEntity)
        {
            var jiujiteiroId = jiujiteiroEntity.Id;
            if (jiujiteiroId < 0)
            {
                lock (_idLock)
                {
                    jiujiteiroId = _currentInsertedItemId++;
                }
            }

            var jiujiteiroDocument = jiujiteiroEntity.ToDocument(jiujiteiroId);
            _athletes.Add(jiujiteiroDocument);

            return jiujiteiroDocument.ToDomain();
        }
    }
}