using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Overwatch_Match_Tracker.Model
{
    internal class Teammate
    {
        public int Id { get; set; }
        public string BattleTag { get; set; }

        public List<Match> Match { get; set; }
    }
}
