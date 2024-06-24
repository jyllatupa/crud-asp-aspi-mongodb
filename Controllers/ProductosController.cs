using ConsumirAPI_MongoDB.DTO;
using ConsumirAPI_MongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ConsumirAPI_MongoDB.Controllers
{
    public class ProductosController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductosController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7236");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> Index()
        {
            var respuesta = await _httpClient.GetAsync("/Products");

            if (respuesta.IsSuccessStatusCode)
            {
                var productos = await respuesta.Content.ReadAsAsync<List<Products>>();

                return View(productos);
            }
            else
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> Details(string id)
        {
            var respuesta = await _httpClient.GetAsync($"/Products/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var productos = await respuesta.Content.ReadAsAsync<Products>();

                return View(productos);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            var respuesta = await _httpClient.PostAsJsonAsync("/Products", productDTO);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
            var respuesta = await _httpClient.GetAsync($"/Products/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var productos = await respuesta.Content.ReadAsAsync<Products>();

                return View(productos);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ProductDTO productDTO)
        {
            var respuesta = await _httpClient.PutAsJsonAsync($"/Products/{id}", productDTO);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            var respuesta = await _httpClient.GetAsync($"/Products/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var productos = await respuesta.Content.ReadAsAsync<Products>();

                return View(productos);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var respuesta = await _httpClient.DeleteAsync($"/Products/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Error");
            }
        }
    }
}
