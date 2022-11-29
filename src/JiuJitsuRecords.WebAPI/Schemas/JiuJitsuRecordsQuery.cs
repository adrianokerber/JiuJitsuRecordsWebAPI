﻿using GraphQL;
using GraphQL.Types;
using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;

namespace JiuJitsuRecords.WebAPI.Schemas
{
    public class JiuJitsuRecordsQuery : ObjectGraphType
    {
        public JiuJitsuRecordsQuery(IAthleteRepository athleteRepository, IPositionRepository positionRepository)
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

            Field<ListGraphType<PosicaoType>>("posicoes")
                .Resolve(context =>
                {
                    var id = context.GetArgument<int?>("id");

                    if (id != null)
                    {
                        var posicao = positionRepository.GetPositionById(id.GetValueOrDefault())
                                                        .GetAwaiter()
                                                        .GetResult();
                        if (posicao != null)
                            return new List<Posicao> { posicao };
                        else
                            return new List<Posicao>();
                    }

                    var posicoes = positionRepository.GetPositions()
                                                     .GetAwaiter()
                                                     .GetResult();
                    return posicoes;
                });
        }
    }
}