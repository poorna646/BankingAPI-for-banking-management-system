namespace BankingAPI.Models;

/// <summary>
/// Shape of the JSON body Postman sends when creating a user (no Id — SQL generates it).
/// </summary>
public class CreateUserRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
