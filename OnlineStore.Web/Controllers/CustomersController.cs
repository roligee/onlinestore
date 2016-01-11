using BlastAsia.Infra.Specifications;
using OnlineStore.Domain;
using OnlineStore.Domain.Models;
using OnlineStore.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Domain.Specifications;

namespace OnlineStore.Web.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerRepository repository;

        public CustomersController(ICustomerRepository repository)
        {
            this.repository = repository;
        }

       
        // GET: Customers
        public ActionResult Index()
        {

           var customers = repository.Find(new ExpressionSpecification<Customer>(c => true));


            return View(customers);
        }

        public ActionResult Create()

        {
            var newCustomer = new Customer();
            return View(newCustomer);

        }


        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(customer);
                }

                repository.Create(customer);
                return RedirectToAction("Index");
            }
            catch (Exception exc)
            {
                // log exception
                return View(customer);
            }
        }

        public ActionResult Edit(int id)

        {
            var customerToEdit = repository.Find(id);

            return View(customerToEdit);

        }


        [HttpPut]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(customer);
                }

                repository.Update(customer);
                return RedirectToAction("Index");
            }
            catch (Exception exc)
            {
                // log exception
                return View(customer);
            }
        }
    }

}