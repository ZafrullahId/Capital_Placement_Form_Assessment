using Domain.Contracts;
using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
     public class PersonalInformation : AuditableEntity
    {
        [Required]
        public string FirstName { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
        [Required]
        public string Email { get; set; } = default!;
        public string? Phone { get; set; }
        public string? Nationality { get; set; }
        public string? CurrentResidence { get; set; }
        public string? IDNumber { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
    }
}
