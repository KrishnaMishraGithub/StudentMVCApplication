using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMVCApplication.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace StudentMVCApplication.Controllers
{
    public class AccountController : Controller
    {
        StudentContext studentContext = new StudentContext();
       

        //public AccountController(StudentContext studentContext)
        //{
        //    _studentContext = studentContext;
            
        //}

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginUser loginUser)
        {
          var result = studentContext.SignUpUsers.Where(x => x.Email == loginUser.Username && x.Password == loginUser.Password).FirstOrDefault();
            if (result!=null)
            {
                HttpContext.Session.SetString("UserID",loginUser.Username);
                HttpContext.Session.SetString("UserPassword", loginUser.Password);
                return RedirectToAction("GetStudent", "StudentController1");
            }
            else
            {
                if(result == null)
                {
                    ModelState.Clear();
                    TempData["LoginErrorMsg"]= "Something went wrong";
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpUser signUpUser)
        {
            if (ModelState.IsValid)
            {
                studentContext.SignUpUsers.Add(signUpUser);
                var result = studentContext.SaveChanges();
                if(result!=0)
                {
                    TempData["SuccessMessage"] = "User is Registered Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Opps! User is not Registered ";
                }
            }
            ModelState.Clear();
            return View("Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
