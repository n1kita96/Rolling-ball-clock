using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;
/// ===============================
///  AUTHOR 
///  Mykyta Shvets
/// ===============================
namespace Time_and_motion
{
    public partial class MainWindow : Window
    {
        TimeAndMotionVM timeAndMotionVM = new TimeAndMotionVM();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = timeAndMotionVM;
        }

        private void AddOne_Click(object sender, RoutedEventArgs e)
        {
            timeAndMotionVM.Increment();
            Slider.Value = timeAndMotionVM.BallsCount;
        }

        private void SubOne_Click(object sender, RoutedEventArgs e)
        {
            timeAndMotionVM.Decrement();
            Slider.Value = timeAndMotionVM.BallsCount;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void ReadMore_Click(object sender, RoutedEventArgs e)
        {
            ReadMore readMore = new ReadMore();
            readMore.ShowDialog();
        }
    }
}
