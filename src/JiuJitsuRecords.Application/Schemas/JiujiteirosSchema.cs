namespace JiuJitsuRecords.Application.Schemas
{
    public class JiujiteirosSchema : GraphQL.Types.Schema
    {
        public JiujiteirosSchema(JiujiteirosQuery query) : base()
        {
            Query = query;
        }
    }
}
