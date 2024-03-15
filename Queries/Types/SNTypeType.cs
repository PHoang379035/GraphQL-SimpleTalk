using GraphQL.Types;
using GraphQL_SimpleTalk.Entities;
using System.Xml.Linq;

namespace GraphQL_SimpleTalk.Queries.Types
{
    public class SNTypeType : EnumerationGraphType<SNType>
    {
        public SNTypeType()
        {
            Name = "SNTypeType";
        }
    }
}
