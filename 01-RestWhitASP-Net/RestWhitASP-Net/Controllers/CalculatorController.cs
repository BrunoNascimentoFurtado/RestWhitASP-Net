using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestWhitASP_Net.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        
        
       private readonly ILogger<CalculatorController> _logger;
        public CalculatorController(ILogger<CalculatorController> logger)
        {
            this._logger = logger;
        }


        [HttpGet("soma/{firtNumber}/{secondNumber}")]
            public IActionResult soma(string firstNumber, string secondNumber)
            {
                 if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                 {
                    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                    return Ok(sum.ToString());
                 }

                  return BadRequest("Entrada inválida");
             }

        [HttpGet("subtracao/{firtNumber}/{secondNumber}")]
        public IActionResult Subtracao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Entrada inválida");
        }

        [HttpGet("Multiplicacao/{firtNumber}/{secondNumber}")]
        public IActionResult Multiplicacao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Entrada inválida");
        }


        [HttpGet("Media/{firtNumber}/{secondNumber}")]
        public IActionResult Media(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                sum = sum / 2;
                return Ok(sum.ToString());
            }

            return BadRequest("Entrada inválida");
        }




        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double .TryParse(strNumber,
                //System.Globalization.NumberStyles.Any,
                //System.Globalization.NumberFormatInfo.InvariantInfo, out number);
                out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue ))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}
