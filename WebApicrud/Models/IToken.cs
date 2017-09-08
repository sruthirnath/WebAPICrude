using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApicrud.Models
{
    interface IToken
    {
        
    
        bool ValidateToken(string token);
        
         stud_Details generatetoken(int id, string password);
    }

    
}
