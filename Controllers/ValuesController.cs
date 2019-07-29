using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hosted_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace hosted_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly RandomStringService RandomStringService;

        public ValuesController(RandomStringService randomStringService)
        {
            this.RandomStringService = randomStringService;
        }

        [HttpGet]
        public string Get()
        {
            return this.RandomStringService.RandomString;
        }
    }
}
