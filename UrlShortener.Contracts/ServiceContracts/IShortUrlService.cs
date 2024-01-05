using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Contracts.DTO;

namespace UrlShortener.Contracts.ServiceContracts
{
    public interface IShortUrlService
    {
        public ShortUrlDTO GetOriginalUrl(string path);

        string GenerateShortUrl(ShortUrlDTO shortUrlDto);
    }
}
