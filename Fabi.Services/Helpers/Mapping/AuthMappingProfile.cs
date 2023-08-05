using AutoMapper;
using Fabi.Core.DTOs;
using Fabi.Core.Entities.Models;

namespace Fabi.Services.Helpers.Mapping;
public class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        CreateMap<RegisterDto, ApplicationUser>();
    }
}
