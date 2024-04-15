namespace Domain.Dtos.Websockets;
public record UserSimpleAuthenticateDto
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
