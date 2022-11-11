using GraphQL;
using GraphQL.Types;
using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;

namespace JiuJitsuRecords.WebAPI.Schemas
{
    public class JiujiteirosMutation : ObjectGraphType
    {
        private readonly IAthleteRepository _athleteRepository;

        public JiujiteirosMutation(IAthleteRepository athleteRepository)
        {
            _athleteRepository = athleteRepository;

            // TODO: finish registration logic
            Field<JiujiteiroType>("registerAthlete")
                .Arguments(new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<StringGraphType> { Name = "apelido" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "nome" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "sobrenome" },
                    new QueryArgument<StringGraphType> { Name = "descricao" }
                ))
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    var apelido = context.GetArgument<string>("apelido") ?? string.Empty;
                    var nome = context.GetArgument<string>("nome") ?? string.Empty;
                    var sobrenome = context.GetArgument<string>("sobrenome") ?? string.Empty;
                    var descricao = context.GetArgument<string>("descricao") ?? string.Empty;

                    var athlete = new Jiujiteiro(id, apelido, nome, sobrenome, DateTimeOffset.Now, PosicaoPreferencial.Any, descricao);

                    _athleteRepository.InsertAthlete(athlete);

                    return athlete;
                });
        }
    }
}