using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PlayerServices
    {
        GameServices gs;
        DataSource ds;
        public PlayerServices()
        {
            gs = new GameServices();
            ds = new DataSource();

            ds.Anonymous.Add(new Anonym { Name = "Anonymous" });
            ds.SaveChanges();

        }
        public void StartGame()
        {
            using (DataSource ds = new DataSource())
            {
                var currentGame = gs.GetCurrentGame();
                if (currentGame == null)
                {
                    Chess.Game chess = new Chess.Game();
                    gs.CreateGame(chess.fen);
                    ds.SaveChanges();
                }
                else
                {
                    currentGame.Status = GameStatus.play;
                    ds.SaveChanges();
                }
            }
        }
        public void PlayerCreating(string UserEmail, string UserPassword, string UserName)
        {
            using (DataSource ds = new DataSource())
            {
                ds.Players.Add(new Player
                {
                    Id = ds.Players.Count() + 1,//???
                    Name = UserName,
                    Email = UserEmail,
                    Password = UserPassword,
                    Rate = 1400,
                    GameNumber = 0
                });
                ds.SaveChanges();
            }
        }
        public void UserAuthentication(string name, string password)
        {
            using (DataSource ds = new DataSource())
            {
                var User = ds.Players.Where(p => p.Name == name).Where(p => p.Password == password).ToList();
                if (User.Count != 0)
                {
                    //foreach (var player in User)
                    //ds.GetPlayerInfo();
                }
            }
        }
        //public void RateCalculation(Player player1, Player player2, double player1Points)
        //{
        //    var player1DeltaRate = 1 / (1 + Math.Pow(10, (player2.Rate - player1.Rate) / 400));
        //    var player2DeltaRate = 1 / (1 + Math.Pow(10, (player1.Rate - player2.Rate) / 400));

        //    var player1AtDB = ds.Players.Find(player1.Id);
        //    var player2AtDB = ds.Players.Find(player2.Id);

        //    if (player1.GameNumber < 40 || player1.Rate < 2300)
        //    {
        //        player1AtDB.Rate += 40 * (player1Points - player1DeltaRate);
        //    }
        //    else
        //    {
        //        if (player1.Rate < 2400)
        //            player1AtDB.Rate += 20 * (player1Points - player1DeltaRate);
        //        else
        //            player1AtDB.Rate += 10 * (player1Points - player1DeltaRate);
        //    }

        //    if (player2.GameNumber < 40)
        //    {
        //        player2AtDB.Rate += 40 * (1 - player1Points - player2DeltaRate);
        //    }
        //    else
        //    {
        //        if (player2.Rate < 2400)
        //            player2AtDB.Rate += 20 * (1 - player1Points - player2DeltaRate);
        //        else
        //            player2AtDB.Rate += 10 * (1 - player1Points - player2DeltaRate);
        //    }
        //}
    }
}
