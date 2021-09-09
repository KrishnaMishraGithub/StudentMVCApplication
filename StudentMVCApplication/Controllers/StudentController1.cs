using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Mvc.Core;
using StudentMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace StudentMVCApplication.Controllers
{
    public class StudentController1 : Controller
    {
        // GET: StudentController1


        StudentContext studentContext = new StudentContext();
        [HttpGet]
        public ActionResult GetStudent(string search,int pageNumber=1)
        {
            //ViewBag.CreateMessage = TempData["CreateMessage"];
            //ViewBag.CreateErrorMessage = TempData["CreateErrorMessage"];
            ViewBag.PageNumber = pageNumber;
            var student = studentContext.Students.ToList();
            ViewBag.TotalPages = Math.Ceiling(student.Count()/5.0);
            if(search!= null)
            {
                // student = studentContext.Students.Where(x => x.Fname == search).ToList();
                //student = studentContext.Students.Where(x => x.Fname.Contains(search)).ToList();
                student = studentContext.Students.Where(x => x.Fname.Contains(search) || x.Lname.Contains(search)).ToList();
            }
            student = student.Skip((int)((pageNumber-1)*5)).Take(5).ToList();
            return View(student);
            
        }

        // GET: StudentController1/Details/5
        public ActionResult Details(int id)
        {
            Student student = studentContext.Students.Where(d => d.Sid == id).FirstOrDefault();

            return View(student);
        }

        // GET: StudentController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            studentContext.Add(student);
          int x=  studentContext.SaveChanges();
            if(x==1)
            {
               TempData["CreateMessage"] = "Student has been added successfully!!";
            }
            else
            {
                TempData["CreateErrorMessage"] = "Oops some problem occured";
            }
            return RedirectToAction("GetStudent");

        }

        // GET: StudentController1/Edit/5
        public ActionResult Edit(int id)
        {
            // List<StudentContext> studentContextsList = new List<StudentContext>();

            Student student = studentContext.Students.Where(s=>s.Sid==id).FirstOrDefault();
            return View(student);
        }

        // POST: StudentController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
           Student student1= studentContext.Students.Where(s => s.Sid == student.Sid).FirstOrDefault();
            studentContext.Remove(student1);
            studentContext.Add(student);
            int x=studentContext.SaveChanges();
            if(x==1)
            {
                TempData["UpdateMessage"] = "Student has been Updated successfully!!";
            }
            else
            {
                TempData["UpdateErrorMessage"] = "Oops some problem occured,Can't Update!!";
            }
            return RedirectToAction("GetStudent");
        }

        // GET: StudentController1/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = studentContext.Students.Where(s => s.Sid == id).FirstOrDefault();
            return View(student);
            
        }

        // POST: StudentController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student student)
        {
            Student student1 = studentContext.Students.Where(s => s.Sid == student.Sid).FirstOrDefault();
            studentContext.Remove(student1);
           int x= studentContext.SaveChanges();
            if (x == 1)
            {
                TempData["DeleteMessage"] = "Student has been Deleted successfully!!";
            }
            else
            {
                TempData["DeleteErrorMessage"] = "Oops some problem occured,Can't Delete!!";
            }
            return RedirectToAction("GetStudent");

        }


        
        [HttpGet]
    
        public ActionResult StudentCard()
        {
            return View(studentContext.Students.ToList());
        }
    }
}
