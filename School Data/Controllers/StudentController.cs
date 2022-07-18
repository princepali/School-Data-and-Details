using School_Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Data.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        private IStudentRepository _repository;
        private StudentRepository studentRepository;

        public StudentController()
            : this(new StudentRepository())
        {
            _repository = new StudentRepository();
        }



        public StudentController(StudentRepository StudentRepository)
        {
            this.studentRepository = StudentRepository;
        }

        public ActionResult Index()
        {
            var res = _repository.GetStudent();
            return View(res);
        }
        public ActionResult Details(int id)
        {
            StudentModel model = _repository.GetStudentByRollno(id);
            return View(model);
        }


        public ActionResult Create()
        {
            return View(new StudentModel());
        }

        [HttpPost]
        public ActionResult Create(StudentModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.InsertStudent(user);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(user);
        }


        public ActionResult Edit(int id)
        {
            StudentModel model = _repository.GetStudentByRollno(id);
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(StudentModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.UpdateStudent(user);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(user);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            StudentModel user = _repository.GetStudentByRollno(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                StudentModel user = _repository.GetStudentByRollno(id);
                _repository.DeleteStudent(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                    new System.Web.Routing.RouteValueDictionary {
                { "id", id },
                { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}