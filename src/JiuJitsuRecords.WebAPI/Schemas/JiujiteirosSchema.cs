using GraphQL.Types;

namespace JiuJitsuRecords.WebAPI.Schemas
{
    public class JiujiteirosSchema : Schema
    {
        public JiujiteirosSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<JiujiteirosQuery>();
            Mutation = serviceProvider.GetRequiredService<JiujiteirosMutation>();
        }
    }
}
