using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace KING_ICT.Web.Api.Controllers
{
    [ApiController]
    [Route("api/proizvodi")]
    public class ProductsController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ProductsController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                // Formiramo URL za dohvaćanje proizvoda
                string url = "https://dummyjson.com/products";

                // Šaljemo GET zahtjev API-ju
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                // Provjeravamo jesu li podaci uspješno dohvaćeni
                if (response.IsSuccessStatusCode)
                {
                    // Ako je odgovor uspješan, vraćamo OK odgovor s podacima
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return Ok(responseBody);
                }
                else
                {
                    // Ako je odgovor neuspješan, vraćamo odgovarajući statusni kod
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                // U slučaju greške, vraćamo internu server grešku
                return StatusCode(500, ex.Message);
            }
        }
    }
}
