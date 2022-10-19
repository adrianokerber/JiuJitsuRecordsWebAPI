using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Services;

namespace JiuJitsuRecords.WebAPI.Services
{
    public class JiujitsuAthleteService : IJiujitsuAthleteService
    {
        private readonly IEnumerable<Jiujiteiro> _jiujiteiros;

        public JiujitsuAthleteService()
        {
            _jiujiteiros = CreateFakeData();
        }

        private IEnumerable<Jiujiteiro> CreateFakeData()
        {
            yield return new Jiujiteiro("Mica",
                                        "Micael Ferreira",
                                        "Galvão",
                                        new DateTimeOffset(2003, 10, 8, 0, 0, 0, TimeSpan.Zero),
                                        PosicaoPreferencial.Any,
                                        "Micael Galvão, também conhecido como Mica (Manaus, 8 de outubro de 2003), é um lutador profissional de Jiu-jitsu campeão mundial em sua categoria e absoluto. Mica é filho e faixa preta do mestre Melqui Galvão, e compete pela academia Fight Sports.");
            yield return new Jiujiteiro("N/A",
                                        "Kade",
                                        "Ruotolo",
                                        new DateTimeOffset(2003, 10, 8, 0, 0, 0, TimeSpan.Zero),
                                        PosicaoPreferencial.Any,
                                        "Kade Ruotolo is a Brazilian jiujitsu submission grappling athlete. A competitor with his brother Tye since the age of 3, Ruotolo is a two-time IBJJF World champion, Pan Am and European Open champion in brown belt. Promoted to black belt in December 2021, Ruotolo won the 2022 ADCC World Championship in the 77kg division, becoming at age 19 the youngest-ever ADCC Submission Fighting World champion");
        }

        public async Task<IEnumerable<Jiujiteiro>> GetJiujitsuAthletes() => await Task.Run(() => _jiujiteiros);

        public Task<Jiujiteiro> GetJiujitsuAthleteByNickname(string nickname)
        {
            throw new NotImplementedException();
        }
    }
}
