using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambiesoft.AfterRunLib
{
    internal class ExeArg
    {
        string exe_;
        string arg_;
        public ExeArg(string e, string a) { exe_ = e; arg_ = a; }
        public string Exe { get { return exe_; } }
        public string Arg { get { return arg_; } }
    }
}
