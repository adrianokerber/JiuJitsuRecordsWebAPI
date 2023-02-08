using GraphQL.Types;
using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;

namespace JiuJitsuRecords.WebAPI.Schemas.Types
{
    public class JiujiteiroType : ObjectGraphType<Jiujiteiro>
    {
        public JiujiteiroType(IPositionRepository positionRepository)
        {
            Name = "Jiujiteiro";
            Description = "Jiujiteiro Type";
            Field(j => j.Id);
            Field(j => j.Apelido);
            Field(j => j.Nome);
            Field(j => j.Sobrenome);
            Field(j => j.EstiloPreferencial);
            Field<IEnumerable<Posicao>>("posicoes")
                .ResolveAsync(async context =>
                {
                    var positionIds = context.Source.PosicaoIds;
                    return await positionRepository.GetPositionsByIds(positionIds);
                });
        }
    }
}