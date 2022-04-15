using AutoMapper;
using ExamProject.Application.DTOs;
using ExamProject.Domain.Entities;

namespace ExamProject.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Exam, ExamDto>().ReverseMap();

            CreateMap<AppUser, AppUserDto>().ReverseMap();

            CreateMap<Post, PostDto>().ReverseMap();

            CreateMap<Question, QuestionDto>().ReverseMap();

            CreateMap<QuestionOption, QuestionOptionDto>().ReverseMap();
        }
    }
}
