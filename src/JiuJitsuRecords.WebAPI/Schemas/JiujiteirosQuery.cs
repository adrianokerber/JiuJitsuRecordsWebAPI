using GraphQL.Types;
using JiuJitsuRecords.Domain.Services;

namespace JiuJitsuRecords.WebAPI.Schemas
{
    public class JiujiteirosQuery : ObjectGraphType
    {
        public JiujiteirosQuery(IJiujitsuAthleteService jiujitsuAthleteService)
        {
            Field<ListGraphType<JiujiteiroType>>("jiujiteiros")
                .Resolve(context => {
                    var jiujitsuAthletes = jiujitsuAthleteService.GetJiujitsuAthletes()
                                                                 .GetAwaiter()
                                                                 .GetResult();
                    return jiujitsuAthletes;
                });
        }
    }
}
