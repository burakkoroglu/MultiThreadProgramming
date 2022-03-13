using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger <HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetConnectAsync(CancellationToken cToken)
        {
            try
            {
                _logger.LogInformation("İstek başladı.");

                await Task.Delay(4000, cToken);


                var myTask = new HttpClient().GetStringAsync("https://www.google.com");
                var data = await myTask;

                _logger.LogInformation("İstek bitti.");
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation("İstek İptal Edildi :  {0}",ex.Message);
                return BadRequest();
            }
            
        }

    }
}
