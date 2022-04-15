
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamProject.Domain.Entities.Abstract
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsModified { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ModifiedDate { get; set; }
    }
}
