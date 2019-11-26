using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MoksnesChrismas.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly IDictionary<string,ChristmasResult> Dict = new Dictionary<string, ChristmasResult>()
        {
            {"3", new ChristmasResult()
            {
                Day = 1,
                Body = "Body för 1"
            }},
            {"4", new ChristmasResult()
            {
                Day = 2,
                Body = "Body för 2"
            }},
        };


        private readonly ILogger<QuestionController> _logger;

        public QuestionController(ILogger<QuestionController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{input}")]
        public ChristmasResult Get(string input)
        {
            if(Dict.TryGetValue(input, out ChristmasResult r))
            {
                return r;
            }

            return new ChristmasResult()
            {
                Success = false,
                Body = "Fel kod..."
            };

        }
    }

    public class ChristmasResult
    {
        public bool Success { get; set; }
        public string ImageUrl { get; set; }
        public string Body { get; set; }
        public int Day { get; set; }
    }
}
