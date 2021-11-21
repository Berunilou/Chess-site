using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class PlayerServices
    {
        GameServices gs;
        public PlayerServices()
        {
            gs = new GameServices();
            using (DataSource ds = new DataSource())
            {
                ds.Anonymous.Add(new Anonym {Name = "Anonymous"});
                ds.SaveChanges();
            }
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
    }
}
