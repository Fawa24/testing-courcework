using ErrorsChecker.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErrorsChecker.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/analyzer")]
        public IActionResult AnalyzerResult(string codeToCheck)
        {
            var errors = ErrorAnalyzer.CheckSyntaxErrors(codeToCheck);

            return View(new ResultModel { Code = codeToCheck, Errors = errors });
        }
    }

    public class ResultModel
    {
        public string Code { get; set; }
        public List<string> Errors { get; set; }
    }
}
