using JiuJitsuRecords.Domain.Entities;

namespace JiuJitsuRecords.Application.Entities
{
    public record AthleteDto(string Apelido,
                             string Nome,
                             string Sobrenome,
                             DateTimeOffset? Nascimento,
                             EstiloPreferencial EstiloPreferencial,
                             string Descricao);
}
