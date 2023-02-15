using GraphQL;
using GraphQL.Types;
using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;
using JiuJitsuRecords.WebAPI.Schemas.Types;
using JiuJitsuRecords.WebAPI.Schemas.Types.InputTypes;

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

            ConfigureAthleteMutation();
            ConfigurePositionMutation();
        }

        private void ConfigureAthleteMutation()
        {
            Field<JiujiteiroType>("registerAthlete")
                .Arguments(new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<StringGraphType> { Name = "apelido" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "nome" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "sobrenome" },
                    new QueryArgument<DateTimeGraphType> { Name = "nascimento" },
                    new QueryArgument<EstiloPreferencialType> { Name = "estiloPreferencial" },
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
                    var estiloPreferencial = context.GetArgument<EstiloPreferencial>("estiloPreferencial");
                    var descricao = context.GetArgument<string>("descricao") ?? string.Empty;
                    var posicoesInput = context.GetArgument<List<Posicao>>("posicoes") ?? new List<Posicao>();

                    var posicaoIds = new List<int>();
                    foreach (var posicaoInput in posicoesInput)
                    {
                        var posicao = await _positionRepository.GetPositionByName(posicaoInput.Nome);
                        if (posicao == null)
                            posicao = await _positionRepository.InsertPosition(posicaoInput);
                        if (posicao != null)
                            posicaoIds.Add(posicao.Id);
                    }

                    var jiujiteiro = new Jiujiteiro(id,
                                                    apelido,
                                                    nome,
                                                    sobrenome,
                                                    nascimento,
                                                    estiloPreferencial,
                                                    descricao,
                                                    posicaoIds);

                    await _athleteRepository.InsertAthlete(jiujiteiro);

                    return jiujiteiro;
                });
        }

        public void ConfigurePositionMutation()
        {
            Field<PosicaoType>("registerPosition")
                .Arguments(new QueryArguments(
                    new QueryArgument<PosicaoInputType> { Name = "posicao" }
                ))
                .ResolveAsync(async context =>
                {
                    var posicaoInput = context.GetArgument<Posicao>("posicao");

                    var posicao = await _positionRepository.GetPositionByName(posicaoInput.Nome);
                    if (posicao != null)
                        return posicao;
                                
                    posicao = await _positionRepository.InsertPosition(posicaoInput);

                    return posicao;
                });
        }
    }
}