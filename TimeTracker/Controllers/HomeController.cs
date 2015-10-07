using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracker.Models;

namespace TimeTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Employee employee = new Employee();
            return View(employee);
        }
        [HttpPost]
        public ActionResult Index(Employee objuserlogin)
        {
            var display = EmployeeList().Where(m => m.Email == objuserlogin.Email).FirstOrDefault();
            if (display != null)
            {
                ViewBag.Status = "Email exists";
            }
            else
            {
                ViewBag.Status = "Email does not exist";
            }
            return View(objuserlogin);
        }
        public List<Employee> EmployeeList()
        {
            List<Employee> objModel = new List<Employee>();
            objModel.Add(new Employee() { FirstName = "Tom", LastName = "Shaw", PhoneNumber = "225-938-9501", Email = "tom@trshaw.com", IsManager = true });
            objModel.Add(new Employee() { FirstName = "Greg", LastName = "Lemond", PhoneNumber = "225-555-1221", Email = "greg@cox.net" });
            objModel.Add(new Employee() { FirstName = "Laurent", LastName = "Fignon", PhoneNumber = "225-555-1234", Email = "eightseconds@sourgrapes.com", IsManager = false });
            return objModel;
        }
        }
    }

            /*
            ViewBag.Title = "Home Page";

            return View();
            */

