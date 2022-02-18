using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Weather.Filter
{
    public class NotFoundCityException : System.Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is Weather.Contracts.Exseption.NotFoundCityExseption)
            {
                exceptionContext.Result = new RedirectResult("~/Weather/Exception");
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}
