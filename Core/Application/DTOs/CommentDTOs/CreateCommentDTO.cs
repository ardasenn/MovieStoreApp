using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CommentDTOs
{
    public class CreateCommentDTO
    {
        public Movie Movie { get; set; }
        public Customer Customer { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; } = 1;
    }
    public class CreateCommentResponse
    {
        public bool Succeded { get; set; } = true;
        public string Message { get; set; }
    }
}
