using GraphQL;
using GraphQL.Types;
using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;
using JiuJitsuRecords.WebAPI.Schemas.Types;

namespace JiuJitsuRecords.WebAPI.Schemas
{
    public class JiuJitsuRecordsQuery : ObjectGraphType
    {
        private readonly IAthleteRepository _athleteRepository;
        private readonly IPositionRepository _positionRepository;

        public JiuJitsuRecordsQuery(IAthleteRepository athleteRepository, IPositionRepository positionRepository)
        {
            _athleteRepository = athleteRepository;
            _positionRepository = positionRepository;

            ConfigureJiujiteirosQuery();
            ConfigurePosicoesQuery();
        }


        private void ConfigureJiujiteirosQuery()
        {
            Field<ListGraphType<JiujiteiroType>>("jiujiteiros")
                .Arguments(new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }
                ))
                .Resolve(context =>
                {
                    var id = context.GetArgument<int?>("id");

                    if (id != null)
                    {
                        var athlete = _athleteRepository.GetAthleteById(id.GetValueOrDefault())
                                                        .GetAwaiter()
                                                        .GetResult();
                        if (athlete != null)
                            return new List<Jiujiteiro> { athlete };
                        else
                            return new List<Jiujiteiro>();
                    }

                    var jiujitsuAthletes = _athleteRepository.GetAthletes()
                                                             .GetAwaiter()
                                                             .GetResult();

                    return jiujitsuAthletes;
                });
        }

        private void ConfigurePosicoesQuery()
        {
            Field<ListGraphType<PosicaoType>>("posicoes")
                .Arguments(new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }
                ))
                .Resolve(context =>
                {
                    var id = context.GetArgument<int?>("id");

                    if (id != null)
                    {
                        var posicao = _positionRepository.GetPositionById(id.GetValueOrDefault())
                                                         .GetAwaiter()
                                                         .GetResult();
                        if (posicao != null)
                            return new List<Posicao> { posicao };
                        else
                            return new List<Posicao>();
                    }

                    var posicoes = _positionRepository.GetPositions()
                                                      .GetAwaiter()
                                                      .GetResult();
                    return posicoes;
                });
        }
    }
}
