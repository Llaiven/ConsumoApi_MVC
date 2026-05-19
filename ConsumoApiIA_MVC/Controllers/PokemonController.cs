using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using ConsumoApiIA_MVC.Models;

namespace ConsumoApiIA_MVC.Controllers
{
    public class PokemonController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        // GET: Pokemon
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pokemon/Buscar?nombre=pikachu
        public async Task<ActionResult> Buscar(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                ViewBag.Error = "Ingresa el nombre de un Pokémon.";
                return View("Index");
            }

            try
            {
                string url = $"https://pokeapi.co/api/v2/pokemon/{nombre.ToLower().Trim()}";

                // Configurar HttpClient
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                // Realizar solicitud GET al endpoint
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Error = "Pokémon no encontrado. Verifica el nombre.";
                    return View("Index");
                }

                // Deserializar JSON con Newtonsoft.Json
                string json = await response.Content.ReadAsStringAsync();
                PokemonModel pokemon = JsonConvert.DeserializeObject<PokemonModel>(json);

                // Enviar datos a la Vista
                return View("Resultado", pokemon);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al conectar con la API: " + ex.Message;
                return View("Index");
            }
        }
    }
}