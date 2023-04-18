using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.MainMenu
{
    public class PlayerInfo
    {
        private int money;
        private int diamond;
        private int highScore;
        private int playerScore;

        public PlayerInfo()
        {
            money = 0;
            diamond = 0;
            playerScore = 0;
            highScore = 0;
        }

        public PlayerInfo(int money, int diamond,int highScore, int playerScore)
        {
            this.money = money;
            this.diamond = diamond;
            this.playerScore = playerScore;
            this.highScore = highScore;
        }
        public PlayerInfo(int money, int diamond, int highScore)
        {
            this.money = money;
            this.diamond = diamond;
            this.highScore = highScore;
        }

        public int Money
        {
            get { return money; }
            set { money = value; }
        }

        public int Diamond
        {
            get { return diamond; }
            set { diamond = value; }
        }
        public int PlayerScore
        {
            get { return playerScore; }
            set { playerScore = value; }
        }

        public int HighScore
        {
            get { return highScore; }
            set { highScore = value; }
        }
    }
}
