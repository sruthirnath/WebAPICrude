using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApicrud
{
    interface IToken
    {
        bool validtoken(int token);
        int generatetoken(int id, string password);
    }
}
