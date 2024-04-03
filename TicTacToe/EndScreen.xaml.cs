using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for EndScreen.xaml
    /// </summary>
    public partial class EndScreen : UserControl
    {
        public MediaPlayer endTheme { get; set; }

        public EndScreen()
        {
            InitializeComponent();

            endTheme = new MediaPlayer();
            endTheme.Open(new Uri("pack://siteoforigin:,,,/audio/end.mp3"));
            endTheme.MediaEnded += new EventHandler(Media_Ended);
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            endTheme.Position = TimeSpan.Zero;
            endTheme.Play();
        }

        private void MenuBtn_Click(object sender, RoutedEventArgs e)
        {
            endTheme.Stop();

            MainWindow mw = (MainWindow)Window.GetWindow(this);

            if (mw.Click.NaturalDuration.HasTimeSpan)
            {
                mw.Click.Position = TimeSpan.Zero;
            }

            mw.Click.Play();

            mw.HideAllExcept(mw.Root, mw.StartScreen);
            mw.ResumeBgm();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            endTheme.Stop();

            MainWindow mw = (MainWindow)Window.GetWindow(this);

            if (mw.Click.NaturalDuration.HasTimeSpan)
            {
                mw.Click.Position = TimeSpan.Zero;
            }

            mw.Click.Play();

            mw.ResumeBgm();
        }

        public void PlayEndTheme()
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);

            if (mw.IsMusicOn)
            {
                if (endTheme.NaturalDuration.HasTimeSpan)
                {
                    endTheme.Position = TimeSpan.Zero;
                }

                endTheme.Play();
            }
        }

        public void SetWinner(bool isPlayerX)
        {
            if (isPlayerX)
            {
                WinnerIcon.Source = new BitmapImage(new Uri("pack://application:,,,/icons/x.png"));
            }
            else
            {
                WinnerIcon.Source = new BitmapImage(new Uri("pack://application:,,,/icons/o.png"));
            }

            TieMsg.Visibility = Visibility.Collapsed;
            WinMsg.Visibility = Visibility.Visible;
        }

        public void SetTie()
        {
            WinMsg.Visibility = Visibility.Collapsed;
            TieMsg.Visibility = Visibility.Visible;
        }
    }
}
