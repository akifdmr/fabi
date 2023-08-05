using AutoMapper;
using Fabi.Core.Entities.Models;
using Fabi.Core.DTOs;
using Fabi.Services.Extensions;

namespace Fabi.Services.Helpers.Mapping;
public class MovieMappingProfile : Profile
{
    public MovieMappingProfile()
    {
        CreateMap<Movie, MovieDetailsDto>()
            .ForMember(dest => dest.GenerName, opt => opt.MapFrom(
                src => src.Genre.Name));

        CreateMap<BaseMovieDto, Movie>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(
                src => src.Title.Trim().CapitalizeFistLitter()))
            .ForMember(dest => dest.PosterUrl, opt => opt.Ignore());


    }
}
