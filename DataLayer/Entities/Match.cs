﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public PlayerGameColour PlayerColour { get; set; }
        public int ChangeOfReit { get; set; }

        //public List<string> gamehisory { get; set; }
    }
}
