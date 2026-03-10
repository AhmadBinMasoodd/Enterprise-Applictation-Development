using System;
using System.Collections.Generic;
using UMS.DataAccess;
using UMS.Entities;

namespace UMS.BusinessLogic
{
    public class CourseServices
    {
        private readonly CourseRepository _courseRepository;

        public CourseServices()
        {
            _courseRepository = new CourseRepository();
        }

        // Business Rule
        public void CheckCreditHours(Course course)
        {
            while (course.Credits <= 0)
            {
                Console.WriteLine("Invalid Credit Hours. Please enter correct credit hours:");

                string? input = Console.ReadLine();

                if (int.TryParse(input, out int newCreditHours) && newCreditHours > 0)
                {
                    course.Credits = newCreditHours;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        public void AddCourse(Course course)
        {
            CheckCreditHours(course);
            _courseRepository.SaveCourse(course);
        }

        public List<Course> GetAllCourses()
        {
            return _courseRepository.GetAll();
        }

        public Course? GetCourseById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public void UpdateCourse(Course course)
        {
            CheckCreditHours(course);
            _courseRepository.UpdateCourse(course);
        }

        public void DeleteCourse(int id)
        {
            _courseRepository.DeleteCourse(id);
        }
    }
}