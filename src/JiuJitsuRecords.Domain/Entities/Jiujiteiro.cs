namespace JiuJitsuRecords.Domain.Entities
{
    public record Jiujiteiro(string Apelido,
                             string Nome,
                             string Sobrenome,
                             DateTimeOffset Nascimento,
                             PosicaoPreferencial Posicao,
                             string Descricao);
}
