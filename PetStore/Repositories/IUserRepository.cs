using PetStore.Models;

namespace PetStore.Repositories
{
    public interface IUserRepository
    {
        public bool LoginCheck(User user);
        public int GetUserRank(User user);
        public void AddUser(User user);

    }
}
