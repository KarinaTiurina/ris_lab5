using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using Ris2_Lab5.Lab5;

namespace Ris2_Lab5
{
    class Program
    {
        static List<Bike> bikeList = Bike.getBikeList();
        static List<Order> orderList = Order.getOrderList();

        public static void PrintAllBikes(List<Bike> bikeList)
        {
            foreach (var bike in bikeList)
            {
                Console.WriteLine(bike.toString());
            }
        }

        public static void PrintAllOrders(List<Order> orderList)
        {
            foreach (var order in orderList)
            {
                Console.WriteLine(order.toString());
            }
        }
        public static String Menu()
        {
            String menu = "1. Каталог велосипедов.\n" + 
                "2. Забронировать велосипед.\n" + 
                "3. Вернуть велосипед.\n" + 
                "4. Список сданных в прокат велосипедов.\n" + 
                "5. Период окупаемости велосипеда.\n" + 
                "6. Выход.";

            return menu;
        }
        static void Main(string[] args)
        {
            String choice = "";

            while (choice != "0")
            {
                Console.Clear();
                Console.WriteLine(Menu());
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n\n");
                        PrintAllBikes(bikeList);
                        break;
                    case "2":
                        Console.WriteLine("\n\n");
                        PrintAllBikes(bikeList);

                        Console.WriteLine("\n\nКакой велосипед хотите заказать?\n");
                        int bike_id = Int32.Parse(Console.ReadLine());
                        Bike bike_to_order = bikeList.Find(x => x.Id == bike_id);
                    
                        Console.WriteLine("Дата/Время начала (Когда заберете велосипед?):");
                        DateTime start_time = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("На сколько хотите заказать? (в часах)");
                        int hours_count = Int32.Parse(Console.ReadLine());

                        if (CheckIfAvailable(bike_id, start_time, hours_count))
                        {
                            Double price = bike_to_order.Price_per_hour * hours_count;
                            int order_id = orderList.Count + 1;
                            Order new_order = new Order(order_id, bike_id, start_time, hours_count);
                            orderList.Add(new_order);
                            Order.SaveOrder(new_order);
                            Console.WriteLine("Спасибо за заказ! Велосипед будет ожидать Вас в нашем гараже.\nНомер заказа: " + order_id + ". Цена заказа: " + price + "р.");
                        }
                        else
                        {
                            Console.WriteLine("Велосипед уже забронирован на это время. Попробуйте выбрать другое.");
                        }
                        break;
                    case "3":                        
                        Console.WriteLine("\n\nВведите номер заказа:\n");
                        int new_order_id = Int32.Parse(Console.ReadLine());
                        Order order_to_return = orderList.Find(x => x.Id == new_order_id);
                        Console.WriteLine("\n\nСпасибо, что выбрали нашу фирму.\n");
                        break;
                    case "4":
                        Console.WriteLine("\n\n");
                        PrintAllOrders(orderList);
                        break;
                    case "5":
                        Console.WriteLine("\n\n");
                        PrintAllBikes(bikeList);
                        Console.WriteLine("\n\nВыберите велосипед:\n");
                        int new_id = Int32.Parse(Console.ReadLine());

                        Bike bike_to_check = bikeList.Find(x => x.Id == new_id);

                        Console.WriteLine("\n\nСтоимость велосипеда:\n");
                        Double bike_price = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("\n\nСреднее время в день:\n");
                        int hours_per_day = Int32.Parse(Console.ReadLine());

                        Double check_price = 0;
                        int days = 0;

                        while (check_price < bike_price) {
                            check_price += hours_per_day * bike_to_check.Price_per_hour;
                            days++;
                        }

                        Console.WriteLine("\n\nВремя окупаемости велосипеда: " + days + " д.\n");

                        break;
                    default:
                        Console.WriteLine("bye");
                        choice = "0";
                        break;
                }

                Console.WriteLine("\n\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey();
            }

        }

        private static Boolean CheckIfAvailable(int bike_id, DateTime start_time, int hours_count)
        {
            Boolean is_available = true;

            List<Order> orders_to_check = orderList.FindAll(x => x.Bike_id == bike_id);
            if (orders_to_check.Any())
            {
                foreach (var order in orders_to_check)
                {
                    DateTime order_end = order.Start_time.AddHours(order.Hours_count);
                    DateTime new_order_end = start_time.AddHours(hours_count);
                    if (!((order.Start_time > start_time && order_end > start_time && order.Start_time > new_order_end && order_end > new_order_end) ||
                        (start_time > order.Start_time && new_order_end > order.Start_time && start_time > order_end && new_order_end > order_end)))
                    {
                        is_available = false;
                    }
                }
            }

            return is_available;
        }
    }
}
