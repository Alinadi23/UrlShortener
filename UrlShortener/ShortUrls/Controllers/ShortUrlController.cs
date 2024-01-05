using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.BL.ShortUrls.DTO;
using UrlShortener.BL.ShortUrls.ServiceContracts;
using UrlShortener.UI.Properties;

namespace UrlShortener.UI.ShortUrls.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShortUrlController : ControllerBase
    {
        private readonly IShortUrlService _shortUrlService;

        public ShortUrlController(IShortUrlService shortUrlService)
        {
            _shortUrlService = shortUrlService;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateShortUrl(ShortUrlDTO model)
        {
            var encodedText = await _shortUrlService.GenerateShortUrl(model);
            var encodedUrl = Url.Action(action : "RedirectToOriginalUrl", controller :"ShortUrl", new { Path = encodedText }, Request.Scheme);

            return Ok(encodedUrl);
        }

        [HttpGet]
        public async Task<IActionResult> RedirectToOriginalUrl(string path)
        {
            var unescapedPath = Uri.UnescapeDataString(path);
            var shortUrl = await _shortUrlService.GetOriginalUrl(unescapedPath);
            if (shortUrl == null)
            {
                return NotFound(new { ErrorMessage = Resources.PageNotFound });
            }

            return Redirect(shortUrl.OriginalUrl);
        }
    }
}
