using System;

namespace BSFAPP.Api.Core.Models
{
    public class Participation : Base
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid OperationId { get; set; }
        public Operation Operation { get; set; }
    }
}