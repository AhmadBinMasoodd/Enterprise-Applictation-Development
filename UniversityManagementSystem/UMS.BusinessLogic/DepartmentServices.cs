using System;
using System.Collections.Generic;
using System.Text;
using UMS.DataAccess;

namespace UMS.BusinessLogic
{
    public class DepartmentServices
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentServices()
        {
            _departmentRepository = new DepartmentRepository();
        }


        
        public void AddDepartment(Department department)
        {
            department.CreatedDate = DateTime.Now;
            _departmentRepository.AddDepartment(department);

        }
        public void UpdateDepartment(Department department)
        {
            _departmentRepository.UpdateDepartment(department);
        }

        public void DeleteDepartment(int departmentId)
        {
            _departmentRepository.RemoveDepartment(departmentId);
        }

        public List<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAll();
        }
        public Department? GetDepartmentById(int id)
        {
            return _departmentRepository.GetById(id);
        }
    }
}
