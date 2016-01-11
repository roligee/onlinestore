using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HiredDate { get; set; }
    }
}
