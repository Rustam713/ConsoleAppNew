using ConsoleApp1.Controller;
using ConsoleApp3.Models;
using ConsoleAppNew.Controller;
using ConsoleAppNew.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleAppNew.View
{
    public class EmployeeView
    {
        public static void ShowMenu()
        {
            bool f = false;
            while (f)
                Console.Clear();
            Console.WriteLine("сотрудники:\n");
            ShowProducts();
            Console.WriteLine("\nВыберите действие");
            Console.WriteLine("1. Показать товары");
            Console.WriteLine("2.редок");
            Console.WriteLine("3. добав");
            Console.WriteLine("4. удол");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowProducts();
                    break;
                case "2":
                    editEmployee();
                    break;
                case "0":
                    Exit();
                    break;
                case "3":
                    addedEmployee(); break;
                case "4":
                    delete(); break;
                default:
                    HandleIncorrectPoint();
                    break;
            }

        }



        private static void HandleIncorrectPoint()
        {
            ShowMessage("Ты ввел неправильное значение, попробуй еще раз!");
            ShowMenu();
        }

        private static void Exit()
        {
            ShowMessage("!!!!");
            Environment.Exit(0);
        }

        private static void ShowMessage(string msg)
        {
            Console.Clear();
            Console.WriteLine(msg);
            Thread.Sleep(2000);
            Console.Clear();
        }

        private static void addedEmployee()
        {


            int resId = 1;
            int employee_code = 0;
            Console.WriteLine("enter Name");
            string Name = Console.ReadLine();
            Console.WriteLine("enter cash Salary");
            decimal Salary = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Position");
            string Position = Console.ReadLine();
            Console.WriteLine("Enter WorkSchedule");
            string WorkSchedule = Console.ReadLine();
            Employee employee = new Employee(employee_code, Name, Position, Salary, WorkSchedule, resId);
            EmployeeController1 vasyaController = new EmployeeController1(employee);
            vasyaController.Save();
            Console.WriteLine("Client saved!");
            Thread.Sleep(1000);
            Console.Clear();
            ShowMenu();


        }






        static string employeesDirectory = "C:\\Users\\rustamcholponbaev\\RiderProjects\\ConsoleAppNew\\ConsoleAppNew\\entity\\Employee\\";

        //static string employeesDirectory = "C:\\Users\\Aidin\\source\\repos\\ConsoleAppNew2\\ConsoleAppNew\\entity\\Employee\\";

        public static void ShowProducts() {
            { /*
           
           */
                //чтение 

                // string employeesDirectory = @"C:\Path\To\Your\Employee\Files\";

                // Создаем экземпляр класса для чтения данных о сотрудниках
                EmployeeController1 employeeReader = new EmployeeController1(employeesDirectory);

                // Читаем данные о сотрудниках из указанной директории
                List<Employee> employees = employeeReader.GetAllEmployees();

                // Выводим информацию о сотрудниках в консоль
                Console.WriteLine("Список сотрудников:");
                string header = "code".PadRight(20) + "Name".PadRight(20) + "Position".PadRight(20) + "Salary".PadRight(15) + "WorkSchedule";

                // Запись заголовков в файл
                Console.WriteLine(header);

                foreach (Employee employee in employees)
                {



                    // Форматирование данных сотрудника для записи
                    string employeeData = $"{employee.Employee_code}".PadRight(20) +
                                           $"{employee.Name}".PadRight(20) +
                                          $"{employee.Position}".PadRight(20) +
                                          $"{employee.Salary}".PadRight(15) +
                                          $"{employee.WorkSchedule}".PadRight(15);

                    // Запись данных сотрудника в файл
                    Console.WriteLine(employeeData);

                }
            }

            /// удаление 







        }

        // Обновление информации о сотруднике
        private static void editEmployee()
        {
            Console.WriteLine("введите код сотруд");
            string codeEmpl = Console.ReadLine();
            if (!int.TryParse(codeEmpl, out int number))
            {
                Console.WriteLine("Ошибка!!! Введите только цифры");
                Thread.Sleep(1000);
                Console.Clear();
                ShowMenu();
            }
            else
            {
                // possibleChoices.Add("0");





                //EmployeeController1 productController = new EmployeeController1();
                EmployeeController1 employeeReader = new EmployeeController1(employeesDirectory);

                // Читаем данные о сотрудниках из указанной директории
                List<Employee> Employees = employeeReader.GetAllEmployees();



                List<int> possibleChoices = Employees
                .Select(p => p.Employee_code)
                .ToList();


                bool containsNumber = possibleChoices.Contains(Convert.ToInt32(codeEmpl));


                if (containsNumber)
                {
                    int employee_code = 0;
                    Console.WriteLine("enter Name");
                    string Name = Console.ReadLine();
                    Console.WriteLine("enter cash Salary");
                    decimal Salary = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Position");
                    string Position = Console.ReadLine();
                    Console.WriteLine("Enter WorkSchedule");
                    string WorkSchedule = Console.ReadLine();
                    EmployeeController1 EmployeeController2 = new EmployeeController1(employeesDirectory);
                    // Вызов метода для редактирования сотрудника с ID = 1
                    EmployeeController2.EditEmployee(Convert.ToInt32(codeEmpl), Name, Position, Salary, WorkSchedule);

                    Console.WriteLine("Данные успешно обновлены.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    ShowMenu();
                }
                else
                {
                    Console.WriteLine("с таким кодом нету такого сотрудника");
                    Thread.Sleep(1000);
                    Console.Clear();
                    ShowMenu();
                }

            }
        }
            private static void delete()
            {
                bool t = false;
                while (!t)
                {
                    Console.WriteLine("Введите код сотрудника");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int number))
                    {
                        Console.WriteLine("Ошибка!!! Введите только цифры");
                    }
                    else
                    {

                        EmployeeController1 EmployeeController1 = new EmployeeController1(employeesDirectory);
                        Employee employeeToDelete = new Employee(int.Parse(input));
                        EmployeeController1.DeleteEmployee(employeeToDelete);
                        Console.Clear();
                        ShowMenu();
                        t = true;
                    }
                }
            }
        }



    } 
