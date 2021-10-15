using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class BlogPost
    {
        public Guid BlogPostId { get; set; }
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
    }
}
