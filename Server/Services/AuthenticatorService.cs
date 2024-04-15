using Domain.Dtos.Websockets;
using Server.Services.Interfaces;

namespace Server.Services;
public class AuthenticatorService
: IAuthenticatorService
{
    public AuthenticatorService()
    {
    }

    public bool Authenticate(UserSimpleAuthenticateDto request)
    {
        if (request.Username == "Carlos")
            return true;

        return false;
    }
}
