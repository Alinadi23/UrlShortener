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

namespace UrlShortener.BL.ShortUrls.Sevices
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
                var shortUrlCode = string.Empty;
                var existingOriginalUrl = await _shortUrlRepository.GetByOriginalUrl(shortUrlDto.OriginalUrl);
                if (existingOriginalUrl == null)
                {
                    var createResult = await CreateNewShortUrl(shortUrlDto.OriginalUrl);
                    shortUrlCode = createResult.ShortUrlCode;
                }
                else
                {
                    shortUrlCode = existingOriginalUrl.ShortUrlCode;
                }

                return shortUrlCode;
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


        private async Task<ShortUrl> CreateNewShortUrl(string originalUrl)
        {
            var shortUrl = new ShortUrl { OriginalUrl = originalUrl };
            await _shortUrlRepository.Create(shortUrl);
            shortUrl.ShortUrlCode = EncodeUrl(shortUrl.Id);
            await _shortUrlRepository.Update(shortUrl);
            return shortUrl;
        }
        private string EncodeUrl(int id)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(id.ToString());
            var encodedText = Convert.ToBase64String(plainTextBytes);
            return encodedText;
        }
    }

}
