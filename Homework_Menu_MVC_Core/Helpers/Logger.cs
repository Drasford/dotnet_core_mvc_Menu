using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_Menu_MVC_Core.Helpers
{
    public class Logger
    {
        public string type { get; set; }
        public string time { get; set; }

        public Logger(string type, string time)
        {
            this.type = type;
            this.time = time;
        }
    }
}
