using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApplication.Data
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool isCompiled { get; set; }

    }
}
