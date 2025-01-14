using Microsoft.AspNetCore.Mvc;

namespace ApiWebMySql3dsn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //Os atributos [ApiController] e [Route("[controller]")] indicam que esta classe é um controlador da API
    //e que a rota para acessá-lo será determinada pelo nome da classe (nesse caso, "WeatherForecast").
    public class WeatherForecastController : ControllerBase // controlador ASP.NET Core.
    {
        private static readonly string[] Summaries = new[] //Summaries, que contém uma lista de descrições climáticas.
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;//uma instância de logger.

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
            //O construtor WeatherForecastController recebe um parâmetro do tipo
            //ILogger<WeatherForecastController> e o atribui ao campo _logger.
        {
            _logger = logger;
        }
        //Método de requisição HTTP GET:
        [HttpGet(Name = "GetWeatherForecast")]//O método Get() é decorado com o atributo [HttpGet], indicando que é acessado por solicitações HTTP GET.

        //Ele retorna um IEnumerable<WeatherForecast>.
        public IEnumerable<WeatherForecast> Get()
        {
            //ele gera uma lista de 5 previsões de tempo fictícias usando LINQ e Enumerable.Range(1, 5).Select(...)
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast//Para cada índice no intervalo de 1 a 5, cria uma nova instância de WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),//Define a propriedade Date com a data atual mais o índice do loop.
                TemperatureC = Random.Shared.Next(-20, 55),//Define a propriedade TemperatureC com um valor aleatório entre -20 e 55.
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]//Define a propriedade Summary selecionando aleatoriamente um item do array Summaries.
            })
            .ToArray();//Finalmente, converte a sequência de previsões em um array e a retorna.
        }
    }
}
