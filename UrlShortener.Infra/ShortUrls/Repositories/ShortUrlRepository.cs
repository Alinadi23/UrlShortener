using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.DAL.Data;
using UrlShortener.DAL.ShortUrls.Models;
using UrlShortener.DAL.ShortUrls.RepositoryContracts;

namespace UrlShortener.Infra.ShortUrls.Repositories
{
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly ApplicationDbContext _context;

        public ShortUrlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ShortUrl> GetByShortUrlCode(string code)
        {
            return await _context.ShortUrls.Where(u => u.ShortUrlCode == code).FirstOrDefaultAsync();
        }

        public async Task<int> Create(ShortUrl shortUrl)
        {
            _context.ShortUrls.Add(shortUrl);
            await _context.SaveChangesAsync();

            return shortUrl.Id;
        }

        public async Task Update(ShortUrl shortUrl)
        {
            _context.ShortUrls.Update(shortUrl);
            await _context.SaveChangesAsync();
        }
    }
}
