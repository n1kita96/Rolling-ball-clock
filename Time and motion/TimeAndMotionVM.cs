using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
/// ===============================
///  AUTHOR 
///  Mykyta Shvets
/// ===============================
namespace Time_and_motion
{
    class TimeAndMotionVM : INotifyPropertyChanged
    {
        const int MAX_BALLS = 127;
        const int MIN_BALLS = 27;

        public TimeAndMotionVM()
        {
            BallsCount = MIN_BALLS;
        }

        int ballsCount;
        public int BallsCount
        {
            get => ballsCount;
            set
            {
                ballsCount = value;
                GetDays();
            }
        }

        string days;
        public string Days
        {
            get => days;
            set
            {
                days = value;
                OnPropertyChanged();
            }
        }

        public void Increment()
        {
            if (BallsCount < MAX_BALLS)
            {
                BallsCount++;
            }
        }

        public void Decrement()
        {
            if (BallsCount > MIN_BALLS)
            {
                BallsCount--;
            }
        }

        public void GetDays()
        {
            Queue<Ball> queue = new Queue<Ball>();
            for (int i = 0; i < ballsCount; i++)
            {
                queue.Enqueue(new Ball() {Number = i});
            }
            Clock clock = new Clock(queue);
            Days = $"{BallsCount} balls cycle after {clock.GetDays()} days";
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
