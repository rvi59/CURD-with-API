using ApiCurds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Data.Entity;



namespace ApiCurds.Controllers
{
    public class CrudApiController : ApiController
    {

        EmployeeDbEntities db = new EmployeeDbEntities();


        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmpoyees()
        {

            List<tblEmployee> emp = db.tblEmployees.ToList();

            return Ok(emp);

        }


        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeebyId(int id)
        {

            var emp = db.tblEmployees.Where(x => x.id == id).FirstOrDefault();

            return Ok(emp);

        }



        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertEmpoyees(tblEmployee t)
        {

            db.tblEmployees.Add(t);
            db.SaveChanges();
            return Ok();

        }



        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateEmpoyees(tblEmployee t)
        {
           // var emp = db.tblEmployees.Where(x => x.id == t.id).FirstOrDefault();
            //if (emp !=null)
            //{
            //    emp.name = t.name;
            //    emp.gender = t.gender;
            //    emp.age = t.age;
            //    emp.designation = t.designation;
            //    emp.salary = t.salary;
            //    db.SaveChanges();
            //}
            //else
            //{
            //    return NotFound();
            //}

            //Other way

            db.Entry(t).State = EntityState.Modified;
            db.SaveChanges();

            return Ok();

        }



        [System.Web.Http.HttpDelete]
        public IHttpActionResult DelEmpoyees(int id)
        {

            var emp = db.tblEmployees.Where(x => x.id ==id).FirstOrDefault();

            db.Entry(emp).State = EntityState.Deleted;
            db.SaveChanges();
            return Ok();

        }


    }
}
