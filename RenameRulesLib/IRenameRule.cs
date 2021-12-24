using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRulesLib
{
    public interface IRenameRule
    {
        string Details { get; }
        string Rename(string origin);
        IRenameRule Clone();
        IRenameRule Clone(string line);
    }
}
