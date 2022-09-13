using PetStore.Data;
using PetStore.Models;

namespace PetStore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        PetContext _context;
        public CommentRepository(PetContext context)
        {
            _context = context;
        }
        public void AddNewComment(Comment comment)
        {
            _context.Comments!.Add(comment);
            _context.SaveChanges();
        }
    }
}
