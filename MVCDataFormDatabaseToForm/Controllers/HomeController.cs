using MVCDataFormDatabaseToForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.BusinessLogic;

namespace MVCDataFormDatabaseToForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewEmployees()
        {
            var data = EmployeeProcessor.LoadEmployees();

            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (var row in data)
            {
                employees.Add(new EmployeeModel
                {
                    EmployeeId = row.EmployeeId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress,
                    ConfirmEmailAddress = row.EmailAddress
                });
            }

            return View("ViewEmployees", employees);
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Employee Sing Up";

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeProcessor.CreateEmployee(model.EmployeeId, 
                    model.FirstName,
                    model.LastName, 
                    model.EmailAddress);
                return RedirectToAction("Index");
            }

            ViewBag.Message = "Employee Sing Up";

            return View();
        }
    }
}