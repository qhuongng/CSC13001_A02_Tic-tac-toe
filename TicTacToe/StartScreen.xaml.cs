using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for StartScreen.xaml
    /// </summary>
    public partial class StartScreen : UserControl
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow) Window.GetWindow(this);

            if (mw.Click.NaturalDuration.HasTimeSpan)
            {
                mw.Click.Position = TimeSpan.Zero;
            }

            mw.Click.Play();

            mw.BoardSizeDialog.Reset();
            mw.BoardSizeDialog.Visibility = Visibility.Visible;
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);

            if (mw.Click.NaturalDuration.HasTimeSpan)
            {
                mw.Click.Position = TimeSpan.Zero;
            }

            mw.Click.Play();

            mw.LoadDialog.RefreshSaveList();
            mw.LoadDialog.Visibility = Visibility.Visible;
        }

        private void QuitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);

            if (mw.Click.NaturalDuration.HasTimeSpan)
            {
                mw.Click.Position = TimeSpan.Zero;
            }

            mw.Click.Play();

            mw.Close();
        }

        private void MusicBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);

            if (mw.Click.NaturalDuration.HasTimeSpan)
            {
                mw.Click.Position = TimeSpan.Zero;
            }

            mw.Click.Play();

            if (mw.IsMusicOn)
            {
                mw.Bgm.Pause();
                MusicIcon.Source = new BitmapImage(new Uri("pack://application:,,,/icons/music_off.png"));

            }
            else
            {
                mw.Bgm.Play();
                MusicIcon.Source = new BitmapImage(new Uri("pack://application:,,,/icons/music_on.png"));
            }

            mw.IsMusicOn = !mw.IsMusicOn;
        }

        public void ToggleMusicIcon()
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);

            if (mw.IsMusicOn)
            {
                MusicIcon.Source = new BitmapImage(new Uri("pack://application:,,,/icons/music_on.png"));

            }
            else
            {
                MusicIcon.Source = new BitmapImage(new Uri("pack://application:,,,/icons/music_off.png"));
            }
        }
    }
}
