namespace JiuJitsuRecords.Domain.Entities
{
    public record Posicao
    {
        public int Id { get; } = 0;
        public string Nome { get; } = string.Empty;
        public string Descricao { get; } = string.Empty;

        public Posicao(string nome)
        {
            Nome = nome;
        }

        public Posicao(int id,
                       string nome,
                       string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }
    }
}
