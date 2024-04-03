using System.Windows;
using System.Windows.Media;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        public bool IsMusicOn { get; set; }
        public MediaPlayer Bgm { get; set; }
        public MediaPlayer Click { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            IsMusicOn = true;

            Bgm = new MediaPlayer();
            Bgm.Open(new Uri("pack://siteoforigin:,,,/audio/bgm.mp3"));
            Bgm.MediaEnded += new EventHandler(Media_Ended);
            Bgm.Play();

            Click = new MediaPlayer();
            Click.Open(new Uri("pack://siteoforigin:,,,/audio/click.mp3"));
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            Bgm.Position = TimeSpan.Zero;
            Bgm.Play();
        }

        public void PauseBgm()
        {
            Bgm.Pause();
        }

        public void ResumeBgm()
        {
            if (IsMusicOn)
            {
                Bgm.Play();
            }
        }

        public void HideAllExcept(UIElement parent, UIElement visibleElement)
        {
            var childNumber = VisualTreeHelper.GetChildrenCount(parent);

            for (var i = 0; i < childNumber; i++)
            {
                var uiElement = VisualTreeHelper.GetChild(parent, i) as UIElement;

                if (uiElement != null && uiElement == visibleElement)
                {
                    visibleElement.Visibility = Visibility.Visible;
                }

                if (uiElement != null && uiElement != visibleElement)
                {
                    uiElement.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
