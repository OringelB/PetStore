using PetStore.Models;

namespace PetStore.Repositories
{
    public interface ICommentRepository
    {
        void AddNewComment(Comment comment);
    }
}
