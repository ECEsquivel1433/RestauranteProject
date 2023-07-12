using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SLAPI.Controllers
{
    public class RestauranteController : Controller
    {
        [HttpGet]
        [Route("api/Restaurante/GetAll")]
        public IActionResult GetAll(ML.Restaurante restaurante)
        {
            ML.Result result = BL.Restaurante.GetAll(restaurante);
            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPost]
        [Route("api/Restaurante/GetById")]
        public IActionResult GetById([FromBody]int IdRestaurante)
        {
            ML.Restaurante restaurante = new ML.Restaurante();
            ML.Result result = BL.Restaurante.GetById(IdRestaurante);
            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPost]
        [Route("api/Restaurante/Add")]
        public IActionResult Add([FromBody] ML.Restaurante restaurante)
        {
            ML.Result result = BL.Restaurante.Add(restaurante);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPut]
        [Route("api/Restaurante/Update")]
        public IActionResult Update([FromBody] ML.Restaurante restaurante)
        {
            ML.Result result = BL.Restaurante.Update(restaurante);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPost]
        [Route("api/Restaurante/Delete")]
        public IActionResult Delete([FromBody] int IdRestaurante)
        {
            ML.Result result = BL.Restaurante.Delete(IdRestaurante);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

    }
}
