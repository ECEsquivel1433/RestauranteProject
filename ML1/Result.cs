using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Result
    {
        public bool Correct { get; set; }
        public object Object { get; set; } = default!;
        public List<object> Objects { get; set; } = default!;
    }
}
