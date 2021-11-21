using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class MovesServices
    {
        private DataSource ds;
        public MovesServices()
        {
            ds = new DataSource();
        }
        public void WritePosition(Game game, Player player, string move)
        {
            ds.Moves.Add(new Move
            {
                GameId = game.Id,
                PlayerId = player.Id,
                CurrentFEN = game.Fen,
                NextMove = " "
            });
            ds.SaveChanges();
        }
        public IEnumerable<string> GameHistory(Game game)
        {
            var playedGame = ds.Moves.Where(m => m.GameId == game.Id).ToList();
            List<string> moves = new List<string>();
            foreach (var move in playedGame)
                moves.Add(move.NextMove);
            return moves;
        }
    }
}
