using ConsoleApp3.Models;
using ConsoleAppNew.Models;
using System;
using System.Collections.Generic;
using System.IO;


public class EmployeeController1
{
    private string _employeesDirectory;  // Путь к директории с файлами сотрудников

    private readonly Employee _employee;
    public EmployeeController1(Employee employee)
    {

        _employee = employee;

    }

    public EmployeeController1(string directoryPath)
    {
        _employeesDirectory = directoryPath;
    }





    // Метод для добавление 
    public void Save()
    {
        string IdentifierPath = "C:\\Users\\Aidin\\source\\repos\\ConsoleAppNew2\\ConsoleAppNew\\entity\\Employee\\max\\EmployeeIdentifier.txt";
        int EmployeeIdentifier = 0;
        using (StreamReader sr = new StreamReader(IdentifierPath))
        {
            EmployeeIdentifier = int.Parse(sr.ReadLine());
        }
        int Employee_Code = EmployeeIdentifier++;

    
     
        using (StreamWriter sw = new StreamWriter($"C:\\Users\\Aidin\\source\\repos\\ConsoleAppNew2\\ConsoleAppNew\\entity\\Employee\\{Employee_Code}.txt"))
        {

            // Форматирование данных сотрудника для записи
            sw.WriteLine(Employee_Code);
            sw.WriteLine($"{_employee.Name}");
            sw.WriteLine($"{_employee.Position}");
            sw.WriteLine($"{_employee.Salary}");
            sw.WriteLine($"{_employee.WorkSchedule}");
            sw.WriteLine($"{_employee.RestaurantID}");

        }
     
        using (StreamWriter sw = new StreamWriter(IdentifierPath))
        {
            sw.WriteLine($"{Employee_Code+1}");
        }
    }


    // Метод для чтения информации о всех сотрудниках
    public List<Employee> GetAllEmployees()
    {
        List<Employee> employees = new List<Employee>();

        try
        {
            string[] filePaths = Directory.GetFiles(_employeesDirectory);

            foreach (string filePath in filePaths)
            {
                using (StreamReader sr = new StreamReader(filePath))
                {

                    int id = int.Parse(sr.ReadLine());
                    string name = sr.ReadLine();
                    string position = sr.ReadLine();
                    decimal salary = decimal.Parse(sr.ReadLine());
                    string workSchedule = sr.ReadLine();
                    int restaurantID = int.Parse(sr.ReadLine());

                    Employee employee = new Employee(id, name, position, salary, workSchedule, restaurantID);
                    employees.Add(employee);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении данных о сотрудниках: {ex.Message}");
        }

        return employees;
    }



    // Метод для обновления информации о сотруднике
    public void EditEmployee(int employeeId, string newName, string newPosition, decimal newSalary, string newSchedule)
    {
        try
        {
            // Формируем путь к файлу с данными о сотруднике
            string filePath = Path.Combine(_employeesDirectory, $"{employeeId}.txt");

            // Проверяем существование файла
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Employee with ID {employeeId} does not exist.");
                return;
            }

            // Чтение текущих данных о сотруднике из файла
            string[] lines = File.ReadAllLines(filePath);

            // Обновляем информацию о сотруднике
            lines[0] = employeeId.ToString();
            lines[1] = newName;
            lines[2] = newPosition;
            lines[3] = newSalary.ToString();
            lines[4] = newSchedule;


            // Записываем обновленные данные обратно в файл
            File.WriteAllLines(filePath, lines);

            Console.WriteLine($"Данные о сотруднике {newName} обновлены");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обновлении данных о сотруднике: {ex.Message}");
        }

    }






    // Метод для удаления сотрудника
    public void DeleteEmployee(Employee employee)
    {
        try
        {
            string filePath = Path.Combine(_employeesDirectory, $"{employee.Employee_code}.txt");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine($"Данные о сотруднике '{employee.Employee_code}' удалены.");
            }
            else
            {
                Console.WriteLine($"Файл с данными о сотруднике '{employee.Employee_code}' не найден.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при удалении данных о сотруднике: {ex.Message}");
        }
    }
}
