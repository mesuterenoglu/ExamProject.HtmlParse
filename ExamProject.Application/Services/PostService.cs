
using AutoMapper;
using ExamProject.Application.DTOs;
using System.Threading.Tasks;
using ExamProject.Domain.Entities;
using System;
using ExamProject.Domain.Interfaces;
using System.Collections.Generic;
using ExamProject.Application.ServiceInterfaces;

namespace ExamProject.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(PostDto entity)
        {
            try
            {
                var post = _mapper.Map<Post>(entity);
                await _postRepository.AddAsync(post);
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
                return await _postRepository.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> AnybyHeaderandAuthor(string header, string author)
        {
            try
            {
                var result = await _postRepository.AnybyHeaderandAuthor(header, author);
                return result;

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
                await _postRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<PostDto>> GetAllActiveAsync()
        {
            try
            {
                var posts = await _postRepository.GetAllActiveAsync();
                var dtos = _mapper.Map<List<PostDto>>(posts);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<PostDto>> GetAllAsync()
        {
            try
            {
                var posts = await _postRepository.GetAllAsync();
                var dtos = _mapper.Map<List<PostDto>>(posts);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<PostDto>> GetAllInActiveAsync()
        {
            try
            {
                var posts = await _postRepository.GetAllInActiveAsync();
                var dtos = _mapper.Map<List<PostDto>>(posts);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<PostDto> GetbyIdAsync(Guid id)
        {
            try
            {
                var post = await _postRepository.GetbyIdAsync(id);
                var dto = _mapper.Map<PostDto>(post);
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
                await _postRepository.RemoveFromDbAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task UpdateAsync(PostDto entity)
        {
            try
            {
                var post = await _postRepository.GetbyIdAsync(entity.Id);
                _mapper.Map<PostDto, Post>(entity, post);

                await _postRepository.UpdateAsync(post);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
