using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.BL.ShortUrls.DTO;
using UrlShortener.BL.ShortUrls.ServiceContracts;
using UrlShortener.DAL.ShortUrls.Models;
using UrlShortener.DAL.ShortUrls.RepositoryContracts;

namespace UrlShortener.Infra.ShortUrls.Services
{
    public class ShortUrlService : IShortUrlService
    {
        private readonly IShortUrlRepository _shortUrlRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ShortUrlService(IShortUrlRepository shortUrlRepository, IMapper mapper)
        {
            _shortUrlRepository = shortUrlRepository;
            _mapper = mapper;
            _logger = new LoggerFactory().CreateLogger<ShortUrlService>();
        }

        public async Task<string> GenerateShortUrl(ShortUrlDTO shortUrlDto)
        {
            try
            {
                var shortUrl = _mapper.Map<ShortUrl>(shortUrlDto);
                await _shortUrlRepository.Create(shortUrl);
                shortUrl.ShortUrlCode = EncodeUrl(shortUrl.Id);
                await _shortUrlRepository.Update(shortUrl);
                return shortUrl.ShortUrlCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ShortUrlDTO> GetOriginalUrl(string path)
        {
            var shortUrl = await _shortUrlRepository.GetByShortUrlCode(path);
            return _mapper.Map<ShortUrlDTO>(shortUrl);
        }

        private string EncodeUrl(int id)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(id.ToString());
            var encodedText = Convert.ToBase64String(plainTextBytes);
            return encodedText;
        }
    }
}
