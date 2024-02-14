using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overwatch_Match_Tracker.Model
{
    internal class QueueMode
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Match> Match { get; set; }
    }
}
