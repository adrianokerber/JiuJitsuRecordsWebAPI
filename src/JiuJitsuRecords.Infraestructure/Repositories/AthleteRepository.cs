using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;

namespace JiuJitsuRecords.Infraestructure.Repositories
{
    public class AthleteRepository : IAthleteRepository
    {
        private readonly List<Jiujiteiro> _athletes;

        public AthleteRepository()
        {
            //_athletes = new List<Jiujiteiro>();
            _athletes = CreateFakeData().ToList();
        }

        private IEnumerable<Jiujiteiro> CreateFakeData()
        {
            yield return new Jiujiteiro(1,
                                        "Mica",
                                        "Micael Ferreira",
                                        "Galv�o",
                                        new DateTimeOffset(2003, 10, 8, 0, 0, 0, TimeSpan.Zero),
                                        EstiloPreferencial.Any,
                                        "Micael Galv�o, tamb�m conhecido como Mica (Manaus, 8 de outubro de 2003), � um lutador profissional de Jiu-jitsu campe�o mundial em sua categoria e absoluto. Mica � filho e faixa preta do mestre Melqui Galv�o, e compete pela academia Fight Sports.",
                                        new List<int> { 1 });
            yield return new Jiujiteiro(2,
                                        "N/A",
                                        "Kade",
                                        "Ruotolo",
                                        new DateTimeOffset(2003, 10, 8, 0, 0, 0, TimeSpan.Zero),
                                        EstiloPreferencial.Pass,
                                        "Kade Ruotolo is a Brazilian jiujitsu submission grappling athlete. A competitor with his brother Tye since the age of 3, Ruotolo is a two-time IBJJF World champion, Pan Am and European Open champion in brown belt. Promoted to black belt in December 2021, Ruotolo won the 2022 ADCC World Championship in the 77kg division, becoming at age 19 the youngest-ever ADCC Submission Fighting World champion",
                                        new List<int>());
        }

        public async Task<IEnumerable<Jiujiteiro>> GetAthletes() => await Task.Run(() => _athletes);

        public async Task<Jiujiteiro> GetAthleteById(int id) => await Task.Run(() => _athletes.Find(x => x.Id == id));

        public async Task<Jiujiteiro> InsertAthlete(Jiujiteiro jiujiteiro) => await Task.Run(() => {
            _athletes.Add(jiujiteiro);
            return jiujiteiro;
        }); // TODO: must return sucess or failure for insertion when ID already exists and should return added data ex: Task<BaseResult<Jiujiteiro>> and the Jiujiteiro should have the inserted ID
    }
}