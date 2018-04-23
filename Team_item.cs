using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addScore
{
    class Team_item
    {

        public int TeamId { get; set; }
        public string Name { get; set; }

        public Team_item()
        {
            TeamId = 0;
            Name = "";
        }
        public override string ToString()
        {
            return Name;
        }
        
    }
}
