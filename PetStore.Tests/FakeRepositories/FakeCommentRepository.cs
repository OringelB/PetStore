using PetStore.Models;
using PetStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Tests.FakeRepositories
{
    internal class FakeCommentRepository : ICommentRepository
    {
        private IEnumerable<Comment> _comment;
        public FakeCommentRepository()
        {
            _comment = new List<Comment>() { new Comment(), new Comment(), new Comment(), new Comment() };

        }
        public void AddNewComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
