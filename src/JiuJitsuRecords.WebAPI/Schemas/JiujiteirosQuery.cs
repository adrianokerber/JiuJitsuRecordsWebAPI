using GraphQL.Types;
using JiuJitsuRecords.Domain.Repositories;

namespace JiuJitsuRecords.WebAPI.Schemas
{
    public class JiujiteirosQuery : ObjectGraphType
    {
        public JiujiteirosQuery(IAthleteRepository athleteRepository)
        {
            Field<ListGraphType<JiujiteiroType>>("jiujiteiros")
                .Resolve(context => {
                    var jiujitsuAthletes = athleteRepository.GetAthletes()
                                                            .GetAwaiter()
                                                            .GetResult();
                    return jiujitsuAthletes;
                });
        }
    }
}
