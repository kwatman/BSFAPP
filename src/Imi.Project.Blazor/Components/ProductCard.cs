using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Components
{
    public partial class ProductCard
    {
        [Parameter]
        public Guid ProductId { get; set; }
        [Parameter]
        public string Name { get; set; }
        [Parameter]
        public string Description { get; set; }
        [Parameter]
        public string imageUrl { get; set; }
        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
    }
}
