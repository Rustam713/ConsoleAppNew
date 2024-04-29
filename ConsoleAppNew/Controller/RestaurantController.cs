using ConsoleApp3.Models;
using ConsoleAppNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Controller
{
    public class RestaurantController
    {


        private string _restaurantDirectory;  // Путь к директории с файлами ресторана

        private readonly Restaurant _restaurant;


        public RestaurantController(Restaurant restaurant)
        {

            _restaurant = restaurant;

        }

        public RestaurantController(string directoryPath)
        {
            _restaurantDirectory = directoryPath;
        }




        public void Save()
        {
            //string IdentifierPath = "C:\\Users\\RUSTAM\\source\\repos\\ConsoleAppNew\\ConsoleAppNew\\entity\\Restaurant\\max\\RestaurantIdentifier.txt";

            //string IdentifierPath = "C:\\Users\\Aidin\\source\\repos\\ConsoleAppNew2\\ConsoleAppNew\\entity\\Restaurant\\max\\RestaurantIdentifier.txt";
            string IdentifierPath = "C:/Users/rustamcholponbaev/RiderProjects/ConsoleAppNew/ConsoleAppNew/entity/Restaurant/max/RestaurantIdentifier.txt";


            int RestaurantIdentifier = 0;
            using (StreamReader sr = new StreamReader(IdentifierPath))
            {
                RestaurantIdentifier = int.Parse(sr.ReadLine());
            }
            int RestaurantCode = RestaurantIdentifier++;
            
            
            using (StreamWriter sw = new StreamWriter($"C:/Users/rustamcholponbaev/RiderProjects/ConsoleAppNew/ConsoleAppNew/entity/Restaurant/{RestaurantCode}.txt"))

            //using (StreamWriter sw = new StreamWriter($"C:\\Users\\RUSTAM\\source\\repos\\ConsoleAppNew\\ConsoleAppNew\\entity\\Restaurant\\{RestaurantCode}.txt"))
  
            //using (StreamWriter sw = new StreamWriter($"C:\\Users\\Aidin\\source\\repos\\ConsoleAppNew2\\ConsoleAppNew\\entity\\Restaurant\\{RestaurantCode}.txt"))
            {


                sw.WriteLine(RestaurantCode);
                sw.WriteLine($"{_restaurant.Name}");
                sw.WriteLine($"{_restaurant.HeadChef}");
                sw.WriteLine($"{_restaurant.Address}");
                

            }
            using (StreamWriter sw = new StreamWriter(IdentifierPath))
            {
                sw.WriteLine($"{RestaurantCode+1}");
            }
        }


        // Метод для чтения
        public List<Restaurant> GetAllRestaurant()
        {
            List<Restaurant> restaurantList = new List<Restaurant>();

            try
            {
                string[] filePaths = Directory.GetFiles(_restaurantDirectory);

                foreach (string filePath in filePaths)
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {

                        int id = int.Parse(sr.ReadLine());
                        string Name = sr.ReadLine();
                        string Address = sr.ReadLine();
                        string HeadChef = sr.ReadLine();
                        //decimal CashBalance = decimal.Parse(sr.ReadLine());


                        Restaurant restaurant = new Restaurant(id, Name, HeadChef, Address);
                        restaurantList.Add(restaurant);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении данных: {ex.Message}");
            }

            return restaurantList;
        }



        // Метод для обновления  
        public void EditRestaurant(int restaurantId, string newName, string newHeadChef, string newAddress)
        {
            try
            {
                // Формируем путь к файлу с данными о сотруднике
                string filePath = Path.Combine(_restaurantDirectory, $"{restaurantId}.txt");

                // Проверяем существование файла
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Ресторан с ID {restaurantId} не найден");
                    return;
                }

                // Чтение текущих данных о сотруднике из файла
                string[] lines = File.ReadAllLines(filePath);

                // Обновляем информацию о сотруднике
                lines[0] = restaurantId.ToString();
                lines[1] = newName;
                lines[2] = newHeadChef.ToString();
                lines[3] = newAddress.ToString();
                // lines[4] = newSchedule;


                // Записываем обновленные данные обратно в файл
                File.WriteAllLines(filePath, lines);

                Console.WriteLine($"Данные о ресторане {newName} обновлены");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обновлении данных о ресторане: {ex.Message}");
            }

        }






        // Метод для удаления 
        public void DeleteRestaurant(Restaurant restaurant)
        {
            try
            {
                string filePath = Path.Combine(_restaurantDirectory, $"{restaurant.RestaurantId}.txt");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine($"Данные о ресторане '{restaurant.RestaurantId}' удалены.");
                }
                else
                {
                    Console.WriteLine($"Файл с данными ресторана '{restaurant.RestaurantId}' не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении: {ex.Message}");
            }
        }


    }
}
