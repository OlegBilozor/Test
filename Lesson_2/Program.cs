using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //Employee emp = new Employee();
            //var emp2 = new Employee("Jake", 21);

            var department = new Department();
            department.AddEmployee(new Employee("John", 24));
            department.AddEmployee(new Employee("Jake", 34));
            department.AddEmployee(new Employee("Bob", 26));
            department.AddEmployee(new Employee("Olga", 18));
            department.AddEmployee(new Employee(25)
            { 
                Name = "Igor"
            });
            Console.WriteLine(department.GetEmployeeBy(3));
            var en = department.GetEmployeeBy(5);
            Console.WriteLine(en);
            foreach(var employee in department)
            {
                Console.WriteLine(employee);
            }
            Console.WriteLine(department.CountEmployees);
            Console.WriteLine(department[3]);
            Console.ReadLine();
        }
    }
    public static class IdHelper
    {
        private static int _idCounter;
        public static int GetNextId()
        {
            return ++_idCounter;
        }
    }
    class Employee
    {
        
        

        public string Name { set; get; }
        private readonly int _age = 0;
        private const string Position = "QA";
        public int Id { get; } = IdHelper.GetNextId();
        public Employee() : this("John", 18)
        {
            //Console.WriteLine("Object was created");
        }
        public Employee(int age)
        {
            _age = age;
        }
        public Employee(string name, int age)
        {
            Name = name;
            _age = age;
            //Console.WriteLine($"Name: {_name}\nAge: {_age}");
        }
        public void ChangeName()
        {
          //  _name = "Bob"; //readonly поле можна приствоїти значення тільки під час оголошення або в конструкторі
        }
        
        public override string ToString()
        {
            return $"Name: {Name}; Age: {_age}; Id: {Id}";
        }
    }
    class Department : IEnumerable<Employee>
    {
        #region Class Fields
        private readonly List<Employee> _employees;
        #endregion
        #region Properties
        public int CountEmployees => _employees.Count;
        public Employee this[int id]
        {
            get { return GetEmployeeBy(id); }
            set
            {
                for(int i=0;i<_employees.Count;i++)
                {
                    if(_employees[i].Id==id)
                    {
                        _employees[i] = value;
                        break;
                    }
                }
            }
        }
        #endregion
        #region Constructors
        public Department()
        {
            _employees = new List<Employee>();
        }
        #endregion
        #region Methods
        public void AddEmployee(Employee newEmp)
        {
            _employees.Add(newEmp);
        }
        public Employee GetEmployeeBy(int id)
        {
            foreach (var emplyee in _employees)
            {
                if (emplyee.Id == id)
                    return emplyee;
            }
            return null;
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return _employees.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Employee>)_employees).GetEnumerator();
        } 
        #endregion


    }
    
}
