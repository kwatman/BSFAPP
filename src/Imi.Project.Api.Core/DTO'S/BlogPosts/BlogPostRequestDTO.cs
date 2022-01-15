using Imi.Project.Api.Core.DTO_S.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.DTO_S.BlogPosts
{
    public class BlogPostRequestDTO : BaseDTO
    {
        [Required(ErrorMessage = "Titel is verplicht")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Post is verplicht")]
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
    }
}
