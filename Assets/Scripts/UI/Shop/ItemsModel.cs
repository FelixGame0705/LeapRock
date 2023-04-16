using Newtonsoft.Json.Schema;
using Palmmedia.ReportGenerator.Core.Reporting.Builders.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.Shop
{
    public class ItemsModel
    {
        public string id;
        private string iconPath;
        private int level;
        private int price;
        
        public ItemsModel()
        {
            id = Guid.NewGuid().ToString();
            iconPath = string.Empty;
            level = 0;
            price = 0;
        }
        public ItemsModel(string id, string iconPath, int level, int price)
        {
            this.id = id;
            this.iconPath = iconPath;
            this.level = level;
            this.price = price;
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string IconPath
        {
            get { return iconPath; }
            set { iconPath = value; }
        }
        public int Level
        {
            get { return level; }
            set
            {
                if(value >= 0 && value <= 6)
                {
                    level = value;
                }
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                if(value >= 0)
                {
                    price = value;
                }
            }
        }
    }
}
