﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.Common.Commands
{
    public class CancelJobCommand : Command
    {
        public CancelJobCommand()
        {
        }

        public Guid Id { get; set; }
    }
}
