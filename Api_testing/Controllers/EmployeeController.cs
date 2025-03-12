using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Api_testing.DAL;
using Api_testing.Models;

namespace Api_testing.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeInfo dal=new EmployeeInfo();

        [HttpPost]
        [Route("api/Employee/AddEmployee")]
         public IHttpActionResult AddEmployee()
        {
            try
            {
                var httprequest = HttpContext.Current.Request;

                if (httprequest.Form["name"]==null || httprequest.Form["email"]== null || httprequest.Form["password"]==null || httprequest.Form["phone"]==null || httprequest.Form["Address"]==null)
                {
                    return BadRequest("Missing  required filed");
                }

                Emp_data employeeInfo = new Emp_data
                {
                    name= httprequest.Form["name"],
                    email=httprequest.Form["email"],
                    password=httprequest.Form["password"],
                    phone = httprequest.Form["phone"],
                    address=httprequest.Form["address"],
                };

                bool result = dal.Add_Emp(employeeInfo);
                if (result)
                {
                    return Ok(employeeInfo);
                }
                else
                {
                    return BadRequest("Data invalid");
                }
                
            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("api/showdata")]
        public IHttpActionResult Show_data()
        {
            List<Emp_data> emp = dal.show_Employee();
            return Ok(emp);
        }




        [HttpDelete]
        [Route("api/Employee/delete")]
        public IHttpActionResult Delete_data(int id)
        {
            EmployeeInfo data=new EmployeeInfo();
            bool result=dal.Delete_data(id);

            if (result)
            {
                return Ok("Data delete succeccfully");
            }
            else
            {
                return BadRequest("Data Delete Error");
            }
        }

        [HttpPut]
        [Route("api/Update")]
        public IHttpActionResult Update()
        {
            var httprequest = HttpContext.Current.Request;

            int id=Convert.ToInt32(httprequest.Form["id"]);
            string name=httprequest.Form["name"];
            string email=httprequest.Form["email"];
            string password=httprequest.Form["password"];
            string phone=httprequest.Form["phone"];
            string address=httprequest.Form["address"];

            Emp_data updation = new Emp_data
            {
                id = id,
                name = name,
                email = email,
                password = password,
                phone = phone,
                address = address,
            };

            EmployeeInfo dal = new EmployeeInfo();
            bool result =dal.edit(updation, id);

            if (result)
            {
                return Ok(updation);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/getuserbyid/{id}")]
        public IHttpActionResult Getdata (int id)
        {
            List<Emp_data> emp_Datas =dal.singleuser(id);
            return Ok(emp_Datas);
        }

    }
}
