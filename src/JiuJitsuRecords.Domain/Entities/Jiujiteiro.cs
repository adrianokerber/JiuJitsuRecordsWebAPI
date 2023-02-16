namespace JiuJitsuRecords.Domain.Entities
{
    public record Jiujiteiro(string Apelido,
                             string Nome,
                             string Sobrenome,
                             DateTimeOffset? Nascimento,
                             EstiloPreferencial EstiloPreferencial,
                             string Descricao,
                             IEnumerable<int> PosicaoIds,
                             int Id = -1);
}
