// See https://aka.ms/new-console-template for more information
using ahmad;
using math_library;
namespace ahmad
{
    class Student
    {
        public void Display()
        {
            Console.WriteLine("The is the student");
            double sum=Calculator.sum(4.5, 45.05, 6.6, 3.65);
            Console.WriteLine($"SUM : {sum}");
        }
    }
    
}
namespace ali
{
    class Teacher
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Hello world!");
            Student student = new Student();
            student.Display();

        }
        public void Display()
        {
            Console.WriteLine("This is the teacher class");
        }
        
    }
}