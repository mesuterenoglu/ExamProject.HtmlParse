using AutoMapper;
using ExamProject.Application.DTOs;
using ExamProject.Application.ServiceInterfaces;
using ExamProject.Domain.Interfaces;
using ExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamProject.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository,IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(QuestionDto entity)
        {
            try
            {
                var question = _mapper.Map<Question>(entity);
                await _questionRepository.AddAsync(question);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> AnyAsync(Guid id)
        {
            try
            {
                return await _questionRepository.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _questionRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<QuestionDto>> GetAllActiveAsync()
        {
            try
            {
                var questions = await _questionRepository.GetAllActiveAsync();
                var dtos = _mapper.Map<List<QuestionDto>>(questions);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<QuestionDto>> GetAllAsync()
        {
            try
            {
                var questions = await _questionRepository.GetAllAsync();
                var dtos = _mapper.Map<List<QuestionDto>>(questions);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<QuestionDto>> GetAllInActiveAsync()
        {
            try
            {
                var questions = await _questionRepository.GetAllInActiveAsync();
                var dtos = _mapper.Map<List<QuestionDto>>(questions);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<QuestionDto> GetbyIdAsync(Guid id)
        {
            try
            {
                var question = await _questionRepository.GetbyIdAsync(id);
                var dto = _mapper.Map<QuestionDto>(question);
                return dto;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task RemoveFromDbAsync(Guid id)
        {
            try
            {
                await _questionRepository.RemoveFromDbAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task UpdateAsync(QuestionDto entity)
        {
            try
            {
                var question = await _questionRepository.GetbyIdAsync(entity.Id);
                _mapper.Map<QuestionDto, Question>(entity, question);
                await _questionRepository.UpdateAsync(question);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
