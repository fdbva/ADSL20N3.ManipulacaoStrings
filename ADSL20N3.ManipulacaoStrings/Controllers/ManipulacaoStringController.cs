using System;
using ADSL20N3.ManipulacaoStrings.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSL20N3.ManipulacaoStrings.Controllers
{
    public class ManipulacaoStringController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Concat(InputResultModel inputResultModel)
        {
            inputResultModel.Results =
                inputResultModel.InputLeft + inputResultModel.InputRight;

            return View("Index", inputResultModel);
        }

        public IActionResult Compare(InputResultModel inputResultModel)
        {
            var isEqual =
                inputResultModel.InputLeft == inputResultModel.InputRight;

            inputResultModel.Results = isEqual ? "Igual" : "Diferente";

            return View("Index", inputResultModel);
        }

        public IActionResult CompareIgnoreCase(InputResultModel inputResultModel)
        {
            var isEqual =
                string.Equals(inputResultModel.InputLeft, inputResultModel.InputRight, StringComparison.OrdinalIgnoreCase);

            inputResultModel.Results = isEqual ? "Igual" : "Diferente";

            ViewData["viewDataExample"] = inputResultModel;
            ViewBag.ViewBagExample = "asd";

            return View("Index", inputResultModel);
        }
    }
}
