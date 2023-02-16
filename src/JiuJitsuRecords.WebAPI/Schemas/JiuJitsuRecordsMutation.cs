using GraphQL;
using GraphQL.Types;
using JiuJitsuRecords.Application.Entities;
using JiuJitsuRecords.Application.Interfaces;
using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Services;
using JiuJitsuRecords.WebAPI.Schemas.Types;
using JiuJitsuRecords.WebAPI.Schemas.Types.InputTypes;

namespace JiuJitsuRecords.WebAPI.Schemas
{
    public class JiuJitsuRecordsMutation : ObjectGraphType
    {
        private readonly IJiujitsuAthleteService _jiujitsuAthleteService;
        private readonly IPositionService _positionService;

        public JiuJitsuRecordsMutation(IJiujitsuAthleteService jiujitsuAthleteService, IPositionService positionService)
        {
            _jiujitsuAthleteService = jiujitsuAthleteService;
            _positionService = positionService;

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
                    var id = context.GetArgument<int>("id"); // TODO: remove ID from mutation? We are not using it right now
                    var apelido = context.GetArgument<string>("apelido") ?? string.Empty;
                    var nome = context.GetArgument<string>("nome") ?? string.Empty;
                    var sobrenome = context.GetArgument<string>("sobrenome") ?? string.Empty;
                    var nascimento = context.GetArgument<DateTime>("nascimento", default);
                    var estiloPreferencial = context.GetArgument<EstiloPreferencial>("estiloPreferencial");
                    var descricao = context.GetArgument<string>("descricao") ?? string.Empty;
                    var posicoesInput = context.GetArgument<List<Posicao>>("posicoes") ?? new List<Posicao>();

                    var athlete = new AthleteDto(apelido, nome, sobrenome, nascimento, estiloPreferencial, descricao);
                    var jiujiteiro = await _jiujitsuAthleteService.RegisterJiujitsuAthleteWithPositions(athlete, posicoesInput);

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

                    var posicao = await _positionService.RegisterPosition(posicaoInput);

                    return posicao;
                });
        }
    }
}