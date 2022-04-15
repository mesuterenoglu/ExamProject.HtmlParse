using System;

namespace ExamProject.Application.DTOs
{
    public class  QuestionOptionDto
    {
        public Guid Id { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; } 
    }
}
