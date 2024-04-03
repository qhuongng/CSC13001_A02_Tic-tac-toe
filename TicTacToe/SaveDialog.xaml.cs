using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TicTacToe
{
    /// <summary>
    /// 
    /// STRUCTURE OF A SAVE FILE
    /// M
    /// N
    /// movesMade
    /// isPlayerX
    /// single-string of all cells on the board
    /// 
    /// </summary>
    public partial class SaveDialog : UserControl
    {
        public string Fname {  get; set; }

        public SaveDialog()
        {
            InitializeComponent();
            UpdateFname();
        }

        public void UpdateFname()
        {
            Fname = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            FnameTxtInput.Text = Fname;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // replace the white spaces in input with underscores
            Fname = FnameTxtInput.Text.Replace(" ", "_");

            // create saves folder if it doesn't exist
            Directory.CreateDirectory(@".\saves\");

            string path = @".\saves\" + Fname + ".caro";

            if (File.Exists(path))
            {
                ErrorMsg.Visibility = Visibility.Visible;
                return;
            }

            FileStream fs = new FileStream(path, FileMode.CreateNew);
            BinaryWriter w = new BinaryWriter(fs);
            MainWindow mw = (MainWindow)Window.GetWindow(this);
            GameScreen cur = mw.GameScreen;

            // convert the board into a string for convenience
            string boardState = "";

            for (int r = 0; r < cur.M; r++)
            {
                for (int c = 0; c < cur.N; c++)
                {
                    if (cur.Board[r, c] == '\0')
                    {
                        boardState += "-";
                    }
                    else
                    {
                        boardState += cur.Board[r, c];
                    }
                }
            }

            w.Write(cur.M);
            w.Write(cur.N);
            w.Write(cur.MovesMade);
            w.Write(cur.IsPlayerX);
            w.Write(boardState);

            w.Close();
            fs.Close();

            if (mw.Click.NaturalDuration.HasTimeSpan)
            {
                mw.Click.Position = TimeSpan.Zero;
            }

            mw.Click.Play();

            mw.HideAllExcept(mw.Root, mw.StartScreen); 
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);

            if (mw.Click.NaturalDuration.HasTimeSpan)
            {
                mw.Click.Position = TimeSpan.Zero;
            }

            mw.Click.Play();

            Visibility = Visibility.Collapsed;
        }
    }
}
