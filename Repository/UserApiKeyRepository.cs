using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserApiKeyRepository : RepositoryBase<UserApiKey>, IUserApiKeyRepository
    {
        private IUserRepository _userRepository;
        public UserApiKeyRepository(RepositoryContext repositoryContext, IUserRepository userRepository)
            : base(repositoryContext)
        {
            _userRepository = userRepository;
        }
        public UserApiKey? GetByApiKey(string key)
        {
            UserApiKey? apiKey =  GetAll()
                        .Include(k => k.User)
                        .SingleOrDefault(k => k.ApiKey == key);
            return apiKey;
        }

        public UserApiKey CreateApiKey(User user)
        {
            var newApiKey = new UserApiKey
            {
                ApiKey = GenerateApiKeyValue(),
                User = user
            };                   
            Create(newApiKey);    

            return newApiKey;
        }
        private string GenerateApiKeyValue() =>
           $"{Guid.NewGuid().ToString()}";
    }
}
