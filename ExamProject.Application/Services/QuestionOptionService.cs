

using AutoMapper;
using ExamProject.Application.DTOs;
using ExamProject.Application.ServiceInterfaces;
using ExamProject.Domain.Entities;
using ExamProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamProject.Application.Services
{
    public class QuestionOptionService : IQuestionOptionService
    {
        private readonly IQuestionOptionRepository _questionOptionRepository;
        private readonly IMapper _mapper;

        public QuestionOptionService(IQuestionOptionRepository questionOptionRepository,IMapper mapper)
        {
            _questionOptionRepository = questionOptionRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(QuestionOptionDto entity)
        {
            try
            {
                var questionOption = _mapper.Map<QuestionOption>(entity);
                await _questionOptionRepository.AddAsync(questionOption);
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
                return await _questionOptionRepository.AnyAsync(x => x.Id == id);
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
                await _questionOptionRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<QuestionOptionDto>> GetAllActiveAsync()
        {
            try
            {
                var questionOptions = await _questionOptionRepository.GetAllActiveAsync();
                var dtos = _mapper.Map<List<QuestionOptionDto>>(questionOptions);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<QuestionOptionDto>> GetAllAsync()
        {
            try
            {
                var questionOptions = await _questionOptionRepository.GetAllAsync();
                var dtos = _mapper.Map<List<QuestionOptionDto>>(questionOptions);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<QuestionOptionDto>> GetAllInActiveAsync()
        {
            try
            {
                var questionOptions = await _questionOptionRepository.GetAllInActiveAsync();
                var dtos = _mapper.Map<List<QuestionOptionDto>>(questionOptions);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<QuestionOptionDto> GetbyIdAsync(Guid id)
        {
            try
            {
                var questionOption = await _questionOptionRepository.GetbyIdAsync(id);
                var dto = _mapper.Map<QuestionOptionDto>(questionOption);
                return dto;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<string>> GetCorrectOptionsbyExamId(Guid examId)
        {
            try
            {
                var options = await _questionOptionRepository.GetCorrectOptionsbyExamId(examId);
                return options;
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
                await _questionOptionRepository.RemoveFromDbAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task UpdateAsync(QuestionOptionDto entity)
        {
            try
            {
                var questionOption = await _questionOptionRepository.GetbyIdAsync(entity.Id);
                _mapper.Map<QuestionOptionDto, QuestionOption>(entity, questionOption);
                await _questionOptionRepository.UpdateAsync(questionOption);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
