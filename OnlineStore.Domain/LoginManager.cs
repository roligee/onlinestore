using BlastAsia.Infra.Specifications;
using OnlineStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain
{
    public class LoginManager
    {
        private IEmployeeRepository repository;
        public LoginManager(IEmployeeRepository repository)
        {
            this.repository = repository;
        }
        public string Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                return "";
            }
            var filter = new ExpressionSpecification<Employee>(
                (e) => e.UserName == username);
            var employees = repository.Find(filter);

            if (employees == null || employees.Count() == 0)
            {
                throw new ApplicationException("Invalid user name or password.");
            }

            var employee = employees.First();
            if (employee.Password != password)
            {
                throw new ApplicationException("Invalid username or password.");
            }
            return "Login successful!";
        }
    }
}
