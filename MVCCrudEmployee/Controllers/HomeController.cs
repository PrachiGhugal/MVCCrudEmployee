﻿using MVCCrudEmployee.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;


namespace MVCCrudEmployee.Controllers
{
    public class HomeController : Controller
    {
        DemoEntities db=new DemoEntities();
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

        public ActionResult Create()
        {
            var employee=new EmployeeViewModel();
            return View(employee);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Map ViewModel to Entity
                var employee = new EmployeeTable
                {
                    
                    Empname = viewModel.Empname,
                    Empage = viewModel.Empage,
                    Empemail = viewModel.Empemail,
                    Empcontact = viewModel.Empcontact,
                    //Isactive=viewModel.Isactive==true,
                    AddressTables = new List<AddressTable>
                {
                    new AddressTable
                    {
                        Addressline1 = viewModel.Addressline1,
                        Addressline2 = viewModel.Addressline2
                    }
                }
                };

                // Save to the database
                db.EmployeeTables.Add(employee);
                db.SaveChanges();

                // Redirect to the appropriate action or view
                return RedirectToAction("Emplist"); // Adjust this based on your actual setup
            }

            // If ModelState is not valid, return the view with validation errors
            return View(viewModel);
        }

        public ActionResult Emplist()
        {
            
            var empviewmodel = db.EmployeeTables.Select(e=> new EmployeeViewModel
            {
                Empid = e.Empid,
                Empname=e.Empname,
                Empage=e.Empage,
                Empemail=e.Empemail,
                Empcontact=e.Empcontact,
                Isactive = (bool)e.Isactive,
                Addressline1 =e.AddressTables.FirstOrDefault().Addressline1,
                Addressline2=e.AddressTables.FirstOrDefault().Addressline2
                
            }).ToList();
            
            return View(empviewmodel);
        }

            public ActionResult Edit(int? id)
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmployeeTable employee = db.EmployeeTables.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            EmployeeViewModel model = new EmployeeViewModel
            {
                Empid = employee.Empid,
                Empname = employee.Empname,
                Empage = employee.Empage,
                Empemail = employee.Empemail,
                Empcontact = employee.Empcontact,
                Isactive= (bool)employee.Isactive,
                Addressline1 = employee.AddressTables.FirstOrDefault()?.Addressline1,
                Addressline2 = employee.AddressTables.FirstOrDefault()?.Addressline2
            };

            return View(model);
        }

            [HttpPost]
        public ActionResult Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeTable employee = db.EmployeeTables.Find(model.Empid);
                if (employee == null)
                {
                    return HttpNotFound();
                }

                // Update employee details
                employee.Empname = model.Empname;
                employee.Empage = model.Empage;
                employee.Empemail = model.Empemail;
                employee.Empcontact = model.Empcontact;
                employee.Isactive = (bool)model.Isactive;

                // Update address details
                AddressTable address = employee.AddressTables.FirstOrDefault();
                if (address != null)
                {
                    address.Addressline1 = model.Addressline1;
                    address.Addressline2 = model.Addressline2;
                }

                db.SaveChanges();

                return RedirectToAction("Emplist"); // Redirect to the appropriate action or view
            }

            // If ModelState is not valid, return to the edit view with the model
            return View(model);
        }

        public ActionResult Details(int id)
        {
            EmployeeTable emp = db.EmployeeTables.Find(id);
            return View(emp);
        }

        public ActionResult Delete(int id)
        {
            EmployeeTable emp = db.EmployeeTables.Find(id);

            // Check if emp is null
            if (emp == null)
            {
                // Handle the case where the record with the specified id is not found
                return HttpNotFound(); // You can return a 404 Not Found status or redirect to an error page
            }

            // Manually delete related records in AddressTable
            foreach (var address in emp.AddressTables.ToList())
            {
                db.AddressTables.Remove(address);
            }

            // Now delete the EmployeeTable record
            db.EmployeeTables.Remove(emp);

            // Save changes
            db.SaveChanges();

            return RedirectToAction("Emplist");
        }

        [HttpGet]
        public ActionResult ActivateCustomer(int id)
        {
            var customer = db.EmployeeTables.FirstOrDefault(c => c.Empid == id);

            if (customer != null)
            {
                customer.Isactive = true;
                db.SaveChanges();
                return RedirectToAction("Emplist");
            }

            return RedirectToAction("Emplist");
        }

        [HttpGet]
        public ActionResult DeactivateCustomer(int id)
        {
            var customer = db.EmployeeTables.FirstOrDefault(c => c.Empid == id);

            if (customer != null)
            {

                customer.Isactive = false;
                db.SaveChanges();
                return RedirectToAction("Emplist");
            }
            return RedirectToAction("Emplist");
        }
    }
}