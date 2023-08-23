using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CodeName
    {
        public CodeName(string code, string name)
        {
            this.code = code;
            this.name = name;
        }
        public string code { get; set; }
        public string name { get; set; }
    }
}
