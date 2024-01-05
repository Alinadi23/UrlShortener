using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.DAL.Models;

namespace UrlShortener.DAL.RepositoryContracts
{
    public interface IShortUrlRepository
    {
        public ShortUrl GetByEncodedUrl(string url);
        int Create(ShortUrl shortUrl);
        void Update(ShortUrl shortUrl);
    }
}
