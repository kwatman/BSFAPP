using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Models
{
    public class BlogPost : Base
    {
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
    }
}
