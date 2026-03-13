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
