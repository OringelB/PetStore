using PetStore.Data;
using PetStore.Models;

namespace PetStore.Repositories
{
    public class UserRepository : IUserRepository
    {
        PetContext _context;

        public UserRepository(PetContext context)
        {
            _context = context;
        }

        public int GetUserRank(User user)
        {
            var obj = _context.Users!.Where(a => a.UserName.Equals(user.UserName) && a.Password.Equals(user.Password)).FirstOrDefault();
            return obj!.UserRank;
        }

        public bool LoginCheck(User user)
        {
            var obj = _context.Users!.Where(a => a.UserName.Equals(user.UserName) && a.Password.Equals(user.Password)).FirstOrDefault();
            if (obj == null)
            {
                return false;
            }
            return true;
        }
        public void AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }
    }
}
