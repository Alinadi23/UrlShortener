using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.DAL.Data;
using UrlShortener.DAL.Models;
using UrlShortener.DAL.RepositoryContracts;

namespace UrlShortener.Infra.Repositories
{
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly ApplicationDbContext _context;

        public ShortUrlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ShortUrl GetByEncodedUrl(string url)
        {
            throw new NotImplementedException();
        }

        public int Create(ShortUrl shortUrl)
        {
            throw new NotImplementedException();
        }

        public void Update(ShortUrl shortUrl)
        {
            throw new NotImplementedException();
        }
    }
}
