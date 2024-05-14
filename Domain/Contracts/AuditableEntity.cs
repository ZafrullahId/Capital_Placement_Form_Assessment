using System;
namespace Domain.Contracts
{
    public class AuditableEntity : BaseEntity, IAuditableEntity, ISoftDelete
    {
        public DateTime CreatedOn { get ; set; } = DateTime.Now;
        public DateTime LastModifiedOn { get ; set ; } = DateTime.Now;
        public DateTime? DeletedOn { get ; set; } = DateTime.Now;
        public bool IsDeleted { get ; set ; } = false;
        DateTime? IAuditableEntity.CreatedOn { get; set; } = DateTime.Now;
        DateTime? IAuditableEntity.LastModifiedOn { get; set; } = DateTime.Now;
    }
}
