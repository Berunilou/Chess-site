using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class MatchServices
    {
        private DataSource ds;
        public MatchServices()
        {
            ds = new DataSource();
        }
        public void AddPlayerToGame(int gameId, int playerId)
        {
            ds.Matches.Add(new Match
            {
                GameId = gameId,
                PlayerId = playerId,
                PlayerColour = PlayerGameColour.white
            });
        }
    }
}
