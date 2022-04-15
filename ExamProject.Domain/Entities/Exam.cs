
using ExamProject.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamProject.Domain.Entities
{
    public class Exam:BaseEntity
    {
        public Guid? PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
        public virtual List<Question> Questions { get; set; }
    }
}
