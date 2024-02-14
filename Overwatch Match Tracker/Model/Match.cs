using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overwatch_Match_Tracker.Model
{
    internal class Match
    {
        public int Id { get; set; }

        public int QueueModeId { get; set; }
        public QueueMode QueueMode { get; set; }

        public int MatchResultId { get; set; }
        public MatchResult MatchResult { get; set; }

        //public List<int> HeroesId { get; set; }
        //public List<Hero> Heroes { get; set; }
        public int HeroId { get; set; }
        public Hero Hero { get; set; }

        public int MapId { get; set; }
        public Map Map { get; set; }

        public int GroupSizeId { get; set; }
        public GroupSize GroupSize { get; set; }

        //public List<int> TeammatesId { get; set; }
        //public List<Teammate> Teammates { get; set; }
        public int TeammateId { get; set; }
        public Teammate Teammate { get; set; }

        public int RankUpdate {  get; set; }

        [NotMapped]
        public QueueMode MatchQueueMode { get { return DataWorker.GetQueueModeById(QueueModeId); } }
        [NotMapped]
        public MatchResult MatchMatchResult { get { return DataWorker.GetMatchResultById(MatchResultId); } }
        [NotMapped]
        public Hero MatchHero { get { return DataWorker.GetHeroById(HeroId); } }
        [NotMapped]
        public Map MatchMap { get { return DataWorker.GetMapById(MapId); } }
        [NotMapped]
        public GroupSize MatchGroupSize { get { return DataWorker.GetGroupSizeById(GroupSizeId); } }
        [NotMapped]
        public Teammate MatchTeammate { get { return DataWorker.GetTeammateById(TeammateId); } }
        //[NotMapped]
        //public string MatchHeroes { get { return DataWorker.GetHeroesListByIds(HeroesId); } }
        //[NotMapped]
        //public string MatchTeammates { get { return DataWorker.GetTeammatesListByIds(TeammatesId); } }
    }
}
