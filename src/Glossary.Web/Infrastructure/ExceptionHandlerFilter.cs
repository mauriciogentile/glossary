using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Web.Http;

namespace Company.Glossary.Web.Infrastructure
{
    public class ExceptionHandlerFilter : ExceptionFilterAttribute
    {
        public ExceptionHandlerFilter()
        {
            this.Mappings = new Dictionary<Type, HttpStatusCode>();
            this.Mappings.Add(typeof(ArgumentNullException), HttpStatusCode.BadRequest);
            this.Mappings.Add(typeof(ArgumentException), HttpStatusCode.BadRequest);
            this.Mappings.Add(typeof(NotFoundException), HttpStatusCode.NotFound);
            this.Mappings.Add(typeof(NotImplementedException), HttpStatusCode.NotImplemented);
        }

        public IDictionary<Type, HttpStatusCode> Mappings
        {
            get;
            private set;
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                var exception = actionExecutedContext.Exception;

                if (actionExecutedContext.Exception is HttpException)
                {
                    var httpException = (HttpException)exception;

                    actionExecutedContext.Response =
                        new HttpResponseMessage((HttpStatusCode)httpException.GetHttpCode());

                }
                else if (this.Mappings.ContainsKey(exception.GetType()))
                {
                    var httpStatusCode = this.Mappings[exception.GetType()];
                    actionExecutedContext.Response = new HttpResponseMessage(httpStatusCode);
                }
                else
                {
                    actionExecutedContext.Response = new HttpResponseException(HttpStatusCode.InternalServerError).Response;
                }
            }
        }
    }
}