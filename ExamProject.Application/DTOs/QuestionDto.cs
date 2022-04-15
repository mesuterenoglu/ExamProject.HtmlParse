using System;
using System.Collections.Generic;

namespace ExamProject.Application.DTOs
{
    public class  QuestionDto
    {
        public Guid Id { get; set; }
      
        public string QuestionHeader { get; set; }

        public List<QuestionOptionDto> Options { get; set; }

        public Guid ExamId { get; set; }
        
        public ExamDto Exam { get; set; }
    }
}
