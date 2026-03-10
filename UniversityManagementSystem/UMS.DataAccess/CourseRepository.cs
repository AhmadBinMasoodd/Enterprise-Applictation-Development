using System;
using System.Collections.Generic;
using System.Text;
using UMS.DataAccess.Context;
using UMS.Entities;
using System.Linq;


namespace UMS.DataAccess
{
    public class CourseRepository
    {

        public CourseRepository() { }

        public void SaveCourse(Course course)
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    context.Courses.Add(course);
                    context.SaveChanges();

                    Console.WriteLine("Course Saved Successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving course: " + ex.Message);

            }
        }

        public List<Course> GetAll()
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    return context.Courses.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while retrieving courses: " + ex.Message);
                return new List<Course>();
            }
        }


        public Course? GetById(int id)
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    return context.Courses.Find(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while retrieving course: " + ex.Message);
                return null;
            }
        }

        public void UpdateCourse(Course course)
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    var existCourse = context.Courses.Find(course.PkCourseId);

                    if (existCourse != null)
                    {
                        existCourse.CourseName = course.CourseName;
                        existCourse.Credits = course.Credits;
                        existCourse.FkDepartmenId = course.FkDepartmenId;

                        context.SaveChanges();
                        Console.WriteLine("Course Updated Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Course not found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating course: " + ex.Message);
            }
        }

        public void DeleteCourse(int id)
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    var existCourse = context.Courses.Find(id);
                    if (existCourse != null)
                    {
                        context.Courses.Remove(existCourse);
                        context.SaveChanges();
                        Console.WriteLine("Course Deleted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Course not found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while deleting course: " + ex.Message);
            }
        }
    }
}