using GraphQL.Types;

namespace JiuJitsuRecords.WebAPI.Schemas.Types
{
    public class EstiloPreferencialType : EnumerationGraphType
    {
        public EstiloPreferencialType()
        {
            Name = "EstiloPreferencial";
            Add("Guard", 2);
            Add("Pass", 4);
            Add("Any", 8);
        }
    }
}
