namespace Domain.Dtos.Websockets;
public record UserSimpleAuthenticateDto(
    string? username,
    string? email,
    string? password)
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
