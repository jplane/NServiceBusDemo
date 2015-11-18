
using System.Collections.Generic;
using System.Linq;

namespace FooBar.Common.Messages
{
    public class ListJobTypesQueryResult : Message
    {
        private readonly string[] _types = null;

        public ListJobTypesQueryResult(IEnumerable<string> types)
        {
            _types = types.ToArray();
        }

        public IEnumerable<string> JobTypes
        {
            get { return _types; }
        }
    }
}
