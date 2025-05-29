namespace Application.DTOs;

public class LoginUserDto
{
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
}
