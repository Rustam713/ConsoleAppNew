using ConsoleApp3.Models;
using ConsoleAppNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNew.Controller
{
    public class DishController
    {
        private string _dishDirectory;  // Путь к директории с файлами ресторана

        private readonly Dish _dish;
        public DishController(Dish dish)
        {
            _dish = dish;
        }

        public DishController(string directoryPath)
        {
            _dishDirectory = directoryPath;
        }




        public void Save()
        {
            //string IdentifierPath = "C:\\Users\\Aidin\\source\\repos\\ConsoleAppNew2\\ConsoleAppNew\\entity\\Dish\\max\\DishIdentifier.txt";
            string IdentifierPath = "C:\\Users\\RUSTAM\\source\\repos\\ConsoleAppNew\\ConsoleAppNew\\entity\\Dish\\max\\DishIdentifier.txt";


            int DishIdentifier = 0;
            using (StreamReader sr = new StreamReader(IdentifierPath))
            {
                DishIdentifier = int.Parse(sr.ReadLine());
            }
            int Dish_Code = DishIdentifier++;

            int maxId = 0;
            using (StreamWriter sw = new StreamWriter($"C:\\Users\\RUSTAM\\source\\repos\\ConsoleAppNew\\ConsoleAppNew\\entity\\Dish\\{Dish_Code}.txt"))
            //using (StreamWriter sw = new StreamWriter($"C:\\Users\\Aidin\\source\\repos\\ConsoleAppNew2\\ConsoleAppNew\\entity\\Dish\\{Dish_Code}.txt"))
            {


                sw.WriteLine(Dish_Code);
                sw.WriteLine($"{_dish.RestaurantId}");
                sw.WriteLine($"{_dish.Price}");
                sw.WriteLine($"{_dish.RestaurantId}");
                sw.WriteLine($"{_dish.IngredientsId}");

            }
          
            using (StreamWriter sw = new StreamWriter(IdentifierPath))
            {
                sw.WriteLine($"{Dish_Code}");
            }
        }

      

        // Метод для чтения
        public List<Dish> GetAllDish()
        {
            List<Dish> DishtList = new List<Dish>();

            try
            {
                string[] filePaths = Directory.GetFiles(_dishDirectory);

                foreach (string filePath in filePaths)
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {

                        int DishId = int.Parse(sr.ReadLine());
                        string Name = sr.ReadLine();
                        int RestaurantId = int.Parse(sr.ReadLine());
                        int IngredientsId = int.Parse(sr.ReadLine());
                        decimal Price = decimal.Parse(sr.ReadLine());


                        Dish dis = new Dish(DishId, Name, Price, RestaurantId, IngredientsId);
                        DishtList.Add(dis);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении данных: {ex.Message}");
            }

            return DishtList;
        }



        // Метод для обновления  
        public void EditDish(int dishId, string newName, decimal newPrice, int newRestaurant, int newIngredients)
        {
            try
            {
                // Формируем путь к файлу с данными о сотруднике
                string filePath = Path.Combine(_dishDirectory, $"{dishId}.txt");

                // Проверяем существование файла
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Ресторан с ID {dishId} не найден");
                    return;
                }

                // Чтение текущих данных о сотруднике из файла
                string[] lines = File.ReadAllLines(filePath);

                // Обновляем информацию о сотруднике
                lines[0] = dishId.ToString();
                lines[1] = newName;
                lines[2] = newPrice.ToString();
                lines[3] = newRestaurant.ToString();
                lines[4] = newIngredients.ToString();
             


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
        public void DeleteDish(Dish dishs)
        {
            try
            {
                string filePath = Path.Combine(_dishDirectory, $"{dishs.DishId}.txt");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine($"Данные о ресторане '{dishs.DishId}' удалены.");
                }
                else
                {
                    Console.WriteLine($"Файл с данными ресторана '{dishs.DishId}' не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении: {ex.Message}");
            }
        }



    }
}

