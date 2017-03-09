﻿using Common.Logging;
using System;
using System.IO;
using System.Management.Instrumentation;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace ApiWeb.Handlers
{
    public class CustomExceptionHandler : ExceptionHandler
    {
        private readonly ILog _logger = LogManager.GetLogger<CustomExceptionHandler>();
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context.Exception is InvalidDataException || context.Exception is NullReferenceException)
            {
                context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.BadRequest,
                    new { context.Exception.Message }));
            }
            else if (context.Exception is InstanceNotFoundException)
            {
                context.Result = new NotFoundResult(context.Request);
            }
            else
            {
                context.Result =
                    new ResponseMessageResult(
                        context.Request.CreateResponse(HttpStatusCode.InternalServerError));
            }
            _logger.Error(context.Exception);
        }
    }
}