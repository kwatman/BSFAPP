using System;
using System.ComponentModel.DataAnnotations;

namespace BSFAPP.Api.Core.Models
{
    public abstract class Base
    {
        [Key]
        public Guid Id { get; set; }
    }
}