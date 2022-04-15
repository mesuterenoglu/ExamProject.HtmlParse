
using System;
using System.ComponentModel.DataAnnotations;

namespace ExamProject.MVC.Models.Exam
{
    public class CreateExamVM
    {
        public Guid PostId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Question1 { get; set; }

        [Required]
        [MaxLength(500)]
        public string Question1Option1 { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question1Option2 { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question1Option3 { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question1Option4 { get; set; }
        public char Question1CorrectOption { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Question2 { get; set; }

        [Required]
        [MaxLength(500)]
        public string Question2Option1 { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question2Option2 { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question2Option3 { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question2Option4 { get; set; }
        public char Question2CorrectOption { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Question3 { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question3Option1 { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question3Option2 { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question3Option3 { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question3Option4 { get; set; }
        public char Question3CorrectOption { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Question4 { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question4Option1 { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question4Option2 { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question4Option3 { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question4Option4 { get; set; }
        public char Question4CorrectOption { get; set; }

    }
}
