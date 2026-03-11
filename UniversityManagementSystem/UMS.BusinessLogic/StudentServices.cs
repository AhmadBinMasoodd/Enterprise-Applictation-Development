using UMS.DataAccess;

namespace UMS.BusinessLogic
{
    public class StudentServices
    {
        private readonly StudentRepository _studentRepository;
        public StudentServices() { 
        
            _studentRepository = new StudentRepository();
        }
        public void CheckStudentAge(Student student)
        {
            while (student.Age <= 0)
            {
                Console.WriteLine("Invalid Age. Please enter a valid age:");

                string? input = Console.ReadLine();

                if (int.TryParse(input, out int newAge) && newAge > 0)
                {
                    student.Age = newAge;
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a positive number.");
                }
            }
        }

        public void AddStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }
        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public void UpdateStudent(Student student)
        { 
            _studentRepository.UpdateStudent(student);
        }
        public void DeleteStudent(Student student)
        {
            _studentRepository.DeleteStudentById(student.PkStudentId);
        }
        public Student? GetStudentById(int id)
        {
            return _studentRepository.GetStudent(id);
        }

    }
}
