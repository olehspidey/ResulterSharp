﻿namespace Resulter.Web.Example.Controllers
{
    using System;
    using System.Net;
    using Extensions;
    using Fabrics;
    using Http;
    using Microsoft.AspNetCore.Mvc;
    using Resulter.AspNetCore;
    using Resulter.Http.Fabrics;

    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return HttpResultFactory
                .CreateFailure("Test error", HttpStatusCode.BadRequest, new Exception("test"))
                .ToActionResult();
        }

        [HttpGet("2")]
        public IActionResult Test2()
        {
            return HttpResultFactory
                .CreateSuccess()
                .ToActionResult();
        }

        [HttpGet("3")]
        public IActionResult Test3()
        {
            return ResultFactory
                .CreateSuccess(new
                {
                    Name =" lol",
                    Age = 290,
                })
                .ToHttpResult(HttpStatusCode.OK)
                .ToActionResult();
        }
    }
}