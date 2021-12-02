using DataLayer;
using System;
using System.Linq;

namespace ConsoleFromDL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Добавление
            using (DataSource ds = new DataSource())
            {
                Player Player1 = new Player { Name = "Tom", Rate = 1880};
                Player Player2 = new Player { Name = "Alice", Rate = 26 };

                // Добавление
                ds.Players.Add(Player1);
                ds.Players.Add(Player2);
                ds.SaveChanges();
            }

            // получение
            using (DataSource ds = new DataSource())
            {
                // получаем объекты из бд и выводим на консоль
                var Players = ds.Players.ToList();
                Console.WriteLine("Данные после добавления:");
                foreach (Player u in Players)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Rate}");
                }
            }

            // Редактирование
            using (DataSource ds = new DataSource())
            {
                // получаем первый объект
                Player Player = ds.Players.FirstOrDefault();
                if (Player != null)
                {
                    Player.Name = "Bob";
                    Player.Rate = 44;
                    //обновляем объект
                    //ds.Players.Update(Player);
                    ds.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после редактирования:");
                var Players = ds.Players.ToList();
                foreach (Player u in Players)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Rate}");
                }
            }

            // Удаление
            //using (DataSource db = new DataSource())
            //{
            //    // получаем первый объект
            //    Player Player = db.Players.FirstOrDefault();
            //    if (Player != null)
            //    {
            //        //удаляем объект
            //        db.Players.Remove(Player);
            //        db.SaveChanges();
            //    }
            //    // выводим данные после обновления
            //    Console.WriteLine("\nДанные после удаления:");
            //    var Players = db.Players.ToList();
            //    foreach (Player u in Players)
            //    {
            //        Console.WriteLine($"{u.Id}.{u.Name} - {u.Rate}");
            //    }
            //}
            Console.Read();
        }
    }
}