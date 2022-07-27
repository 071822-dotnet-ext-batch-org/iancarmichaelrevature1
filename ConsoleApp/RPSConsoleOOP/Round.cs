using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpsConsole2
{
    public class Round
    {
        public RockPaperScissors
        public int playerWinsCounter
        {
            get
            {
                return this.playerWinsCounter;
            }
            set
            {
                playerWinsCounter++;
            }
        }

        public int computerWinsCounter
        {
            get
            {
                return this.computerWinsCounter;
            }
            set
            {
                computerWinsCounter++;
            }
        }
    }
}