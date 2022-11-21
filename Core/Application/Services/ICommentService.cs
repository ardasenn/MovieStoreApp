using Application.DTOs.CommentDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICommentService
    {
        Task<CreateCommentResponse> CreateComment(CreateCommentDTO model);
        Task<UpdateCommentResponse> UpdateComment(UpdateCommentDTO model);
        Task<DeleteCommentResponse> DeleteComment(DeleteCommentDTO model);
        List<Comment> GetAll();
    }
}
