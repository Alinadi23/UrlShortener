using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.BL.ShortUrls.DTO;
using UrlShortener.DAL.ShortUrls.Models;

namespace UrlShortener.BL.ShortUrls.Mapper
{
    public class ShortUrlMapper : Profile
    {
        public ShortUrlMapper()
        {
            CreateMap<ShortUrlDTO, ShortUrl>().ReverseMap();
        }
    }
}
