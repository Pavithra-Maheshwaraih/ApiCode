using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiCode.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        static List<Example> examples = new List<Example>()
        {
            new Example(){name="test",phone="test"},
          
        };
        // GET: api/<ExampleController>
        [HttpGet]
        public IEnumerable<Example> Get()
        {
            return examples;


        }


       

       

    }
}
