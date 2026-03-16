using System;
using System.Collections.Generic;
using System.Text;
using UMS.DataAccess.Context;
using System.Linq;
using UMS.Entities;
using Microsoft.EntityFrameworkCore;
namespace UMS.DataAccess
{
    public class DepartmentRepository
    {

        public DepartmentRepository() { }

        public void AddDepartment(Department department)
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    context.Departments.Add(department);
                    context.SaveChanges();
                    Console.WriteLine("Department Added Successfully");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"An error occurred while adding the department: {ex.Message}");
            }
        }
        public List<Department> GetAll()
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    return context.Departments.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while retrieving departments: " + ex.Message);
                return new List<Department>();
            }
        }
        public void DepartmentDashboard(int departmentId)
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    var department = context.Departments
                        .Include(d => d.Students)
                        .Include(d => d.Courses)
                        .Include(d => d.Teachers)
                        .FirstOrDefault(d => d.PkDepartmentId == departmentId);
                    if (department != null)
                    {
                        Console.WriteLine($"Department: {department.DepartmentName}");
                        Console.WriteLine($"Location: {department.Location}");
                        Console.WriteLine($"Created Date: {department.CreatedDate}");
                        Console.WriteLine($"Number of Students: {department.Students?.Count ?? 0}");
                        Console.WriteLine($"Number of Courses: {department.Courses?.Count ?? 0}");
                        Console.WriteLine($"Number of Teachers: {department.Teachers?.Count ?? 0}");
                    }
                    else
                    {
                        Console.WriteLine("Department not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while retrieving department dashboard: " + ex.Message);
            }
        }
        public Department? GetById(int id)
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    return context.Departments.Find(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while retrieving department: " + ex.Message);
                return null;
            }
        }


        public List<Student> GetStudentsByDepartmentId(int departmentId)
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    var department = context.Departments.Include(s => s.Students).FirstOrDefault(d => d.PkDepartmentId == departmentId);

                    return department?.Students.ToList() ?? new List<Student>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while retrieving students: " + ex.Message);
                return new List<Student>();
            }
        }

        public List<Course> GetCoursesByDepartmentId(int departmentId)
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    var department = context.Departments.Include(c => c.Courses).FirstOrDefault(d => d.PkDepartmentId == departmentId);

                    return department?.Courses.ToList() ?? new List<Course>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while retrieving Courses: " + ex.Message);
                return new List<Course>();
            }
        }
        public List<Teacher> GetTeachersOfDepartment(int departmentId)
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    var department = context.Departments.Include(t=>t.Teachers).FirstOrDefault(t=>t.PkDepartmentId==departmentId);
                    if (department == null)
                    {
                        Console.WriteLine($"Department with {departmentId} not found");
                        return new List<Teacher>();
                    }
                    if (department.Teachers == null)
                    {
                        Console.WriteLine($"Department with id {departmentId} and name {department.DepartmentName} has no teacher");
                        return new List<Teacher>();
                    }

                    return department!.Teachers.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while retrieving teachers: " + ex.Message);
                return new List<Teacher>();
            }
        }
        public void RemoveDepartment(int departmentId)
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    var existingDepartment = context.Departments.Find(departmentId);
                    if (existingDepartment != null)
                    {
                        context.Departments.Remove(existingDepartment);
                        context.SaveChanges();
                        Console.WriteLine("Department Removed Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Department not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while removing the department: " + ex.Message);
            }
        }

        public void UpdateDepartment(Department department)
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    var existingDepartment = context.Departments.Find(department.PkDepartmentId);
                    if (existingDepartment != null)
                    {
                        existingDepartment.DepartmentName = department.DepartmentName;
                        existingDepartment.Location = department.Location;
                        existingDepartment.CreatedDate = department.CreatedDate;
                        context.SaveChanges();
                        Console.WriteLine("Department Updated Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Department not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the department: " + ex.Message);
            }
        }
    }
}
