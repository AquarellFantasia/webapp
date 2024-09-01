using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace webapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string ApiKey = "api key";

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [BindProperty]
        public string Location { get; set; }

        public WeatherData WeatherData { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Location))
            {
                return Page();
            }

            var client = _clientFactory.CreateClient();
            var response = await client.GetStringAsync($"http://api.weatherapi.com/v1/current.json?key={ApiKey}&q={Location}");

            WeatherData = JsonSerializer.Deserialize<WeatherData>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return Page();
        }
    }

    public class WeatherData
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
    }

    public class Current
    {
        public float Temp_C { get; set; }
        public float Temp_F { get; set; }
        public Condition Condition { get; set; }
    }

    public class Condition
    {
        public string Text { get; set; }
    }
}
