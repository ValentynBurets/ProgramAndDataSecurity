using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Model
{
    class WritingParams
    {
        public WritingParams()
        {
            outputCount = 0;
            number = 0;
            breakOutputToUI = false;
            isPeriodFound = false;
        }

        public StreamWriter writer { set; get;  }
        public ulong outputCount { set; get; }
        public ulong number { set; get; }
        public bool breakOutputToUI { set; get; }
        public bool isPeriodFound { set; get; }
    }
}
