using MediaViewer.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MediaViewer.UserControls
{
    /// <summary>
    /// Interaction logic for MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer : UserControl
    {
        private bool _userMovingSlider;
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MediaProperty =
            DependencyProperty.Register("Media", typeof(Media), typeof(MediaPlayer));

        public Media Media
        {
            get { return GetValue(MediaProperty) as Media; }
            set { SetValue(MediaProperty, value); }
        }

        public MediaPlayer()
        {
            InitializeComponent();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Clock = null;
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            MediaClock clock = mediaElement.Clock;
            if (clock != null)
            {
                if (clock.IsPaused)
                {
                    clock.Controller.Resume();
                }
                else
                {
                    clock.Controller.Pause();
                }
            }
            else
            {
                if (Media == null) return;

                MediaTimeline mediaTimeline = new MediaTimeline(Media.Uri);
                clock = mediaTimeline.CreateClock();
                clock.CurrentTimeInvalidated += Clock_CurrentTimeInvalidated;
                mediaElement.Clock = clock;
            }
        }

        private void Clock_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            if (mediaElement.Clock == null || _userMovingSlider)
            {
                return;
            }
            progressSlider.Value = mediaElement.Clock.CurrentTime.Value.TotalMilliseconds;
        }

        private void progressSlider_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _userMovingSlider = true;
        }

        private void progressSlider_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MediaClock clock = mediaElement.Clock;

            if (clock != null)
            {
                TimeSpan offset = TimeSpan.FromMilliseconds(progressSlider.Value);

                clock.Controller.Seek(offset, System.Windows.Media.Animation.TimeSeekOrigin.BeginTime);
            }

            _userMovingSlider = false;
        }

        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            progressSlider.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaElement.Clock = null;

        }
    }
}
