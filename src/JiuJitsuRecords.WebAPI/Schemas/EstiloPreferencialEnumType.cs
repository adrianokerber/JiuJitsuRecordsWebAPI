using GraphQL.Types;

namespace JiuJitsuRecords.WebAPI.Schemas
{
    public class EstiloPreferencialEnumType : EnumerationGraphType
    {
        public EstiloPreferencialEnumType()
        {
            Name = "EstiloPreferencial";
            Add("Guard", 2);
            Add("Pass", 4);
            Add("Any", 8);
        }
    }
}
