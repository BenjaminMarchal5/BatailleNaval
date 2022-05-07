using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model.Utils
{
    public class XMLPath
    {
        public string XmlPath;
        private static XMLPath instance;
        public static XMLPath GetInstance()
        {
            if (instance==null)
            {
                instance = new XMLPath();
            }
            return instance;
        }
        public XMLPath()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            this.XmlPath = xmlPath;
        }
    }
}
