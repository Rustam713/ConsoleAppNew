using ConsoleApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNew.Controller
{
    public class ProductController
    {

        private string _ProductDirectory;  // Путь к директории с файлами ресторана

        private readonly Products product;

        public ProductController(string directoryPath)
        {
            _ProductDirectory = directoryPath;
        }




        public void Save()
        {

            string IdentifierPath = "C:\\Users\\Aidin\\source\\repos\\ConsoleAppNew2\\ConsoleAppNew\\entity\\Products\\max\\ProductIdentifier.txt";
     
            int ProductIdentifier = 0;
            using (StreamReader sr = new StreamReader(IdentifierPath))
            {
                ProductIdentifier = int.Parse(sr.ReadLine());
            }
            int Product_Code = ProductIdentifier++;

            int maxId = 0;
           
            using (StreamWriter sw = new StreamWriter($"C:\\Users\\Aidin\\source\\Новая папка\\ConsoleApp3\\entity\\Products\\{ProductIdentifier}.txt"))
            {


                sw.WriteLine(Product_Code);
                sw.WriteLine($"{product.ProductId}");
                sw.WriteLine($"{product.Name}");
                sw.WriteLine($"{product.Type}");
                sw.WriteLine($"{product.Count}");
                sw.WriteLine($"{product.PricePerGram}");

            }
          
            using (StreamWriter sw = new StreamWriter(IdentifierPath))
            {
                sw.WriteLine($"{Product_Code}");
            }
        }


        // Метод для чтения
        public List<Products> GetAllProduct()
        {
            List<Products> producttList = new List<Products>();

            try
            {
                string[] filePaths = Directory.GetFiles(_ProductDirectory);

                foreach (string filePath in filePaths)
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {

                        int ProductId = int.Parse(sr.ReadLine());
                        string Name = sr.ReadLine();
                        string Type = sr.ReadLine();
                        int Count = int.Parse(sr.ReadLine());
                        string Unit = sr.ReadLine();
                        decimal PricePerGram = decimal.Parse(sr.ReadLine());
                       
                        Products product = new Products(ProductId, Name, PricePerGram,Type, Unit, Count);
                        producttList.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении данных: {ex.Message}");
            }

            return producttList;
        }



        // Метод для обновления  
        public void EditProduct(int restaurantId, string newName, string newHeadChef, string newAddress)
        {
            try
            {
                // Формируем путь к файлу с данными о сотруднике
                string filePath = Path.Combine(_ProductDirectory, $"{restaurantId}.txt");

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
        public void DeleteProduct(Products restaurant)
        {
            try
            {
                string filePath = Path.Combine(_ProductDirectory, $"{restaurant.ProductId}.txt");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine($"Данные о ресторане '{restaurant.ProductId}' удалены.");
                }
                else
                {
                    Console.WriteLine($"Файл с данными ресторана '{restaurant.ProductId}' не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении: {ex.Message}");
            }
        }


    
}
}
