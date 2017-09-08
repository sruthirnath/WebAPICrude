using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApicrud.Models;

namespace WebApicrud.Controllers
{
    public class SampleController : ApiController
    {
        [HttpPost]
        [Route("create")]
        public IHttpActionResult create(stud_Details s)
        {

            StudentEntities2 obj = new StudentEntities2();
            obj.stud_Details.Add(s);
            obj.SaveChanges();
            return Ok("successfull");
        }
        [HttpGet]
        [Route("list")]
        public IHttpActionResult display()
        {
            StudentEntities2 obj = new StudentEntities2();
            List<stud_Details> li = obj.stud_Details.ToList();
            return Ok(li);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult delete(int id)
        {
            StudentEntities2 obj = new StudentEntities2();
            var del = (from b in obj.stud_Details where b.ID == id select b).FirstOrDefault();
            obj.stud_Details.Remove(del);
            obj.SaveChanges();
            return Ok(" Delete Sucessfull");
        }


        [HttpPost]
        [Route("Login")]
        [Authoriztion]
        public HttpResponseMessage GetAuthToken(stud_Details s)
        {
            BusinessService bs = new BusinessService();
            var token = bs.generatetoken(s.UserName,s.Password);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token",token.Token);
            response.Headers.Add("TokenExpiry", DateTime.Now.AddHours(2).ToString());
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
            return response;

        }


    }

}
