using ApplicationTrackingSystem.Business.Interfaces;
using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using ApplicationTrackingSytem.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSystem.Business.Repositories
{
    public class AuthService : IAuthService
    {

        private readonly IUnitofWork _uow;
        private readonly IJwtService _jwt;
        private readonly IPasswordHasher<User> _hasher;

        public AuthService(IUnitofWork uow, IJwtService jwt, IPasswordHasher<User> hasher)
        {
            _uow = uow;
            _jwt = jwt;
            _hasher = hasher;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            var existing = await _uow.Users.GetByEmailAsync(dto.Email);
            if (existing != null)
                throw new InvalidOperationException("Email already registered.");

            var user = new User
            {
                Email = dto.Email,
                Role = dto.Role,
            };
            user.PasswordHash = _hasher.HashPassword(user, dto.Password);
            await _uow.Users.AddAsync(user);
            await _uow.SaveChangesAsync();

            return await GenerateAuthResponse(user);
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _uow.Users.GetByEmailAsync(dto.Email)
                ?? throw new UnauthorizedAccessException("Invalid credentials.");

            if (!user.IsActive)
                throw new UnauthorizedAccessException("Account is disabled.");

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
                throw new UnauthorizedAccessException("Invalid credentials.");

            return await GenerateAuthResponse(user);
        }

        public async Task<AuthResponseDto> RefreshTokenAsync(string refreshToken)
        {
            var user = await _uow.Users.GetWithRefreshTokensAsync(0)
                ?? throw new UnauthorizedAccessException("Invalid token.");

            var stored = user.RefreshTokens
                .FirstOrDefault(rt => rt.Token == refreshToken && !rt.IsRevoked && rt.ExpiresAt > DateTime.UtcNow)
                ?? throw new UnauthorizedAccessException("Token expired or invalid.");

            stored.IsRevoked = true;
            await _uow.SaveChangesAsync();

            return await GenerateAuthResponse(user);
        }

        public async Task RevokeTokenAsync(string refreshToken)
        {
            // Find user by refresh token
            var allUsers = await _uow.Users.GetAllAsync();
            foreach (var u in allUsers)
            {
                var userWithTokens = await _uow.Users.GetWithRefreshTokensAsync(u.Id);
                var token = userWithTokens?.RefreshTokens.FirstOrDefault(t => t.Token == refreshToken);
                if (token != null)
                {
                    token.IsRevoked = true;
                    await _uow.SaveChangesAsync();
                    return;
                }
            }
        }

        private async Task<AuthResponseDto> GenerateAuthResponse(User user)
        {
            var accessToken = _jwt.GenerateAccessToken(user);
            var refreshTokenStr = _jwt.GenerateRefreshToken();

            var refreshToken = new RefreshToken
            {
                UserId = user.Id,
                Token = refreshTokenStr,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
            };

            await _uow.SaveChangesAsync(); // RefreshToken is added via navigation, so just save

            return new AuthResponseDto(
                accessToken,
                refreshTokenStr,
                new UserDto(user.Id, user.Email, user.Role)
            );
        }

    }
}
