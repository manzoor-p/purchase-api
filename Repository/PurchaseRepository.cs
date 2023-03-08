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
    public class PurchaseRepository : RepositoryBase<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public IEnumerable<Purchase> PurchasesByCustomer(Guid customerId)
        { 
            return FindByCondition(p=> p.IdCustomer.Equals(customerId)).ToList();
        }
    }    
}
