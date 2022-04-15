using ExamProject.Domain.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace ExamProject.Domain.Entities
{
    public class Post:BaseEntity
    {
        [Required]
        [MaxLength(500)]
        public string Header { get; set; }

        [Required]
        [MaxLength(100)]
        public string AuthorName { get; set; }

        [Required]
        [MaxLength(10000)]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime PostedDate { get; set; }
    }
}
