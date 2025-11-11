using GhazaSystem.Api.Infrastructure.Data;

namespace GhazaSystem.Api.DTOs
{
    public class UserDTOs
    {
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public long National_Code { get; set; }

        public static implicit operator UserDTOs(User v)
        {
            throw new NotImplementedException();
        }
    }
}
