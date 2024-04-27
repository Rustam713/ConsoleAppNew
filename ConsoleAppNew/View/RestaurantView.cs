using ConsoleApp3.Controller;
using ConsoleApp3.Models;
using ConsoleAppNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNew.View
{
    internal class RestaurantView
    {
        public void ShowMenu()
        {
            bool f = false;
            while (f)
                Console.Clear();
            Console.WriteLine("сотрудники:\n");
            ShowProducts();
            Console.WriteLine("\nВыберите действие");
            Console.WriteLine("1 - выбрать ресторан");
            Console.WriteLine("2 - изменить данные о ресторане");
            Console.WriteLine("3 - Добавить ");
            Console.WriteLine("4 - удалить ");

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



        private void HandleIncorrectPoint()
        {
            ShowMessage("Ты ввел неправильное значение, попробуй еще раз!");
            ShowMenu();
        }

        private void Exit()
        {
            ShowMessage("!!!!");
            Environment.Exit(0);
        }

        private void ShowMessage(string msg)
        {
            Console.Clear();
            Console.WriteLine(msg);
            Thread.Sleep(2000);
            Console.Clear();
        }

        private void addedEmployee()
        {


            int employee_code = 0;
            Console.WriteLine("enter Name");
            string Name = Console.ReadLine();
            Console.WriteLine("enter HeadChef");
            string HeadChef = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string Address = Console.ReadLine();

            Restaurant rest = new Restaurant(employee_code, Name, HeadChef, Address);
            RestaurantController vasyaController = new RestaurantController(rest);
            vasyaController.Save();
            Console.WriteLine("Client saved!");
            Thread.Sleep(1000);
            Console.Clear();
            ShowMenu();


        }


        public void menu()
        {

        }




        string RestaurantDirectory = "C:\\Users\\Aidin\\source\\repos\\ConsoleAppNew2\\ConsoleAppNew\\entity\\Restaurant\\";

        public void ShowProducts()
        {
            { /*
           
           */
                //чтение 


                // Создаем экземпляр класса для чтения данных о сотрудниках
                RestaurantController restaurantReader = new RestaurantController(RestaurantDirectory);

                // Читаем данные о сотрудниках из указанной директории
                List<Restaurant> restaurant = restaurantReader.GetAllRestaurant();

                // Выводим информацию о сотрудниках в консоль
                Console.WriteLine("Список Ресторанов:");
                string header = "RestaurantId".PadRight(20) + "Name".PadRight(20) + "HeadChef".PadRight(20) + "Address";

                // Запись заголовков в файл
                Console.WriteLine(header);

                foreach (Restaurant items in restaurant)
                {



                    // Форматирование данных сотрудника для записи
                    string RestaurantData = $"{items.RestaurantId}".PadRight(20) +
                                            $"{items.Name}".PadRight(20) +
                                           $"{items.HeadChef}".PadRight(20) +
                                          $"{items.Address}".PadRight(20);
                                        

                    // Запись данных сотрудника в файл
                    Console.WriteLine(RestaurantData);

                }
            }

            /// удаление 







        }

        // Обновление информации о сотруднике
        private void editEmployee()
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





               // RestaurantController RestaurantController1 = new RestaurantController();
                RestaurantController RestaurantReader = new RestaurantController(RestaurantDirectory);

                // Читаем данные о сотрудниках из указанной директории
                List<Restaurant> Restaurant = RestaurantReader.GetAllRestaurant();



                List<int> possibleChoices = Restaurant
                .Select(p => p.RestaurantId)
                .ToList();


                bool containsNumber = possibleChoices.Contains(Convert.ToInt32(codeEmpl));


                if (containsNumber)
                {
                    int employee_code = 0;
                    Console.WriteLine("enter Name");
                    string Name = Console.ReadLine();
                    Console.WriteLine("enter HeadChef");
                    string HeadChef = Console.ReadLine();
                    Console.WriteLine("Enter Address");
                    string Address = Console.ReadLine();
                    RestaurantController RestaurantController = new RestaurantController(RestaurantDirectory);
                    // Вызов метода для редактирования сотрудника с ID = 1
                    RestaurantController.EditRestaurant( Convert.ToInt32(codeEmpl), Name, HeadChef, Address);

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
        private void delete()
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

                    RestaurantController RestaurantController111 = new RestaurantController(RestaurantDirectory);
                    Restaurant RestaurantToDelete = new Restaurant(int.Parse(input));
                    RestaurantController111.DeleteRestaurant(RestaurantToDelete);
                    Console.Clear();
                    ShowMenu();
                    t = true;
                }
            }
        }
    }
}
