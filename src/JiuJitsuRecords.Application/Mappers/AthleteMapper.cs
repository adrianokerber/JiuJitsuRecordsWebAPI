using JiuJitsuRecords.Application.Entities;
using JiuJitsuRecords.Domain.Entities;

namespace JiuJitsuRecords.Application.Mappers
{
    public static class AthleteMapper
    {
        public static Jiujiteiro ToDomain(this AthleteDto dto, List<int> posicaoIds = default)
            => new Jiujiteiro(-1,
                              dto.Apelido,
                              dto.Nome,
                              dto.Sobrenome,
                              dto.Nascimento,
                              dto.EstiloPreferencial,
                              dto.Descricao,
                              posicaoIds);
    }
}
