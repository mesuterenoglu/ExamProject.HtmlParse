
using ExamProject.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamProject.Domain.Entities
{
    public class Question : BaseEntity
    {
        [Required]
        [MaxLength(1000)]
        public string QuestionHeader { get; set; }

        public virtual List<QuestionOption> Options { get; set; }

        [Required]
        public Guid ExamId { get; set; }
        [ForeignKey("ExamId")]
        public virtual Exam Exam { get; set; }
    }
}
