using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CommentDTOs
{
    public class DeleteCommentDTO
    {
        public string Id { get; set; }
    }
    public class DeleteCommentResponse
    {
        public bool Succeded { get; set; } = true;
        public string Message { get; set; }
    }
}
