using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private ICustomerRepository _customer;
        private IPurchaseRepository _purchase;
        private IUserRepository _user;
        private IUserApiKeyRepository _userApiKey;

        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_repositoryContext);
                }
                return _customer;
            }
        }
        public IPurchaseRepository Purchase { 
            get {
                if (_purchase == null) { 
                    _purchase = new PurchaseRepository(_repositoryContext);
                }
                return _purchase;
            }
        }
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repositoryContext);
                }
                return _user;
            }
        }
        public IUserApiKeyRepository UserApiKey
        {
            get
            {
                if (_userApiKey == null)
                {
                    _userApiKey = new UserApiKeyRepository(_repositoryContext, _user);
                }
                return _userApiKey;
            }
        }
        public RepositoryWrapper(RepositoryContext repositoryContext)
        { 
            _repositoryContext = repositoryContext;
        }

        public void Save()
        { 
            _repositoryContext.SaveChanges();
        }
    }
}
