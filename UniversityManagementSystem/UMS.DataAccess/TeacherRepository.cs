using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UMS.DataAccess.Context;

namespace UMS.DataAccess
{
    public class TeacherRepository
    {
        public TeacherRepository() { }


        public void AddTeacher(Teacher teacher)
        {
            try
            {
                using(var context=new UniversityDbContext())
                {
                    context.Teachers.Add(teacher);
                    context.SaveChanges();
                    Console.WriteLine("Teacher Added Successfullly");   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Student Does Not Added "+ex.ToString());
            }
        }


        public List<Teacher> GetTeachers()
        {
            try
            {
                using(var context=new UniversityDbContext())
                {
                    List<Teacher> teachers = context.Teachers.ToList();
                    return teachers;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Unable to Reterive Teachers" + ex.Message);
                return new List<Teacher>();
            }
        }


        public Teacher? GetTeacherById(int id) 
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    var teacher = context.Teachers.Find(id);
                    return teacher;
                }

            }
            catch (Exception ex) 
            {
                Console.WriteLine("Unable to reterieve Teacher" + ex.Message);
                return null;
            }
        }

        public void DeleteById(int id)
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    var teacher = context.Teachers.Find(id);

                    if (teacher != null)
                    {
                        context.Teachers.Remove(teacher);
                        context.SaveChanges();
                        Console.WriteLine("Teacher Removed Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Teacher not found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to Delete Teacher " + ex.Message);
            }
        }
        public void UpdateTeacher(Teacher teacher)
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    var existTeacher = context.Teachers.Find(teacher.PkTeacherId);

                    if (existTeacher != null)
                    {
                        existTeacher.Name = teacher.Name;
                        existTeacher.Email = teacher.Email;
                        existTeacher.FkDepartment = teacher.FkDepartment;

                        context.SaveChanges();

                        Console.WriteLine("Teacher Updated Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Teacher not found");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to reterieve Teacher" + ex.Message);
            }
        }
    }
}
