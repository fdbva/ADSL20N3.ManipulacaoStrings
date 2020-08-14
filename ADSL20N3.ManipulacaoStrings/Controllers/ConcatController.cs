using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADSL20N3.ManipulacaoStrings.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSL20N3.ManipulacaoStrings.Controllers
{
    public class ConcatController : Controller
    {
        public IActionResult Index(string left, string right)
        {
            var concatResult = $"{left}{right}";
            return View("Index", concatResult);
        }

        [HttpPost]
        public IActionResult Index2(Index2InputModel index2InputModel)
        {
            var index2ResultModel = new Index2ResultModel();
            index2ResultModel.ConcatResult = $"{index2InputModel.Left}{index2InputModel.Right}";

            return View("Index2", index2ResultModel);
        }
    }
}
