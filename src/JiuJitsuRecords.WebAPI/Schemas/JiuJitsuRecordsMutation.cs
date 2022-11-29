using GraphQL;
using GraphQL.Types;
using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;

namespace JiuJitsuRecords.WebAPI.Schemas
{
    public class JiuJitsuRecordsMutation : ObjectGraphType
    {
        private readonly IAthleteRepository _athleteRepository;
        private readonly IPositionRepository _positionRepository;

        public JiuJitsuRecordsMutation(IAthleteRepository athleteRepository, IPositionRepository positionRepository)
        {
            _athleteRepository = athleteRepository;
            _positionRepository = positionRepository;

            // TODO: finish registration logic
            Field<JiujiteiroType>("registerAthlete")
                .Arguments(new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<StringGraphType> { Name = "apelido" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "nome" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "sobrenome" },
                    new QueryArgument<StringGraphType> { Name = "descricao" }
                    //new QueryArgument<IntGraphType>() { Name = "posicoes" }
                ))
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    var apelido = context.GetArgument<string>("apelido") ?? string.Empty;
                    var nome = context.GetArgument<string>("nome") ?? string.Empty;
                    var sobrenome = context.GetArgument<string>("sobrenome") ?? string.Empty;
                    var descricao = context.GetArgument<string>("descricao") ?? string.Empty;
                    //var posicoes = context.GetArgument<List<Posicao?>>("posicoes") ?? new List<Posicao?>();
                    var posicaoIds = context.GetArgument<List<int>>("posicoes") ?? new List<int>();

                    var jiujiteiro = new Jiujiteiro(id,
                                                    apelido,
                                                    nome,
                                                    sobrenome,
                                                    DateTimeOffset.Now,
                                                    EstiloPreferencial.Any,
                                                    descricao,
                                                    //posicoes.Select(x => x!.Id));
                                                    posicaoIds);
                    // TODO: properly configure mutation of Athlete + position

                    // TODO: verify if we should create a new position based on the input if the position is not already registered. Match only name not ID

                    _athleteRepository.InsertAthlete(jiujiteiro);

                    return jiujiteiro;
                });

            // TODO: add logic to _positionRepository
        }
    }
}