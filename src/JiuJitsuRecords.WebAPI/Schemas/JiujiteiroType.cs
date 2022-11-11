using GraphQL.Types;
using JiuJitsuRecords.Domain.Entities;

namespace JiuJitsuRecords.WebAPI.Schemas
{
    public class JiujiteiroType : ObjectGraphType<Jiujiteiro>
    {
        public JiujiteiroType()
        {
            Name = "Jiujiteiro";
            Description = "Jiujiteiro Type";
            Field(j => j.Id);
            Field(j => j.Apelido);
            Field(j => j.Nome);
            Field(j => j.Sobrenome);
            //Field<PosicaoPreferencialSchema>("posicao",
            //    resolve: context => jiujitsuAthleteService.)
        }
    }
}