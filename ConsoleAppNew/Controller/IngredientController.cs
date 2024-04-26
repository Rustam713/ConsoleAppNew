using ConsoleApp3.Models;
using ConsoleAppNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNew.Controller
{
    internal class IngredientController
    {
        private string _ingredientDirectory;  // Путь к директории с файлами сотрудников

        private readonly Ingredient _ingredient;
        public IngredientController(Ingredient ingredient)
        {

            _ingredient = ingredient;

        }

        public IngredientController(string directoryPath)
        {
            _ingredientDirectory = directoryPath;
        }





        // Метод для добавление 
        public void Save()
        {
            string IdentifierPath = "C:\\Users\\Aidin\\source\\repos\\ConsoleAppNew2\\ConsoleAppNew\\entity\\Ingredient\\max\\IngredientIdentifier.txt";
  
            int IngredientIdentifier = 0;
            using (StreamReader sr = new StreamReader(IdentifierPath))
            {
                IngredientIdentifier = int.Parse(sr.ReadLine());
            }
            int ingredient_Code = IngredientIdentifier++;

            int maxId = 0;
          
            using (StreamWriter sw = new StreamWriter($"C:\\Users\\Aidin\\source\\repos\\ConsoleAppNew2\\ConsoleAppNew\\entity\\Ingredient\\{ingredient_Code}.txt"))
            {

              
                sw.WriteLine(ingredient_Code);
                sw.WriteLine($"{_ingredient.ProductID}");
                sw.WriteLine($"{_ingredient.WeightGrams}");
                sw.WriteLine($"{_ingredient.DishId}");
                sw.WriteLine($"{_ingredient.RestaurantId}");

            }
           
            using (StreamWriter sw = new StreamWriter(IdentifierPath))
            {
                sw.WriteLine($"{ingredient_Code}");
            }
        }


        // Метод для чтения информации о всех сотрудниках
        public List<Ingredient> GetAllIingredient()
        {
            List<Ingredient> ingredientList = new List<Ingredient>();

            try
            {
                string[] filePaths = Directory.GetFiles(_ingredientDirectory);

                foreach (string filePath in filePaths)
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {

                        int IngredientId = int.Parse(sr.ReadLine());
                        int ProductID = int.Parse(sr.ReadLine());
                        int WeightGrams = int.Parse(sr.ReadLine());
                        int DishId = int.Parse(sr.ReadLine());
                        int RestaurantId = int.Parse(sr.ReadLine());


                        Ingredient ingredient= new Ingredient(IngredientId, ProductID, WeightGrams, DishId, RestaurantId);
                        ingredientList.Add(ingredient);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении: {ex.Message}");
            }

            return ingredientList;
        }



        // Метод для обновления информации о сотруднике
        public void EditIngredient(int ingredientId, int newProductID, int newWeightGrams, int newDishId, int newRestaurantId)
        {
            try
            {
                // Формируем путь к файлу с данными о сотруднике
                string filePath = Path.Combine(_ingredientDirectory, $"{ingredientId}.txt");

                // Проверяем существование файла
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Ресторан с ID {ingredientId} не найден ");
                    return;
                }

                // Чтение текущих данных 
                string[] lines = File.ReadAllLines(filePath);

                // Обновляем информацию 
                lines[0] = ingredientId.ToString();
                lines[1] = newProductID.ToString();
                lines[2] = newWeightGrams.ToString();
                lines[3] = newDishId.ToString();
                lines[4] = newRestaurantId.ToString();


                // Записываем обновленные данные обратно в файл
                File.WriteAllLines(filePath, lines);

                Console.WriteLine($"Данные успешно обновлены");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обновлении данных: {ex.Message}");
            }

        }






        // Метод для удаления сотрудника
        public void DeleteIngredient(Ingredient ingredient)
        {
            try
            {
                string filePath = Path.Combine(_ingredientDirectory, $"{ingredient.IngredientId}.txt");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine($"Данные '{ingredient.IngredientId}' удалены.");
                }
                else
                {
                    Console.WriteLine($"Файл с данными '{ingredient.IngredientId}' не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении данных: {ex.Message}");
            }
        }
    }
}
