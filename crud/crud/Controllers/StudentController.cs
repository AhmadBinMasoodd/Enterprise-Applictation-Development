using crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Student()
        {
            //ViewBag.abc = "danish";
            //ViewData["abc"]="Ahmad";

            using(EnterpriseDbContext db=new EnterpriseDbContext())
            {
                List<Student> myList = db.Students.ToList();
                return View("Student",myList);

            }
        }
        
        public IActionResult add(string name,string age)
        {
            using (EnterpriseDbContext db = new EnterpriseDbContext())
            {
                Student student = new Student { Sname = name, Sage = int.Parse(age) };
                db.Students.Add(student);
                db.SaveChanges();

            }
            return Ok();
        }
        [HttpGet]
        public IActionResult getAllStudents()
        {
             using(EnterpriseDbContext db= new EnterpriseDbContext())
            {
                var student=db.Students.ToList();
                return Json(student);
            }
        }

        [HttpDelete]
        public IActionResult delete(int pk_id)
        {
            using (EnterpriseDbContext db = new EnterpriseDbContext())
            {
                Student? temp = db.Students.Where(x => x.Id == pk_id).FirstOrDefault();

                ///nameless variables
                /// the variable is not used anywhere else in the code
                db.Students.Remove(temp!);
                db.SaveChanges();
                 
               return Ok();
                   
                
            }

        }
        public IActionResult deletestudent(int pk_id)
        {
            using (EnterpriseDbContext db = new EnterpriseDbContext())
            {
                var temp = db.Students.Where(s => s.Id == pk_id).FirstOrDefault();
                if (temp != null)
                {
                    db.Students.Remove(temp);
                    int num=db.SaveChanges();
                    if (num > 0)
                    {
                        ViewData["msg"] = "Seccessfully deleted";
                        return RedirectToAction("Student");
                    }
                    else
                    {
                        ViewData["msg"] = "Deletion Failed";
                        return RedirectToAction("Student");
                    }
                }
                else
                {
                    ViewData["msg"] = "Deletion Failed";
                    return RedirectToAction("Student");
                }
            }

        }
        [HttpPost]
        public IActionResult update(int pk_id,string name,int age)
        {
            using(EnterpriseDbContext db=new EnterpriseDbContext())
            {
                var temp = db.Students.Where(s => s.Id == pk_id).FirstOrDefault();
                if (temp != null)
                {
                    temp.Sname = name;
                    temp.Sage = age;
                    int num = db.SaveChanges();
                    if (num > 0)
                    {
                        ViewData["msg"] = "Seccessfully updated";
                        return RedirectToAction("Student");
                    }
                    else
                    {
                        ViewData["msg"] = "Updation Failed";
                        return RedirectToAction("Student");
                    }
                }
                else
                {
                    ViewData["msg"] = "Updation Failed";
                    return RedirectToAction("Student");
                }
            }
        }

        public IActionResult editstudent(int pk_id)
        {
            using (EnterpriseDbContext db = new EnterpriseDbContext())
            {
                var student = db.Students.Where(s => s.Id == pk_id).FirstOrDefault();
                if (student != null)
                {
                    return View(student);
                }
                else
                {
                    ViewData["msg"] = "Student not found";
                    return RedirectToAction("Student");
                }
            }
        }
        public IActionResult updateStu(int pk_id, string name, int age)
        {
            using (EnterpriseDbContext db = new EnterpriseDbContext())
            {
                var temp = db.Students.FirstOrDefault(s => s.Id == pk_id);

                if (temp == null) return NotFound();

                temp.Sname = name;
                temp.Sage = age;

                db.SaveChanges();
                return Ok();
            }
        }
        public IActionResult getStudentById(int id)
        {
            using (EnterpriseDbContext db = new EnterpriseDbContext())
            {
                var student = db.Students.Where(s => s.Id == id).FirstOrDefault();
                if (student != null)
                {
                    return Json(student);
                }
                else
                {
                    return Json(new { message = "Student not found" });
                }
            }
        }

        [HttpPost]
        public IActionResult addstudent(string name,string age)
        {
            using (EnterpriseDbContext db = new EnterpriseDbContext())
            {
                Student student = new Student {Sname=name ,Sage=int.Parse(age)};
                db.Students.Add(student);
                db.SaveChanges();

            }
             return RedirectToAction("Student");
        }
    }
}
