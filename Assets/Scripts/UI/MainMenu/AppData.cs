using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.Dependencies.NCalc;

namespace Assets.Scripts.UI.MainMenu
{
    public class AppData
    {
        private Queue<Treasure> treasureList;
        private PlayerInfo playerInfo;
        private Setting playerSetting;
        private Queue<ShopItem> shopItemList;
        private Queue<ShopItem> skinItemList;
        private Queue<ShopItem> goldItemList;
        public AppData()
        {
            treasureList = new Queue<Treasure>();
            playerInfo = new PlayerInfo();
            playerSetting =  new Setting();
            shopItemList = new Queue<ShopItem>();
            skinItemList = new Queue<ShopItem>();
            goldItemList = new Queue<ShopItem>();
        }
        public AppData(Queue<Treasure> treasureList,PlayerInfo playerInfo, Setting playerSetting, Queue<ShopItem> shopItemList, Queue<ShopItem> skinItemList, Queue<ShopItem> goldItemList)
        {
            this.treasureList = treasureList;
            this.playerInfo = playerInfo;
            this.playerSetting = playerSetting;
            this.shopItemList = shopItemList;
            this.skinItemList = skinItemList;
            this.goldItemList = goldItemList;
        }
        
        public PlayerInfo PlayerInfo
        {
            get { return playerInfo; }
            set { playerInfo = value; }
        }
        public Setting PlayerSetting
        {
            get { return playerSetting; }
            set { playerSetting = value; }
        }
        public Queue<ShopItem> ShopItemList
        {
            get { return shopItemList; }
            set { shopItemList = value; }
        }
        public Queue<ShopItem> SkinItemList
        {
            get { return skinItemList; }
            set { skinItemList = value; }
        }
        public Queue<ShopItem> GoldItemList
        {
            get { return goldItemList; }
            set { goldItemList = value;}
        }

        public Queue<Treasure> TreasureList
        {
            get { return  treasureList; }
            set { treasureList = value; }
        }
    }
}
