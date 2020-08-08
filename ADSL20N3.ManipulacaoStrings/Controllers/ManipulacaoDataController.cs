using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADSL20N3.ManipulacaoStrings.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSL20N3.ManipulacaoStrings.Controllers
{
    public class ManipulacaoDataController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Compare(InputResultModel inputResultModel)
        {
            var cultureInfo = new CultureInfo("pt-br");
            var leftParseSuccess = DateTime.TryParse(
                inputResultModel.InputLeft, 
                cultureInfo, 
                DateTimeStyles.None, 
                out var parsedLeft);

            if (leftParseSuccess == false)
            {
                inputResultModel.Results = "InputLeft contains invalid Date";
                return View("Index", inputResultModel);
            }

            try
            {
                var parsedRight = DateTime.Parse(inputResultModel.InputRight, cultureInfo);

                inputResultModel.Results = (parsedLeft == parsedRight).ToString();

                return View("Index", inputResultModel);
            }
            catch (Exception e)
            {
                inputResultModel.Results = "InputRight contains invalid Date";
                return View("Index", inputResultModel);
            }
        }

        public IActionResult DatePlusDays(InputResultModel inputResultModel)
        {
            var cultureInfo = new CultureInfo("pt-br");
            var leftParseSuccess = DateTime.TryParse(
                inputResultModel.InputLeft,
                cultureInfo,
                DateTimeStyles.None,
                out var parsedLeft);

            if (leftParseSuccess == false)
            {
                inputResultModel.Results = "InputLeft contains invalid Date";
                return View("Index", inputResultModel);
            }

            var rightParsedSuccess = int.TryParse(inputResultModel.InputRight, out var parsedRight);

            if (rightParsedSuccess == false)
            {
                inputResultModel.Results = "InputRight contains invalid number";
                return View("Index", inputResultModel);
            }

            var newData = parsedLeft.AddDays(parsedRight).AddHours(15);

            inputResultModel.Results = newData.ToString("dd MMM yyyy - HH");
            return View("Index", inputResultModel);
        }
    }
}
