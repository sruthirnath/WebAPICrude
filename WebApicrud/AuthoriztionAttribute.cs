﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApicrud
{
    public class AuthoriztionAttribute:ActionFilterAttribute
    {
        private const string Token = "Token";
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            var pro = new BusinessService();
            if (filterContext.Request.Headers.Contains(Token))
            {
                var tokenValue = filterContext.Request.Headers.GetValues(Token).First();

                if(pro!=null&&!pro.ValidateToken(tokenValue))
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "invalid Request" };
                    filterContext.Response = responseMessage;
                }
            }
            else
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}