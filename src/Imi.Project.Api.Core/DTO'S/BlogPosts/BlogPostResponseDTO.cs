using Imi.Project.Api.Core.DTO_S.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.DTO_S.BlogPosts
{
    public class BlogPostResponseDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
    }
}
