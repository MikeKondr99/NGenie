using Microsoft.IdentityModel.Tokens;

namespace NGenieBack.Auth;

// Ключ для проверки подписи (публичный)
public interface IJwtSigningDecodingKey
{
    SecurityKey GetKey();
}
