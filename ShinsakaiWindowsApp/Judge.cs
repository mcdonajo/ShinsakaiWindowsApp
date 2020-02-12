using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinsakaiWindowsApp
{
    public class Judge
    {
        public string ID { get; set; } = DataManager.GetGuid();
        public string Name { get; set; } = "";
    }
}
