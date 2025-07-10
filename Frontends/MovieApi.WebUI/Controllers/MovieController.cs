using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.MovieDtos;
using Newtonsoft.Json;
using NuGet.Versioning;

namespace MovieApi.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IHttpClientFactory _httoClientFactory;

        public MovieController(IHttpClientFactory httoClientFactory)
        {
            _httoClientFactory = httoClientFactory;
        }

        public async Task< IActionResult> MovieList()
        {
            ViewBag.v1 = "Film Listesi";
            ViewBag.v2 = "Anasayfa";
            ViewBag.v3 = "Tüm Filmler";

            var client = _httoClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7291/api/Movies");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData);

                return View(values);
            }

            return View();
        }
        public async Task<IActionResult> MovieDetail(int id)
        {
            id = 0;
            return View();
        }
    }
}
