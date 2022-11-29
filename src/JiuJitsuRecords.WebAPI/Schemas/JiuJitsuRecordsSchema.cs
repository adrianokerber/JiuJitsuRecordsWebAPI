using GraphQL;
using GraphQL.Types;
using JiuJitsuRecords.Domain.Entities;

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
        }
    }
}
