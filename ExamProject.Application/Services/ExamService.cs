using AutoMapper;
using ExamProject.Application.DTOs;
using ExamProject.Application.ServiceInterfaces;
using ExamProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExamProject.Domain.Entities;

namespace ExamProject.Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;

        public ExamService(IExamRepository examRepository,IMapper mapper)
        {
            _examRepository = examRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(ExamDto entity)
        {
            try
            {
                var exam = _mapper.Map<Exam>(entity);
                await _examRepository.AddAsync(exam);
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
                return await _examRepository.AnyAsync(x => x.Id == id);
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
                await _examRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<ExamDto>> GetAllActiveAsync()
        {
            try
            {
                var exams = await _examRepository.GetAllActiveAsync();
                var dtos = _mapper.Map<List<ExamDto>>(exams);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<ExamDto>> GetAllAsync()
        {
            try
            {
                var exams = await _examRepository.GetAllAsync();
                var dtos = _mapper.Map<List<ExamDto>>(exams);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<ExamDto>> GetAllInActiveAsync()
        {
            try
            {
                var exams = await _examRepository.GetAllInActiveAsync();
                var dtos = _mapper.Map<List<ExamDto>>(exams);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<ExamDto> GetbyIdAsync(Guid id)
        {
            try
            {
                var exam = await _examRepository.GetbyIdAsync(id);
                var dto = _mapper.Map<ExamDto>(exam);
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
                await _examRepository.RemoveFromDbAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task UpdateAsync(ExamDto entity)
        {
            try
            {
                var exam = await _examRepository.GetbyIdAsync(entity.Id);
                _mapper.Map<ExamDto, Exam>(entity, exam);
                await _examRepository.UpdateAsync(exam);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
