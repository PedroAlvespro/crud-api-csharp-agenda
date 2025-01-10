
namespace TRIMAPAPI.recordsUser
{
    public record Users(int Id, object testEncoder, string Email, string Password, string []Roles);
}