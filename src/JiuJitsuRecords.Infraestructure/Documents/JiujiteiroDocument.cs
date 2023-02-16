using JiuJitsuRecords.Domain.Entities;

namespace JiuJitsuRecords.Infraestructure.Documents
{
    public record JiujiteiroDocument(int Id,
                                     string Apelido,
                                     string Nome,
                                     string Sobrenome,
                                     DateTimeOffset? Nascimento,
                                     EstiloPreferencial EstiloPreferencial,
                                     string Descricao,
                                     IEnumerable<int> PosicaoIds);
}
