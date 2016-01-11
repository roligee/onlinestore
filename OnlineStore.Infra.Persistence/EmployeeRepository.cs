using OnlineStore.Domain;
using OnlineStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infra.Persistence
{
    public class EmployeeRepository 
        : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IOnlineStoreDbContext context) 
            : base(context)
        {

        }
    }
}
