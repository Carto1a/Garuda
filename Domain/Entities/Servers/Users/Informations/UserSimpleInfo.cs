namespace Domain.Entities.Servers.Users.Informations;
public class UserSimpleInfo
{
    public Guid ServerUserId { get; set; }
    public string Username { get; set; }

    public UserSimpleInfo(
        Guid id,
        string? username)
    {
        ServerUserId = id;
        Username = username ?? "Anonymous";
    }
}
