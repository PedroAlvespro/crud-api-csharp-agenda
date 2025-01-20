
namespace TRIMAPAPI.recordsUser
{
    public record Users(int Id, object TestEncoder, string Email, string Password, string []Roles);
}