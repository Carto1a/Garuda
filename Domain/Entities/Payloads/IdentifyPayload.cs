using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads;
public class IdentifyPayload
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Anonymous { get; set; }

    public IdentifyPayload(
        string username,
        string email,
        string password,
        bool anonymous = false)
    {
        this.Username = username;
        this.Email = email;
        this.Password = password;
        this.Anonymous = anonymous;
    }

    public static Payload<IdentifyPayload> Create(
        string token,
        string username,
        string password,
        bool anonymous = false)
    {
        return new Payload<IdentifyPayload>(
            OpCodes.Identify,
            new IdentifyPayload(token, username, password, anonymous),
            null);
    }
}
