﻿using AutoMapper;
using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models.Comment;
using ExamManagement.Persistence.Auth;
using ExamManagement.Persistence.Repositories.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services.Comment
{
    public class CommentService : ICommentService
    {

        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<Result<CommentModel>> Add(CommentModel model)
        {
            var commentEntity = _mapper.Map<Entities.Comment>(model);
            commentEntity.DateAdded = DateTime.Now.ToString();

            await _commentRepository.Add(commentEntity);
            await _commentRepository.SaveChanges();

            return _mapper.Map<CommentModel>(commentEntity);
        }

        public Task<Result<CommentModel>> Delete(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<CommentModel>> Get(Guid commentId)
        {
            var comment = await _commentRepository.GetById(commentId);
            return comment == null ? Result.Failure<CommentModel>("Comment not found") : _mapper.Map<CommentModel>(comment);
        }

        public async Task<Result<IList<CommentModel>>> GetByExamId(Guid examId)
        {
            var commentList = await _commentRepository.GetByExamId(examId);
            var returnList = commentList.OrderBy((a) => a.ParentId)
                .Reverse()
                .ToList()
                .Select((comment) => new CommentModel( comment.Id, comment.ParentId, comment.UserId, comment.ExamId, comment.Text, comment.DateAdded)).ToList();

            return Result.Success<IList<CommentModel>>(returnList);
        }

        public Task<Result<CommentModel>> Update(Guid commentId)
        {
            throw new NotImplementedException();
        }
    }
}
