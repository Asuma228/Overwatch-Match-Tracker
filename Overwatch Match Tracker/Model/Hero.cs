using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overwatch_Match_Tracker.Model
{
    internal class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public List<Match> Match { get; set; }
    }
}
