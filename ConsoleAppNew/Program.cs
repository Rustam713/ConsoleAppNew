// See https://aka.ms/new-console-template for more information

using ConsoleAppNew.View;
 namespace Project
 {
     class Program
     {
         static void Main()
         {
             Console.WriteLine("Hello");
             Console.WriteLine("elect tasks: ");
             Console.WriteLine(" Write - 1");
             Console.WriteLine("Read  -  2");
             Console.WriteLine("Delate - 3");
             Console.Write(" --->: ");

             string choose = Console.ReadLine();
             
             while (true)
             {
                 if (choose == "1")
                 {
                     Console.WriteLine("Hello");
                     Console.WriteLine("where to write down: ");
                     Console.WriteLine("Restaurant - 1");
                     Console.WriteLine("    Dish  -  2");
                     Console.WriteLine(" Employee -  3");
                     Console.Write(" --->: ");

                     string chooseWrite = Console.ReadLine();

                     if (chooseWrite == "1")
                     {
                         RestaurantView.ShowMenu();
                     }
                     else if (chooseWrite == "2")
                     {
                         DishView.ShowMenu();
                     }
                     else if (chooseWrite == "3")
                     {
                         EmployeeView.ShowMenu();
                     }
                     else
                     {
                         Console.WriteLine("bye");
                         break;
                     }
                 }

                 else if (choose == "2")
                 {
                     Console.WriteLine("Hello");
                     Console.WriteLine("What to read: ");
                     Console.WriteLine("Restaurant - 1");
                     Console.WriteLine("    Dish  -  2");
                     Console.WriteLine(" Employee -  3");
                     Console.Write(" --->: ");

                     string chooseRead = Console.ReadLine();

                     if (chooseRead == "1")
                     {
                         RestaurantView.ShowProducts();
                     }
                     else if (chooseRead == "2")
                     {
                         DishView.ShowProducts();
                     }
                     else if (chooseRead == "3")
                     {
                         EmployeeView.ShowProducts();
                     }
                     else
                     {
                         Console.WriteLine("bye");
                         break;
                     }

                 }
                 else if (choose == "3")
                 {
                     
                 }
                 else
                 {
                     Console.WriteLine("bye");
                     break;
                 }
             }
         }
     }
 }

