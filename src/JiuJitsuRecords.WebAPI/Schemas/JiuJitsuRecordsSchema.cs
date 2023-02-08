using GraphQL;
using GraphQL.Types;
using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.WebAPI.Schemas.Types;
using JiuJitsuRecords.WebAPI.Schemas.Types.InputTypes;

namespace JiuJitsuRecords.WebAPI.Schemas
{
    public class JiuJitsuRecordsSchema : Schema
    {
        public JiuJitsuRecordsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            RegisterMappings();

            Query = serviceProvider.GetRequiredService<JiuJitsuRecordsQuery>();
            Mutation = serviceProvider.GetRequiredService<JiuJitsuRecordsMutation>();
        }

        private void RegisterMappings()
        {
            this.RegisterTypeMapping<Posicao, PosicaoType>();
            this.RegisterTypeMapping<Posicao, PosicaoInputType>();
        }
    }
}
