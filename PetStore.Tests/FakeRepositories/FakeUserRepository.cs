using PetStore.Models;
using PetStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Tests.FakeRepositories
{
    internal class FakeUserRepository : IUserRepository
    {
        private IEnumerable<User> _user;
        public FakeUserRepository()
        {
            _user = new List<User>() { new User(), new User(), new User(), new User() };

        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public int GetUserRank(User user)
        {
            throw new NotImplementedException();
        }

        public bool LoginCheck(User user)
        {
            throw new NotImplementedException();
        }
    }
}
