using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class MatchEntity
    {
        public int MatchId { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public string Location { get; set; }
        public string Tournament { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
    }
}
