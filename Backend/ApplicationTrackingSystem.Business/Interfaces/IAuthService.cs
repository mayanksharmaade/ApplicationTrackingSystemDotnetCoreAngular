using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSystem.Business.Interfaces
{
    
        public interface IAuthService
        {
            Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
            Task<AuthResponseDto> LoginAsync(LoginDto dto);
            Task<AuthResponseDto> RefreshTokenAsync(string refreshToken);
            Task RevokeTokenAsync(string refreshToken);
        }

    }

