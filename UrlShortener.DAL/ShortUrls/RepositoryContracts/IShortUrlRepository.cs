using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.DAL.ShortUrls.Models;

namespace UrlShortener.DAL.ShortUrls.RepositoryContracts
{
    public interface IShortUrlRepository
    {
        public Task<ShortUrl> GetByShortUrlCode(string code);
        public Task<ShortUrl> GetByOriginalUrl(string originalUrl);
        Task<int> Create(ShortUrl shortUrl);
        Task Update(ShortUrl shortUrl);
    }
}
