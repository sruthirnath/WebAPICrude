using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApicrud.Models;

namespace WebApicrud
{
    public class BusinessService
    {
        public stud_Details generatetoken(string name, string password)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(50000000);
            var tokd = new stud_Details
            {
                Expiry = expiredOn,
                Token = token,
                UserName=name
            };
            StudentEntities2 obj = new StudentEntities2();
            obj.stud_Details.Add(tokd);
            obj.SaveChanges();
            return tokd;

        }
        public bool ValidateToken(string token)
        {
            StudentEntities2 db = new StudentEntities2();
            var res = (from s in db.stud_Details where s.Token == token select s).FirstOrDefault();
            if (res == null)
                return true;
            else
                return false;

        }
    }
}







    