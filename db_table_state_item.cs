using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addScore{
    class db_table_state_item{

        public int num { get; set; }
        public string state { get; set; }
        public int time { get; set; }

        public db_table_state_item(){
            num = 0;
            state = "";
            time = 0;
        }
        public override string ToString(){
            return state;
        }
    }
}
