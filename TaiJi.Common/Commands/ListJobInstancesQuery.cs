﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaiJi.Common.Commands
{
    public class ListJobInstancesQuery : Command
    {
        public ListJobInstancesQuery()
        {
        }

        public string ConnectionId { get; set; }
    }
}
