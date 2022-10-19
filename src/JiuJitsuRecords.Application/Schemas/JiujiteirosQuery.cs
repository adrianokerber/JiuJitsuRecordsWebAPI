using GraphQL.Types;
using JiuJitsuRecords.Domain.Services;

namespace JiuJitsuRecords.Application.Schemas
{
    public class JiujiteirosQuery : ObjectGraphType<object>
    {
        public JiujiteirosQuery(IJiujitsuAthleteService jiujitsuAthleteService)
        {
            Name = "Query";
            Field<ListGraphType<JiujiteiroType>>("jiujiteiros",
                                                 resolve: context => jiujitsuAthleteService.GetJiujitsuAthletes());
        }
    }
}
