using GraphQL;
using GraphQL.Types;
using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;

namespace JiuJitsuRecords.WebAPI.Schemas
{
    public class JiujiteirosQuery : ObjectGraphType
    {
        public JiujiteirosQuery(IAthleteRepository athleteRepository)
        {
            Field<ListGraphType<JiujiteiroType>>("jiujiteiros")
                .Arguments(new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }
                ))
                .Resolve(context => {
                    var id = context.GetArgument<int?>("id");

                    if (id != null)
                    {
                        var athlete = athleteRepository.GetAthleteById(id.GetValueOrDefault())
                                                       .GetAwaiter()
                                                       .GetResult();
                        if (athlete != null)
                            return new List<Jiujiteiro> { athlete };
                        else
                            return new List<Jiujiteiro>();
                    }

                    var jiujitsuAthletes = athleteRepository.GetAthletes()
                                                            .GetAwaiter()
                                                            .GetResult();
                    return jiujitsuAthletes;
                });
        }
    }
}
