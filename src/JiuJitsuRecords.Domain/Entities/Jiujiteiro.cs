namespace JiuJitsuRecords.Domain.Entities
{
    public record Jiujiteiro(int Id,
                             string Apelido,
                             string Nome,
                             string Sobrenome,
                             DateTimeOffset? Nascimento,
                             EstiloPreferencial EstiloPreferencial,
                             string Descricao,
                             IEnumerable<int> PosicaoIds);
}
