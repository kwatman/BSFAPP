﻿using Imi.Project.Api.Core.DTO_S.BlogPosts;
using Imi.Project.Api.Core.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        protected readonly IBlogPostRepository _blogPostRepository;

        public BlogPostsController(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var blogPosts = await _blogPostRepository.ListAllAsync();
            var blogPostDTO = blogPosts.Select(bp => new BlogPostResponseDTO
            {
                Id = bp.Id,
                Title = bp.Title,
                PostDate = bp.PostDate
            });

            return Ok(blogPostDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(id);

            if (blogPost == null)
            {
                return NotFound($"Geen blogpost met id {id} gevonden");
            }
            else
            {
                var blogPostDTO = new BlogPostResponseDTO
                {
                    Id = blogPost.Id,
                    Title = blogPost.Title,
                    PostDate = blogPost.PostDate
                };

                return Ok(blogPostDTO);
            }
        }
    }
}
