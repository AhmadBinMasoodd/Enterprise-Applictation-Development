using System;
using System.Collections.Generic;
using System.Text;
using UMS.DataAccess;

namespace UMS.BusinessLogic
{
    public class TeacherServices
    {
        private readonly TeacherRepository _repository;

        public TeacherServices()
        {
            _repository = new TeacherRepository();
        }
        public List<Teacher> GetTeachersByDepartmentId(int departmentId) =>_repository.GetTeachersByDepartmentId(departmentId);
        
        public void AddTeacher(Teacher teacher)
        {
            _repository.AddTeacher(teacher);
        }
        public List<Teacher> GetAllTeachers() 
        {
           return  _repository.GetTeachers();
        }
        public Teacher GetTeacherById(int id) 
        {
            return _repository.GetTeacherById(id)!;
        }
        public void DeleteTeacherById(int id) 
        {
            _repository.DeleteById(id);
        }
        public void UpdateTeacher(Teacher teacher)
        {
            _repository.UpdateTeacher(teacher);
        }
    }
}
