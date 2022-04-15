

using System;
using System.Collections.Generic;

namespace ExamProject.Application.DTOs
{
    public class ExamDto
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        
        public virtual PostDto Post { get; set; }

        public virtual List<QuestionDto> Questions { get; set; }
    }
}
