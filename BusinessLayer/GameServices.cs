using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class GameServices
    {
        private DataSource ds;
        public GameServices()
        {
            ds = new DataSource();
        }
        public Game GetCurrentGame()
        {
            return ds.Games.Where(g => g.Status == GameStatus.wait).FirstOrDefault();
        }
        public void CreateGame(string fen)
        {
            ds.Games.Add(new Game { 
                Fen = fen, 
                Status = GameStatus.play 
            });
            ds.SaveChanges();
        }
        public void FinishGame(int gameId)
        {
            ds.Games.Where(g => g.Id == gameId).FirstOrDefault().Status = GameStatus.done;
            ds.SaveChanges();
        }
    }
}
