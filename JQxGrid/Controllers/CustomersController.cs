﻿using System;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using JQxGrid.Models;
namespace JQxGrid.Controllers
{
    public class CustomersController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        CustomerContext db = new CustomerContext();
        public JsonResult GetValues(string sidx, string sord, int page, int rows) //Gets the todo Lists.  
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var Results = db.Customers.Select(
                a => new
                {
                    a.Id,
                    a.Name,
                    a.Phone,
                    a.Address,
                    a.Email,
                });
            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Results
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // TODO:insert a new row to the grid logic here  
        [HttpPost]
        public string Create([Bind(Exclude = "Id")] Customer obj)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Customers.Add(obj);
                    db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        public string Edit(Customer obj)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        public string Delete(int Id)
        {
            Customer list = db.Customers.Find(Id);
            db.Customers.Remove(list);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }
}