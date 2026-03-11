using UMS.DataAccess.Context;

namespace UMS.DataAccess
{
    public class StudentRepository
    {
        public StudentRepository() { }

        public void AddStudent(Student student)
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                    Console.WriteLine("Student added successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            
        }

        public List<Student> GetAll()
        {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    return context.Students.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while retrieving students: " + ex.Message);
                return new List<Student>();
            }
        }


        public Student? GetStudent(int id) { 
            try
            {
                using (var context = new UniversityDbContext())
                {
                    return context.Students.Find(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while retrieving student: " + ex.Message);
                return null;
            }
        }


        public void DeleteStudentById(int id) {
            try
            {
                using (var context = new UniversityDbContext())
                {
                    var student = context.Students.Find(id);
                    if (student != null)
                    {
                        context.Students.Remove(student);
                        context.SaveChanges();
                        Console.WriteLine("Student deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine("Error while deleting student: " + ex.Message);
            }
        }

            public void UpdateStudent(Student student)
            {
                try
                {
                    using (var context = new UniversityDbContext())
                    {
                        var existStudent = context.Students.Find(student.PkStudentId);
    
                        if (existStudent != null)
                        {
                            existStudent.StudentName = student.StudentName;
                            existStudent.Age = student.Age;
                            existStudent.DepartmentId = student.DepartmentId;
                            existStudent.Email = student.Email;
    
                            context.SaveChanges();
                            Console.WriteLine("Student Updated Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Student not found");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while updating student: " + ex.Message);
                }
        }
    }

   
}
