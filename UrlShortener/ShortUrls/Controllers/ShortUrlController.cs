using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.DAL.DTO;

namespace UrlShortener.UI.ShortUrls.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortUrlController : ControllerBase
    {

        public ShortUrlController()
        {
        }

        [HttpPost]
        public IActionResult GenerateShortUrl(ShortUrlDTO model)
        {

            return Ok();
        }

        [HttpGet]
        public IActionResult RedirectToOriginalUrl(string path)
        {
            if (path == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
