
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.Common.Commands
{
    public class StartJobCommand : Command
    {
        public StartJobCommand()
        {
        }

        public string Name { get; set; }

        public string Payload { get; set; }
    }
}
