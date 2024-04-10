using System;
using System.ComponentModel;

namespace EmployeesReport
{
    internal class Program
    {
        public static int registeredEmployees = 0;
        public static int maxEmployees = 10;
        public static string[] names = { "Cesar", "Maria", "Eduardo", "Ana", "Artur", "Kauet", "Vitor", "Vinicius", "Gabriel", "Nauã", "Naiara" };
        public static string[] surnames = { "Chiodi", "Faccio", "Yashuda", "Gomes", "Devechi", "Dezotti", "Manzolli", "Boffo", "Fernandes" };

        static void Main(string[] args)
        {
            var employees = new Employee[maxEmployees];

            CreateRandomEmployees(employees);
            ShowAllEmployees(employees);
            GetTotalSalaryPerCategory(employees);
            GetHigherAndLowerSalaryPerCategory(employees);
            GetAverageAgePerCategory(employees);
            GetEmployeesPerSalaryRange(employees);
            GetYoungestEmployeeName(employees);
        }

        private static void ShowAllEmployees(Employee[] employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine("Name: " + employee.Name);
                Console.WriteLine("Age: " + employee.Age);
                Console.WriteLine("Salary: " + Math.Round(employee.Salary, 2));
                Console.WriteLine("Category: " + employee.Category + "\n");
            }
        }

        private static void AddEmployee(Employee[] employees)
        {
            if (registeredEmployees > maxEmployees)
                Console.WriteLine("The maximum number of employees has been reached!");

            else
            {
                employees[registeredEmployees] = new Employee();

                AddEmployeeData(registeredEmployees, employees);

                Console.WriteLine("Employee successfully added!");

                registeredEmployees++;
            }
        }

        private static void AddEmployeeData(
            int index,
            Employee[] employees
        )
        {
            Console.WriteLine("Enter the employee's information");

            Console.Write("\nName: ");
            employees[index].Name = Console.ReadLine();

            Console.Write("\nAge: ");
            employees[index].Age = int.Parse(Console.ReadLine());

            Console.Write("\nSalary: ");
            employees[index].Salary = double.Parse(Console.ReadLine());

            Console.Write("\nCategory: ");
            employees[index].Category = int.Parse(Console.ReadLine());
        }

        private static void CreateRandomEmployees(Employee[] employees)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                var random = new Random();

                employees[i] = new Employee
                {
                    Name = names[random.Next(names.Length)] + " " + surnames[random.Next(surnames.Length)],
                    Age = random.Next(16, 60),
                    Salary = 1000 + (random.NextDouble() * 11000),
                    Category = random.Next(1, 4)
                };
            }
        }

        private static void GetTotalSalaryPerCategory(Employee[] employees)
        {
            var totalCategoryOne = 0.0;
            var totalCategoryTwo = 0.0;
            var totalCategoryThree = 0.0;

            for (int i = 0; i < employees.Length; i++)
            {
                totalCategoryOne += employees[i].Category == 1 ? employees[i].Salary : 0.0;
                totalCategoryTwo += employees[i].Category == 2 ? employees[i].Salary : 0.0;
                totalCategoryThree += employees[i].Category == 3 ? employees[i].Salary : 0.0;
            }


            Console.WriteLine("Category 1's total: " + Math.Round(totalCategoryOne, 2));
            Console.WriteLine("Category 2's total: " + Math.Round(totalCategoryTwo, 2));
            Console.WriteLine("Category 3's total: " + Math.Round(totalCategoryThree, 2));
        }

        private static void GetHigherAndLowerSalaryPerCategory(Employee[] employees)
        {
            var higherCategoryOne = 0.0;
            var higherCategoryTwo = 0.0;
            var higherCategoryThree = 0.0;

            var lowerCategoryOne = 11000.0;
            var lowerCategoryTwo = 11000.0;
            var lowerCategoryThree = 11000.0;

            for (int i = 0; i < employees.Length; i++)
            {
                higherCategoryOne = employees[i].Category == 1 && employees[i].Salary > higherCategoryOne 
                    ? employees[i].Salary 
                    : higherCategoryOne;
                higherCategoryTwo = employees[i].Category == 2 && employees[i].Salary > higherCategoryTwo 
                    ? employees[i].Salary 
                    : higherCategoryTwo;
                higherCategoryThree = employees[i].Category == 3 && employees[i].Salary > higherCategoryThree 
                    ? employees[i].Salary 
                    : higherCategoryThree;

                lowerCategoryOne = employees[i].Category == 1 && employees[i].Salary < lowerCategoryOne 
                    ? employees[i].Salary 
                    : lowerCategoryOne;
                lowerCategoryTwo = employees[i].Category == 2 && employees[i].Salary < lowerCategoryTwo 
                    ? employees[i].Salary 
                    : lowerCategoryTwo;
                lowerCategoryThree = employees[i].Category == 3 && employees[i].Salary < lowerCategoryThree 
                    ? employees[i].Salary 
                    : lowerCategoryThree;
            }


            Console.WriteLine("\nCategory 1's highest salary: " + Math.Round(higherCategoryOne, 2));
            Console.WriteLine("Category 2's highest salary: " + Math.Round(higherCategoryTwo, 2));
            Console.WriteLine("Category 3's highest salary: " + Math.Round(higherCategoryThree, 2));

            Console.WriteLine("\nCategory 1's lowest salary: " + Math.Round(lowerCategoryOne, 2));
            Console.WriteLine("Category 2's lowest salary: " + Math.Round(lowerCategoryTwo, 2));
            Console.WriteLine("Category 3's lowest salary: " + Math.Round(lowerCategoryThree, 2));
        }

        private static void GetAverageAgePerCategory(Employee[] employees)
        {
            var agesSumCategoryOne = 0;
            var agesSumCategoryTwo = 0;
            var agesSumCategoryThree = 0;

            var employeesCategoryOne = 0;
            var employeesCategoryTwo = 0;
            var employeesCategoryThree = 0;

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].Category == 1)
                {
                    agesSumCategoryOne += employees[i].Age;
                    employeesCategoryOne++;
                }
                else if (employees[i].Category == 2)
                {
                    agesSumCategoryTwo += employees[i].Age;
                    employeesCategoryTwo++;
                }
                else if (employees[i].Category == 3)
                {
                    agesSumCategoryThree += employees[i].Age;
                    employeesCategoryThree++;
                }
            }

            Console.WriteLine("\nCategory 1 average age: " + (employeesCategoryOne != 0 
                ? agesSumCategoryOne / employeesCategoryOne 
                : 0
            ));
            Console.WriteLine("Category 2 average age: " + (employeesCategoryTwo != 0 
                ? agesSumCategoryTwo / employeesCategoryTwo 
                : 0
            ));
            Console.WriteLine("Category 3 average age: " + (employeesCategoryThree != 0 
                ? agesSumCategoryThree/employeesCategoryThree 
                : 0
            ));
        }

        private static void GetEmployeesPerSalaryRange(Employee[] employees)
        {
            var basicSalary = 1000;
            var between1and2 = 0;
            var between3and4 = 0;
            var between5and6 = 0;
            var between7and8 = 0;
            var moreThan8 = 0;

            for (int i = 0; i < employees.Length; i++)
            {
                between1and2 = employees[i].Salary < (basicSalary * 3) 
                    ? between1and2 + 1 
                    : between1and2;
                between3and4 = employees[i].Salary >= (basicSalary * 3) && employees[i].Salary < (basicSalary * 5) 
                    ? between3and4 + 1 
                    : between3and4;
                between5and6 = employees[i].Salary >= (basicSalary * 5) && employees[i].Salary < (basicSalary * 7) 
                    ? between5and6 + 1 
                    : between5and6;
                between7and8 = employees[i].Salary >= (basicSalary * 7) && employees[i].Salary < (basicSalary * 9) 
                    ? between7and8 + 1 
                    : between7and8;
                moreThan8 = employees[i].Salary >= (basicSalary * 9) 
                    ? moreThan8 + 1 
                    : moreThan8;
            }

            Console.WriteLine("\nEmployees who receive in the range of 1 and 2 minimum wages: " + between1and2);
            Console.WriteLine("Employees who receive in the range of 3 and 4 minimum wages: " + between3and4);
            Console.WriteLine("Employees who receive in the range of 5 and 6 minimum wages: " + between5and6);
            Console.WriteLine("Employees who receive in the range of 7 and 8 minimum wages: " + between7and8);
            Console.WriteLine("Employees who receive more than 8 minimum wages: " + moreThan8);

        }

        private static void GetYoungestEmployeeName(Employee[] employees)
        {
            var youngestEmployee = employees[0];

            for (int i = 0; i < employees.Length; i++)
                youngestEmployee = employees[i].Age < youngestEmployee.Age 
                    ? employees[i] 
                    : youngestEmployee;

            Console.WriteLine("\nYoungest employee's name: " + youngestEmployee.Name);
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public int Category { get; set; }
    }
}
