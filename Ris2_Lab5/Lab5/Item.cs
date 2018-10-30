using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ris2_Lab5.Lab5
{
    class Item
    {
        public String toString()
        {
            return "item";
        }
        virtual public Double Price() { return 0; }

        virtual public String FullInfo() { return "";  }

    }
}
