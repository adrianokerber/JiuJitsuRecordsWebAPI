using GraphQL;
using GraphQL.Types;
using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;
using JiuJitsuRecords.WebAPI.Schemas.InputTypes;

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

            // TODO: finish registration logic and move to specific Resolver class
            Field<JiujiteiroType>("registerAthlete")
                .Arguments(new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<StringGraphType> { Name = "apelido" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "nome" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "sobrenome" },
                    new QueryArgument<DateTimeGraphType> { Name = "nascimento" },
                    new QueryArgument<StringGraphType> { Name = "descricao" },
                    new QueryArgument<ListGraphType<PosicaoInputType>> { Name = "posicoes" }
                ))
                .ResolveAsync(async context =>
                {
                    var id = context.GetArgument<int>("id");
                    var apelido = context.GetArgument<string>("apelido") ?? string.Empty;
                    var nome = context.GetArgument<string>("nome") ?? string.Empty;
                    var sobrenome = context.GetArgument<string>("sobrenome") ?? string.Empty;
                    var nascimento = context.GetArgument<DateTime>("nascimento", default);
                    var descricao = context.GetArgument<string>("descricao") ?? string.Empty;
                    var posicoesInput = context.GetArgument<List<Posicao>>("posicoes") ?? new List<Posicao>();

                    var posicaoIds = new List<int>();
                    foreach (var posicaoInput in posicoesInput)
                    {
                        var posicao = await positionRepository.GetPositionByName(posicaoInput.Nome);
                        if (posicao != null)
                            posicaoIds.Add(posicao.Id);
                    }

                    // TODO: verify if we should create a new position based on the input if the position is not already registered. Match only name not ID

                    var jiujiteiro = new Jiujiteiro(id,
                                                    apelido,
                                                    nome,
                                                    sobrenome,
                                                    nascimento,
                                                    EstiloPreferencial.Any, // TODO: add new input type for this field
                                                    descricao,
                                                    posicaoIds);

                    await _athleteRepository.InsertAthlete(jiujiteiro);

                    return jiujiteiro;
                });

            // TODO: add logic to _positionRepository
        }
    }
}