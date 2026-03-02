namespace Entity
{
    public class Employee
    {
        private int id;
        private string first_name;
        private string last_name;
        private int age;
        private double salary;
        private string department;

        public int Id
        {
            get => id;
            set => id = value;
        }
        public string FirstName
        {
            get => first_name;
            set => first_name = value;
        }
        public string LastName
        {
            get => last_name;
            set => last_name = value;
        }
        public int Age
        {
            get => age;
            set => age = value;
        }
        public double Salary
        {
            get => salary;
            set => salary = value;
        }
        public string Department
        {
            get => department;
            set => department = value;
        }
    }
}
