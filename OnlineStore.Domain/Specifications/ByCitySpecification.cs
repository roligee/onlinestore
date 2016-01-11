using BlastAsia.Infra.Specifications;
using OnlineStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Specifications
{
    public class ByCitySpecification : CompositeSpecification<Customer>
    {
        private String city;
        public ByCitySpecification(string city)
        {
            this.city = city;
        }
        public override bool IsSatisfiedBy(Customer o)
        {
            return o.City == city;
        }
    }
}
