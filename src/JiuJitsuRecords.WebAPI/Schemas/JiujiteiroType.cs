using GraphQL.Types;
using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;
using System;

namespace JiuJitsuRecords.WebAPI.Schemas
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
            //Field(j => j.Posicoes)
            //    .ResolveAsync(async (context) => {
            //      var positionIds = context.Source.PosicaoIds;
            //      await positionRepository.GetPositionsByIds(positionIds);
            //    });
            Field<IEnumerable<Posicao>>("posicoes")
                .Resolve(context => {
                    var positionIds = context.Source.PosicaoIds;
                    return positionRepository.GetPositionsByIds(positionIds).GetAwaiter().GetResult();
                });
        }
    }
}