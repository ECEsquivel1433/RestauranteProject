using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class RestauranteController : Controller
    {
        private IConfiguration configuration;
        public RestauranteController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Restaurante restaurante = new ML.Restaurante();
            restaurante.Restaurantes = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["WebAPI"]);
                var responseTask = client.GetAsync("Restaurante/GetAll");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();
                    foreach (var resulItem in readTask.Result.Objects)
                    {
                        ML.Restaurante resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Restaurante>(resulItem.ToString());
                        restaurante.Restaurantes.Add(resultItemList);
                    }
                }
            }
                return View(restaurante);
        }

        [HttpPost]
        public IActionResult GetAll(ML.Restaurante restaurante)
        {
            ML.Result result = BL.Restaurante.GetAll(restaurante);
            if (result.Correct)
            {
                restaurante.Restaurantes = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al consultar el restaurante";
            }
            return View(restaurante);
        }
        [HttpGet]
        public ActionResult Form(int IdRestaurante)
        {
            ML.Restaurante restaurante = new ML.Restaurante();
            if (IdRestaurante == null)
            {
                return View(restaurante);
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(configuration["WebAPI"]);
                    var postTask = client.PostAsJsonAsync<int>("Restaurante/GetById", IdRestaurante);
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ML.Restaurante>();
                        readTask.Wait();
                        restaurante = readTask.Result;
                    }
                }
                return View(restaurante);
            }
        }

        [HttpPost]
        public IActionResult Form (ML.Restaurante restaurante)
        {
            ML.Result result = new ML.Result();
            if(restaurante.IdRestaurante == 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(configuration["WebAPI"]);

                    var postTask = client.PostAsJsonAsync<ML.Restaurante>("Restaurante/Add", restaurante);
                    postTask.Wait();

                    var restauranteresult = postTask.Result;
                    if (restauranteresult.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se inserto el restaurante";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al insertar el restaurante";
                    }
                    return PartialView("Modal");
                }
            }
            else
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(configuration["WebAPI"]);
                    var postTask = client.PutAsJsonAsync<ML.Restaurante>("Restaurante/Update", restaurante);
                    postTask.Wait();

                    var restauranteresult = postTask.Result;
                    if(restauranteresult.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se actualizo el restaurante";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al actualizar el restaurante";
                    }
                    return PartialView("Modal");

                }
            }
        }

        public ActionResult Delete(int IdRestaurante)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["WebAPI"]);
                var postTask = client.PostAsJsonAsync<int>("Restaurante/Delete", IdRestaurante);
                postTask.Wait();
                
                var restauranteresult = postTask.Result;
                if (restauranteresult.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se elimino correctamente el restaurante";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al eliminar el restaurante";
                }
            }
            return PartialView("Modal");
        }
    }
}
