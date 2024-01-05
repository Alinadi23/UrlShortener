using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.BL.DTO;
using UrlShortener.BL.ServiceContracts;

namespace UrlShortener.Infra.Services
{
    public class ShortUrlService : IShortUrlService
    {


        public ShortUrlService()
        {
        }

        public string GenerateShortUrl(ShortUrlDTO shortUrlDto)
        {
            throw new NotImplementedException();
        }

        public ShortUrlDTO GetOriginalUrl(string path)
        {
            throw new NotImplementedException();
        }

    }
}
