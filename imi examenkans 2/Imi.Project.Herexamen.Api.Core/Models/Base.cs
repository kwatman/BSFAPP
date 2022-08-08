using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Herexamen.Api.Core.Models
{
    public abstract class Base
    {
        [Key]
        public Guid Id { get; set; }
    }
}