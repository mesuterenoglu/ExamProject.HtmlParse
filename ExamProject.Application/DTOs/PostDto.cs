

using System;

namespace ExamProject.Application.DTOs
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
