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
            using (DataSource db = new DataSource())
            {
                Player Player1 = new Player { Name = "Tom", Reit = 1880};
                Player Player2 = new Player { Name = "Alice", Reit = 26 };

                // Добавление
                db.Players.Add(Player1);
                db.Players.Add(Player2);
                db.SaveChanges();
            }

            // получение
            using (DataSource db = new DataSource())
            {
                // получаем объекты из бд и выводим на консоль
                var Players = db.Players.ToList();
                Console.WriteLine("Данные после добавления:");
                foreach (Player u in Players)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Reit}");
                }
            }

            // Редактирование
            using (DataSource db = new DataSource())
            {
                // получаем первый объект
                Player Player = db.Players.FirstOrDefault();
                if (Player != null)
                {
                    Player.Name = "Bob";
                    Player.Reit = 44;
                    //обновляем объект
                    //db.Players.Update(Player);
                    db.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после редактирования:");
                var Players = db.Players.ToList();
                foreach (Player u in Players)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Reit}");
                }
            }

            // Удаление
            using (DataSource db = new DataSource())
            {
                // получаем первый объект
                Player Player = db.Players.FirstOrDefault();
                if (Player != null)
                {
                    //удаляем объект
                    db.Players.Remove(Player);
                    db.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после удаления:");
                var Players = db.Players.ToList();
                foreach (Player u in Players)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Reit}");
                }
            }
            Console.Read();
        }
    }
}