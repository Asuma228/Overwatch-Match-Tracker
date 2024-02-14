using Overwatch_Match_Tracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Overwatch_Match_Tracker.Model
{
    internal class DataWorker
    {
        //получить все режимы очереди
        public static List<QueueMode> GetAllQueueModes()
        {
            using ApplicationContext db = new();
            {
                var result = db.QueueModes.ToList();
                return result;
            }
        }

        //получить все результаты
        public static List<MatchResult> GetAllMatchResults()
        {
            using ApplicationContext db = new();
            {
                var result = db.MatchResults.ToList();
                return result;
            }
        }

        //получить всех героев
        public static List<Hero> GetAllHeroes()
        {
            using ApplicationContext db = new();
            {
                var result = db.Heroes.ToList();
                return result;
            }
        }

        //получить все карты
        public static List<Map> GetAllMaps()
        {
            using ApplicationContext db = new();
            {
                var result = db.Maps.ToList();
                return result;
            }
        }
        //получить все размеры групп
        public static List<GroupSize> GetAllGroupSizes()
        {
            using ApplicationContext db = new();
            {
                var result = db.GroupSizes.ToList();
                return result;
            }
        }

        //получить всех тиммейтов
        public static List<Teammate> GetAllTeammates()
        {
            using ApplicationContext db = new();
            {
                var result = db.Teammates.ToList();
                return result;
            }
        }
        //получить все матчи
        public static List<Match> GetAllMatches()
        {
            using ApplicationContext db = new();
            {
                var result = db.Matches.ToList();
                return result;
            }
        }

        //создание матча
        public static string CreateMatch
            (
            QueueMode queueMode,
            MatchResult matchResult,
            Hero hero,
            Map map,
            GroupSize groupSize,
            Teammate teammate,
            int rankUpdate
            )
        {
            string result;// = $"Игра {name} с окладом {salary} уже существует!";
            using ApplicationContext db = new();
            //bool checkIsExist = db.Matches.Any(x => x.Id == name && x.Salary == salary);
            //if (!checkIsExist)
            //{
            Match newMatch = new()
            {
                QueueModeId = queueMode.Id,
                MatchResultId = matchResult.Id,
                HeroId = hero.Id,
                MapId = map.Id,
                GroupSizeId = groupSize.Id,
                TeammateId = teammate.Id,
                RankUpdate = rankUpdate
            };
            db.Matches.Add(newMatch);
            db.SaveChanges();
            result = "Сделано!";
            //}
            return result;
        }
        //редактирование матча
        //удаление матча

        //создание размера группы
        public static string CreateGroupSize(string name)
        {
            string result = $"Размер группы {name} уже существует!";
            using ApplicationContext db = new();
            bool checkIsExist = db.GroupSizes.Any(x => x.Name == name);

            if (!checkIsExist)
            {
                GroupSize newGroupSize = new()
                {
                    Name = name,
                };
                db.GroupSizes.Add(newGroupSize);
                db.SaveChanges();
                result = "Сделано!";
            }
            return result;
        }
        //редактирование размера группы
        //удаление размера группы

        //создание героя
        public static string CreateHero(string name, string role)
        {
            string result = $"Герой {name} уже существует!";
            using ApplicationContext db = new();
            bool checkIsExist = db.Heroes.Any(x => x.Name == name);

            if (!checkIsExist)
            {
                Hero newHero = new()
                {
                    Name = name,
                    Role = role
                };
                db.Heroes.Add(newHero);
                db.SaveChanges();
                result = "Сделано!";
            }
            return result;
        }
        //редактирование героя
        //удаление героя

        //создание карты
        public static string CreateMap(string name)
        {
            string result = $"Карта {name} уже существует!";
            using ApplicationContext db = new();
            bool checkIsExist = db.Maps.Any(x => x.Name == name);

            if (!checkIsExist)
            {
                Map newMap = new()
                {
                    Name = name,
                };
                db.Maps.Add(newMap);
                db.SaveChanges();
                result = "Сделано!";
            }
            return result;
        }
        //редактирование карты
        //удаление карты

        //создание результата
        public static string CreateMatchResult(string name)
        {
            string result = $"Результат {name} уже существует!";
            using ApplicationContext db = new();
            bool checkIsExist = db.MatchResults.Any(x => x.Name == name);

            if (!checkIsExist)
            {
                MatchResult newMatchResult = new()
                {
                    Name = name,
                };
                db.MatchResults.Add(newMatchResult);
                db.SaveChanges();
                result = "Сделано!";
            }
            return result;
        }
        //редактирование результата
        //удаление результата

        //создание режима очереди
        public static string CreateQueueMode(string name)
        {
            string result = $"Режим очереди {name} уже существует!";
            using ApplicationContext db = new();
            bool checkIsExist = db.QueueModes.Any(x => x.Name == name);

            if (!checkIsExist)
            {
                QueueMode newQueueMode = new()
                {
                    Name = name,
                };
                db.QueueModes.Add(newQueueMode);
                db.SaveChanges();
                result = "Сделано!";
            }
            return result;
        }
        //редактирование режима очереди
        //удаление режима очереди

        //создание тиммейта
        public static string CreateTeammate(string battletag)
        {
            string result = $"Тиммейт {battletag} уже существует!";
            using ApplicationContext db = new();
            bool checkIsExist = db.Teammates.Any(x => x.BattleTag == battletag);

            if (!checkIsExist)
            {
                Teammate newTeammate = new()
                {
                    BattleTag = battletag,
                };
                db.Teammates.Add(newTeammate);
                db.SaveChanges();
                result = "Сделано!";
            }
            return result;
        }
        //редактирование тиммейта
        //удаление тиммейта

        //получение элемента по айди
        public static QueueMode GetQueueModeById(int id)
        {
            using ApplicationContext db = new();
            {
                QueueMode queueMode = db.QueueModes.FirstOrDefault(x => x.Id == id);
                return queueMode;
            }
        }
        public static MatchResult GetMatchResultById(int id)
        {
            using ApplicationContext db = new();
            {
                MatchResult matchResult  = db.MatchResults.FirstOrDefault(x => x.Id == id);
                return matchResult;
            }
        }
        public static Hero GetHeroById(int id)
        {
            using ApplicationContext db = new();
            {
                Hero hero = db.Heroes.FirstOrDefault(x => x.Id == id);
                return hero;
            }
        }
        public static Map GetMapById(int id)
        {
            using ApplicationContext db = new();
            {
                Map map = db.Maps.FirstOrDefault(x => x.Id == id);
                return map;
            }
        }
        public static GroupSize GetGroupSizeById(int id)
        {
            using ApplicationContext db = new();
            {
                GroupSize gs = db.GroupSizes.FirstOrDefault(x => x.Id == id);
                return gs;
            }
        }
        public static Teammate GetTeammateById(int id)
        {
            using ApplicationContext db = new();
            {
                Teammate t = db.Teammates.FirstOrDefault(x => x.Id == id);
                return t;
            }
        }

        /*public static string GetTeammateNameById(int id)
        {
            using ApplicationContext db = new();
            {
                List<Teammate> matchTeammates = (from MatchTeammates in GetAllTeammates() where MatchTeammates.TeammateId == id select Match).ToList();
                string t = string.Join(", ", matchTeammates);
                return t;
            }
        }*/
    }
}
