using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for BoardSizeDialog.xaml
    /// </summary>
    public partial class BoardSizeDialog : UserControl
    {
        public BoardSizeDialog()
        {
            InitializeComponent();
        }

        private void HandleSizeInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);

            if (mw.Click.NaturalDuration.HasTimeSpan)
            {
                mw.Click.Position = TimeSpan.Zero;
            }

            mw.Click.Play();

            mw.HideAllExcept(mw.Root, mw.StartScreen);
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);

            if (mw.Click.NaturalDuration.HasTimeSpan)
            {
                mw.Click.Position = TimeSpan.Zero;
            }

            mw.Click.Play();

            mw.GameScreen.SetBoardSize(int.Parse(RowTxtInput.Text), int.Parse(ColTxtInput.Text));
            mw.GameScreen.ResetGame(null, null);

            // if the bgm is turned off from the start screen, change the icon in the game screen
            if (!mw.IsMusicOn)
            {
                mw.GameScreen.MusicOff();
            }

            mw.HideAllExcept(mw.Root, mw.GameScreen);
        }

        public void Reset()
        {
            RowTxtInput.Text = "12";
            ColTxtInput.Text = "12";
        }
    }

    public class BoardSizeRestrictor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool valid = true;

            foreach (object value in values)
            {
                if (string.IsNullOrWhiteSpace((string) value) || int.Parse((string) value) < 5)
                {
                    valid = false;
                }
            }

            return valid;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
