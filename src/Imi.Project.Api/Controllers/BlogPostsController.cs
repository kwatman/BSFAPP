using Imi.Project.Api.Core.DTO_S.BlogPosts;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Services;
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
        protected readonly IBlogPostService _blogPostService;

        public BlogPostsController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var blogPosts = await _blogPostService.ListAllAsync();
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
            var blogPost = await _blogPostService.GetByIdAsync(id);

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

        [HttpPost]
        public async Task<IActionResult> Add(BlogPostRequestDTO blogPostDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            else
            {
                var blogPostToAdd = new BlogPost
                {
                    Title = blogPostDTO.Title,
                    PostDate = DateTime.Now
                };

                await _blogPostService.AddAsync(blogPostToAdd);

                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(BlogPostRequestDTO blogPostDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            else
            {
                var blogPostToUpdate = await _blogPostService.GetByIdAsync(blogPostDTO.Id);

                if (blogPostToUpdate == null)
                {
                    return NotFound($"Geen blogpost met id {blogPostDTO.Id} gevonden");
                }
                else
                {
                    blogPostToUpdate.Title = blogPostDTO.Title;

                    await _blogPostService.UpdateAsync(blogPostToUpdate);

                    return Ok();
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var blogPostToDelete = await _blogPostService.GetByIdAsync(id);

            if (blogPostToDelete == null)
            {
                return NotFound($"Geen blogpost met id {id} gevonden");
            }
            else
            {
                await _blogPostService.DeleteAsync(blogPostToDelete);

                return Ok();
            }
        }
    }
}
