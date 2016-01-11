using OnlineStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Domain.Models;

namespace OnlineStore.Infra.Persistence
{
    public class CustomerRepository
        : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IOnlineStoreDbContext context)
            :base(context)
        {

        }

    }
}
