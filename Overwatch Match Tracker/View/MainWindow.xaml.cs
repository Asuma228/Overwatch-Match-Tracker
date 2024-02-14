using System.Windows;
using System.Windows.Controls;

namespace Overwatch_Match_Tracker.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllMatchesView;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            AllMatchesView = ViewAllMatches;
            FrameworkElement.StyleProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata
            {
                DefaultValue = FindResource(typeof(Window))
            });
        }
    }
}
