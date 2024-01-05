using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.BL.ShortUrls.DTO;

namespace UrlShortener.BL.ShortUrls.ServiceContracts
{
    public interface IShortUrlService
    {
        public ShortUrlDTO GetOriginalUrl(string path);

        string GenerateShortUrl(ShortUrlDTO shortUrlDto);
    }
}
