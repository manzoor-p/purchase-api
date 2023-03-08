using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
        IPurchaseRepository Purchase { get; }
        IUserRepository User { get; }
        IUserApiKeyRepository UserApiKey { get; }
        void Save();
    }
}
