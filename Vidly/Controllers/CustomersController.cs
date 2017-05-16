using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //ApplicationDbContext is used to query database tables
        private ApplicationDbContext _context;

        //Constructor
        public CustomersController()
        {
            //Initializing ApplicationDbContext to use in the other action results
            _context = new ApplicationDbContext();
        }

        //Disposing the _context ApplicationDbContext as it is a disposable object (Beginner )
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            
        }

        // GET: Customers
        public ActionResult Index()
        {
            //Querying DB Selecting Customers -- EagerLoading with Include to include MembershipType to access MembershipType properties

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        //Attribute for validating 
        [ValidateAntiForgeryToken]
        //Binds the values from form to a model in Customer
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            //If Customer id is 0 therefore new customer add into db
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                //Search the Db for the customer using id and update
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //Manually Set the properties however in future Automapper can be used 
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                
            }
           
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Details(int id)
        {
            //Query through DbSet Customers
            var selectedCustomer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (selectedCustomer == null)
            {
                return HttpNotFound();
            }
            return View(selectedCustomer);
        }


    }



}