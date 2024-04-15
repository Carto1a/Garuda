using Domain.Dtos.Websockets;

namespace Server.Services.Interfaces;
public interface IAuthenticatorService
{
    bool Authenticate(UserSimpleAuthenticateDto request);
}
