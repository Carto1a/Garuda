namespace Domain.Entities.Servers.Users.Informations;
public class UserSimpleExtAuthInfo
: UserSimpleInfo
{
    public string? Token { get; set; }

    public UserSimpleExtAuthInfo(
        Guid id,
        string username,
        string? token)
    : base(id, username)
    {
        Token = token;
    }
}
