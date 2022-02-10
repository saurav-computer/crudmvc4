using crudmvc4.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crudmvc4.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        db_textEntities dbobj = new db_textEntities();

        public ActionResult Student( Tbl_student obj)
        {
            if (obj != null)
                return View(obj);
            else

            return View();
        }
        [HttpPost]
        
            public ActionResult AddStudent(Tbl_student model)

        { 
            if (ModelState.IsValid)

            {



                Tbl_student obj = new Tbl_student();
                obj.Name = model.Name;
                obj.Fname = model.Fname;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Address = model.Address;

                dbobj.Tbl_student.Add(obj);
                dbobj.SaveChanges();


                ModelState.Clear();
            }

            return View("Student");
        }

        public ActionResult StudentList()
        {
            var res = dbobj.Tbl_student.ToList();
            return View(res);
        }
        public ActionResult Delete( int id)
        {
            var res = dbobj.Tbl_student.Where(x => x.Id == id).First();
            dbobj.Tbl_student.Remove(res);
            dbobj.SaveChanges();
             var list = dbobj.Tbl_student.ToList();
            return View("StudentList",list);
        }

    }
}