using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamProject.Entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public virtual DateTime CreatedAt { get; set; }

        public virtual DateTime? DeletedAt { get; set; }

        public virtual bool IsDeleted { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            DeletedAt = null;
            IsDeleted = false;
        }

    }
}
