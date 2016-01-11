using BlastAsia.Infra.Specifications;
using OnlineStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Specifications
{
    public class PremiumCustomersSpecification : CompositeSpecification<Customer>
    {
        private double creditLimit;
        public PremiumCustomersSpecification(double creditLimit)
        {
            this.creditLimit = creditLimit;
        }

        public PremiumCustomersSpecification() : this(1000000D)
        {

        }

        public override bool IsSatisfiedBy(Customer o)
        {
            return o.CreditLimit >= this.creditLimit;
        }
    }
}
