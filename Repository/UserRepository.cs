using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public User GetUserById(Guid userId)
        {
            return FindByCondition(user => user.UserId.Equals(userId))
                .FirstOrDefault();
        }
        
    }
}
