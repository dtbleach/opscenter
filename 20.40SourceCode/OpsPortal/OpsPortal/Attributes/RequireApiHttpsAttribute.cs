using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System;
using System.Net;

namespace OpsPortal.Attributes
{
    public class RequireApiHttpsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
        }
    }
}