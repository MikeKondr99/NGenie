using Microsoft.IdentityModel.Tokens;

namespace NGenieBack.Auth;

// Ключ для создания подписи (приватный)
public interface IJwtSigningEncodingKey
{
    string SigningAlgorithm { get; }

    SecurityKey GetKey();
}
