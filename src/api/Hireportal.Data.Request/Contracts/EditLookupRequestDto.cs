
namespace Hireportal.Data.Request.Contracts
{
    public class EditLookupRequestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
