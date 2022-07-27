using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpsConsole2
{
    public class Game
    {
        public Player GameWinner { get; set; }
        public DateTime GameDate { get; set; }
        public int numberOfTies { get; set; }

        public Player P1{get; set;}
        public Player P2{get; set;}
    }
}