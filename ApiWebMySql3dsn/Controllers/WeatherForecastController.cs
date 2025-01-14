using Microsoft.AspNetCore.Mvc;

namespace ApiWebMySql3dsn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //Os atributos [ApiController] e [Route("[controller]")] indicam que esta classe � um controlador da API
    //e que a rota para acess�-lo ser� determinada pelo nome da classe (nesse caso, "WeatherForecast").
    public class WeatherForecastController : ControllerBase // controlador ASP.NET Core.
    {
        private static readonly string[] Summaries = new[] //Summaries, que cont�m uma lista de descri��es clim�ticas.
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;//uma inst�ncia de logger.

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
            //O construtor WeatherForecastController recebe um par�metro do tipo
            //ILogger<WeatherForecastController> e o atribui ao campo _logger.
        {
            _logger = logger;
        }
        //M�todo de requisi��o HTTP GET:
        [HttpGet(Name = "GetWeatherForecast")]//O m�todo Get() � decorado com o atributo [HttpGet], indicando que � acessado por solicita��es HTTP GET.

        //Ele retorna um IEnumerable<WeatherForecast>.
        public IEnumerable<WeatherForecast> Get()
        {
            //ele gera uma lista de 5 previs�es de tempo fict�cias usando LINQ e Enumerable.Range(1, 5).Select(...)
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast//Para cada �ndice no intervalo de 1 a 5, cria uma nova inst�ncia de WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),//Define a propriedade Date com a data atual mais o �ndice do loop.
                TemperatureC = Random.Shared.Next(-20, 55),//Define a propriedade TemperatureC com um valor aleat�rio entre -20 e 55.
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]//Define a propriedade Summary selecionando aleatoriamente um item do array Summaries.
            })
            .ToArray();//Finalmente, converte a sequ�ncia de previs�es em um array e a retorna.
        }
    }
}
