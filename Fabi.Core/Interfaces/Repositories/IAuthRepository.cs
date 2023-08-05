﻿using Fabi.Core.DTOs;

namespace Fabi.Core.Interfaces;
public interface IAuthRepository
{
    Task<AuthDto> RegisterAsync(RegisterDto dto);
    Task<AuthDto> GetTokenAsync(LoginDto dto);
    Task<string> AddRoleAsync(AddRoleDto dto);
    Task<AuthDto> RefreshTokenAsync(string token);
    Task<bool> RevokeTokenAsync(string token);
}
