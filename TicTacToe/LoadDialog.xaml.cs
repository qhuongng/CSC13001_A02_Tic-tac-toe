using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

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
    public partial class LoadDialog : UserControl
    {
        public ObservableCollection<string> SavedGames { get; set; }

        public LoadDialog()
        {
            InitializeComponent();
            DataContext = this;
            SavedGames = new ObservableCollection<string>();
        }

        public void RefreshSaveList()
        {
            SavedGames.Clear();

            try
            {
                foreach (string f in Directory.GetFiles(@"./saves/"))
                {
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(f);
                    SavedGames.Add(fileName);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream(@"./saves/" + SaveList.SelectedItem.ToString() + ".caro", FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);
            int M, N, movesMade;
            bool isPlayerX;
            string boardState;

            M = r.ReadInt32();
            N = r.ReadInt32();
            movesMade = r.ReadInt32();
            isPlayerX = r.ReadBoolean();
            boardState = r.ReadString();

            r.Close();
            fs.Close();

            MainWindow mw = (MainWindow)Window.GetWindow(this);
            GameScreen gs = mw.GameScreen;

            if (mw.Click.NaturalDuration.HasTimeSpan)
            {
                mw.Click.Position = TimeSpan.Zero;
            }

            mw.Click.Play();

            gs.LoadGame(M, N, movesMade, isPlayerX, boardState);
            mw.HideAllExcept(mw.Root, gs);
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);

            if (mw.Click.NaturalDuration.HasTimeSpan)
            {
                mw.Click.Position = TimeSpan.Zero;
            }

            mw.Click.Play();

            string toDelete = SaveList.SelectedItem.ToString();

            File.Delete(@".\saves\" + toDelete + ".caro");

            RefreshSaveList();
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

        private void SaveList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);

            if (mw.Click.NaturalDuration.HasTimeSpan)
            {
                mw.Click.Position = TimeSpan.Zero;
            }

            mw.Click.Play();

            if (SaveList.SelectedItem != null)
            {
                LoadBtn.IsEnabled = true;
                DelBtn.IsEnabled = true;
            }
            else
            {
                LoadBtn.IsEnabled = false;
                DelBtn.IsEnabled = false;
            }
        }
    }
}
