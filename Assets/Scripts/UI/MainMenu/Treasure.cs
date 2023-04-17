using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.MainMenu
{
    public class Treasure
    {
        private string _uid;
        private string iconPath;
        private string name;
        private string chestType;
        private bool status;
        public Treasure() {
            _uid = Guid.NewGuid().ToString();
            iconPath = string.Empty;
            name = string.Empty;
            name = name.Trim();
            chestType = string.Empty;
            status = false;
        }
        public Treasure(string uid, string iconPath, string name, string chestType, bool status)
        {
            _uid = uid;
            this.iconPath = iconPath;
            this.name = name;
            this.chestType = chestType;
            this.status = status;
        }

        public Treasure(string iconPath, string name, string chestType, bool status): this()
        {
            this.iconPath = iconPath;
            this.name = name;
            this.chestType = chestType;
            this.status = status;
        }

        public string UID 
        {
            get { return _uid; }
            set { _uid = value; }
        }

        public string IconPath
        {
            get { return iconPath;}
            set { iconPath = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string ChestType
        {
            get { return chestType; }
            set { chestType = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value;}
        }
    }
}
