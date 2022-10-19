using GraphQL.Types;
using JiuJitsuRecords.Domain.Entities;

namespace JiuJitsuRecords.WebAPI.Schemas
{
    public class JiujiteiroType : ObjectGraphType<Jiujiteiro>
    {
        public JiujiteiroType()//IJiujitsuAthleteService jiujitsuAthleteService)
        {
            Field(j => j.Apelido);
            Field(j => j.Nome);
            Field(j => j.Sobrenome);
            //Field<PosicaoPreferencialSchema>("posicao",
            //    resolve: context => jiujitsuAthleteService.)
        }
    }
}