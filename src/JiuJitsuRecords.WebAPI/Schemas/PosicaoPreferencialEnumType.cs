using GraphQL.Types;

namespace JiuJitsuRecords.WebAPI.Schemas
{
    public class PosicaoPreferencialEnumType : EnumerationGraphType
    {
        public PosicaoPreferencialEnumType()
        {
            Name = "Posicao";
            Add("Guard", 2);
            Add("Pass", 4);
            Add("Any", 8);
        }
    }
}
