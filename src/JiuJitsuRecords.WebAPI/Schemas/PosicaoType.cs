using GraphQL.Types;
using JiuJitsuRecords.Domain.Entities;

namespace JiuJitsuRecords.WebAPI.Schemas
{
    public class PosicaoType : ObjectGraphType<Posicao>
    {
        public PosicaoType()
        {
            Name = "Posicao";
            Description = "Posicao Type";
            Field(j => j.Id);
            Field(j => j.Nome);
            Field(j => j.Descricao);
        }
    }
}