using ApiCurds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ApiCurds.Controllers
{
    public class CurdmvcController : Controller
    {
        // GET: Curdmvc

        HttpClient client = new HttpClient();


        public ActionResult Index()
        {

            List<tblEmployee> emp_list = new List<tblEmployee>();

            client.BaseAddress = new Uri("https://localhost:44380/api/CrudApi");

            var respose = client.GetAsync("CrudApi");
            respose.Wait();

            var res = respose.Result;

            if (res.IsSuccessStatusCode)
            {

                var display = res.Content.ReadAsAsync<List<tblEmployee>>();
                display.Wait();
                emp_list = display.Result;

            }         
            return View(emp_list);
        }


        public ActionResult Details(int id)
        {
            tblEmployee e = null;
            client.BaseAddress = new Uri("https://localhost:44380/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var res = response.Result;
            if (res.IsSuccessStatusCode)
            {
                var display = res.Content.ReadAsAsync<tblEmployee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }




        public ActionResult Create()
        {         

            return View();
        }


        [HttpPost]
        public ActionResult Create(tblEmployee t)
        {

            client.BaseAddress = new Uri("https://localhost:44380/api/CrudApi");

            var respose = client.PostAsJsonAsync<tblEmployee>("CrudApi",t);
            respose.Wait();

            var res = respose.Result;

            if (res.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }

            return View("Create");
        }


        public ActionResult Edit(int id)
        {
            tblEmployee e = null;
            client.BaseAddress = new Uri("https://localhost:44380/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var res = response.Result;
            if (res.IsSuccessStatusCode)
            {
                var display = res.Content.ReadAsAsync<tblEmployee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }


        [HttpPost]
        public ActionResult Edit(tblEmployee t)
        {
            client.BaseAddress = new Uri("https://localhost:44380/api/CrudApi");

            var respose = client.PutAsJsonAsync<tblEmployee>("CrudApi", t);
            respose.Wait();

            var res = respose.Result;

            if (res.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }

            
            return View("Edit");
        }


        public ActionResult Delete(int id)
        {
            tblEmployee e = null;
            client.BaseAddress = new Uri("https://localhost:44380/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var res = response.Result;
            if (res.IsSuccessStatusCode)
            {
                var display = res.Content.ReadAsAsync<tblEmployee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44380/api/CrudApi");

            var respose = client.DeleteAsync("CrudApi/"+id.ToString());
            respose.Wait();

            var res = respose.Result;

            if (res.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }
            return View("Delete");
        }


    }
}