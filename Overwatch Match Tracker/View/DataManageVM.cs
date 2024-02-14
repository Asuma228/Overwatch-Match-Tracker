using ManageStaffDBApp.Models;
using Overwatch_Match_Tracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Overwatch_Match_Tracker.View
{
    internal class DataManageVM : INotifyPropertyChanged
    {
        private List<Match> allMatches = DataWorker.GetAllMatches();
        private List<MatchResult> allMatchResults = DataWorker.GetAllMatchResults();
        private List<QueueMode> allQueueModes = DataWorker.GetAllQueueModes();
        private List<Hero> allHeroes = DataWorker.GetAllHeroes();
        private List<Map> allMaps = DataWorker.GetAllMaps();
        private List<GroupSize> allGroupSizes = DataWorker.GetAllGroupSizes();
        private List<Teammate> allTeammates = DataWorker.GetAllTeammates();


        public List<Match> AllMatches
        {
            get { return allMatches; }
            set
            {
                allMatches = value;
                NotifyPropertyChanged("All Matches");
            }
        }
        public List<QueueMode> AllQueueModes
        {
            get { return allQueueModes; }
            set
            {
                allQueueModes = value;
                NotifyPropertyChanged("All QueueModes");
            }
        }
        public List<MatchResult> AllMatchResults
        {
            get { return allMatchResults; }
            set
            {
                allMatchResults = value;
                NotifyPropertyChanged("All MatchResults");
            }
        }
        public List<Hero> AllHeroes
        {
            get { return allHeroes; }
            set
            {
                allHeroes = value;
                NotifyPropertyChanged("All Heroes");
            }
        }
        public List<Map> AllMaps
        {
            get { return allMaps; }
            set
            {
                allMaps = value;
                NotifyPropertyChanged("All Maps");
            }
        }
        public List<GroupSize> AllGroupSizes
        {
            get { return allGroupSizes; }
            set
            {
                allGroupSizes = value;
                NotifyPropertyChanged("All GroupSizes");
            }
        }
        public List<Teammate> AllTeammates
        {
            get { return allTeammates; }
            set
            {
                allTeammates = value;
                NotifyPropertyChanged("All Teammates");
            }
        }


        private static void OpenAddNewElementWindowMethod()
        {
            AddNewElementWindow newElemenWindow = new();
            SetCenterPositionAndOpen(newElemenWindow);
        }

        private readonly RelayCommand openAddNewElementWindow;
        public RelayCommand OpenAddNewElementWindow
        {
            get
            {
                return openAddNewElementWindow ?? new RelayCommand(obj =>
                {
                    OpenAddNewElementWindowMethod();
                }
                );
            }
        }

        public QueueMode MatchQueueMode { get; set; }
        public MatchResult MatchMatchResult { get; set; }
        public Hero MatchHero { get; set; }
        public Map MatchMap { get; set; }
        public GroupSize MatchGroupSize { get; set; }
        public Teammate MatchTeammate { get; set; }
        public string QueueModeName { get; set; }
        public string MatchResultName { get; set; }
        public string HeroName { get; set; }
        public string HeroRoleName {  get; set; }
        public string MapName { get; set; }
        public string GroupSizeName { get; set; }
        public string TeammateName { get; set; }
        public int RankUpdate {  get; set; }

        #region COMMANDS TO ADD

        private RelayCommand addNewMatch;
        public RelayCommand AddNewMatch
        {
            get
            {
                return addNewMatch ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    resultStr = DataWorker.CreateMatch(
                                            MatchQueueMode,
                                            MatchMatchResult,
                                            MatchHero,
                                            MatchMap,
                                            MatchGroupSize,
                                            MatchTeammate,
                                            RankUpdate);
                    ShowMessageToUser(resultStr);
                    UpdateAllMatchesView();
                    SetNullValuesToProperties();
                }
                    );
            }
        }
        private RelayCommand addNewQueueMode;
        public RelayCommand AddNewQueueMode
        {
            get
            {
                return addNewQueueMode ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    resultStr = DataWorker.CreateQueueMode(QueueModeName);
                    ShowMessageToUser(resultStr);
                    UpdateAllMatchesView();
                    SetNullValuesToProperties();
                });
            }
        }

        private RelayCommand addNewMatchResult;
        public RelayCommand AddNewMatchResult
        {
            get
            {
                return addNewMatchResult ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    resultStr = DataWorker.CreateMatchResult(MatchResultName);
                    ShowMessageToUser(resultStr);
                    UpdateAllMatchesView();
                    SetNullValuesToProperties();
                });
            }
        }
        private RelayCommand addNewHero;
        public RelayCommand AddNewHero
        {
            get
            {
                return addNewHero ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    resultStr = DataWorker.CreateHero(HeroName, HeroRoleName);
                    ShowMessageToUser(resultStr);
                    UpdateAllMatchesView();
                    SetNullValuesToProperties();
                });
            }
        }
        private RelayCommand addNewMap;
        public RelayCommand AddNewMap
        {
            get
            {
                return addNewMap ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    resultStr = DataWorker.CreateMap(MapName);
                    ShowMessageToUser(resultStr);
                    UpdateAllMatchesView();
                    SetNullValuesToProperties();
                });
            }
        }
        private RelayCommand addNewGroupSize;
        public RelayCommand AddNewGroupSize
        {
            get
            {
                return addNewGroupSize ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    resultStr = DataWorker.CreateGroupSize(GroupSizeName);
                    ShowMessageToUser(resultStr);
                    UpdateAllMatchesView();
                    SetNullValuesToProperties();
                });
            }
        }
        private RelayCommand addNewTeammate;
        public RelayCommand AddNewTeammate
        {
            get
            {
                return addNewTeammate ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    resultStr = DataWorker.CreateTeammate(TeammateName);
                    ShowMessageToUser(resultStr);
                    UpdateAllMatchesView();
                    SetNullValuesToProperties();
                });
            }
        }

        #endregion

        private void SetNullValuesToProperties()
        {
            
            MatchQueueMode = null;
            MatchMatchResult = null;
            MatchHero = null;
            MatchMap = null;
            MatchGroupSize = null;
            MatchTeammate = null;
            QueueModeName = null;
            MatchResultName = "";
            HeroName = "";
            HeroRoleName = "";
            MapName = "";
            GroupSizeName = "";
            TeammateName = "";
        }

        private void UpdateAllMatchesView()
        {
            AllMatches = DataWorker.GetAllMatches();
            MainWindow.AllMatchesView.ItemsSource = null;
            MainWindow.AllMatchesView.Items.Clear();
            MainWindow.AllMatchesView.ItemsSource = AllMatches;
            MainWindow.AllMatchesView.Items.Refresh();
        }


        private void SetRedBlockControl(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        private static void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new(message);
            SetCenterPositionAndOpen(messageView);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
