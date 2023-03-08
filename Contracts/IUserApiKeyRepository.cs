using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserApiKeyRepository
    {
        UserApiKey CreateApiKey(User user);
        UserApiKey GetByApiKey(string key);
    }
}
