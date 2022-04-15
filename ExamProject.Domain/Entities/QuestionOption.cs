
using ExamProject.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace ExamProject.Domain.Entities
{
    public class QuestionOption : BaseEntity
    {
        [Required]
        [MaxLength(500)]
        public string Option { get; set; }
        public bool IsCorrect { get; set; } 

    }
}
