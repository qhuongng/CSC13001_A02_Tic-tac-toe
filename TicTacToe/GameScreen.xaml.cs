using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for GameScreen.xaml
    /// </summary>
    public class DrawingVisualHost : FrameworkElement
    {
        private DrawingVisual _dv;

        public DrawingVisualHost()
        {
            _dv = new DrawingVisual();
        }

        protected override int VisualChildrenCount => 1;

        protected override Visual GetVisualChild(int index)
        {
            return _dv;
        }

        public DrawingContext RenderOpen()
        {
            return _dv.RenderOpen();
        }
    }

    public partial class GameScreen : UserControl
    {
        // board dimensions
        public int M { get; set; }
        public int N { get; set; }

        // starting coordinates for grid redrawing
        // this ensures the grid is centered and the cells are squared when the window is resized
        double startX;
        double startY;

        private const int WINNING_COUNT = 5;

        private double cellSize;

        public bool IsPlayerX { get; set; }

        // to check for early tíes
        private bool xCanWin = true;
        private bool oCanWin = true;

        private bool isSoundOn = true;

        // to prevent making moves with the keyboard when the game is over
        // retain other keyboard shortcuts and events
        private bool isGameOver = false;

        private readonly Brush xBrush = Brushes.Red;
        private readonly Pen oBrush = new Pen(Brushes.Blue, 2);
        private readonly Pen gridBrush = new Pen(Brushes.Black, 2);
        private readonly Pen cursorBrush = new Pen(Brushes.Green, 4);

        public char[,] Board { get; set; }

        public int[] CursorCoord { get; set; }
        public DrawingVisualHost CursorHost { get; set; }

        public int MovesMade { get; set; }

        private MediaPlayer mpX;
        private MediaPlayer mpO;

        public GameScreen()
        {
            InitializeComponent();

            mpX = new MediaPlayer();
            mpX.Open(new Uri("pack://siteoforigin:,,,/audio/tic.mp3"));

            mpO = new MediaPlayer();
            mpO.Open(new Uri("pack://siteoforigin:,,,/audio/toc.mp3"));

            CursorCoord = [0, 0];
            cellSize = Math.Min(GameCanvas.ActualWidth / N, GameCanvas.ActualHeight / M);
        }

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            cellSize = Math.Min(GameCanvas.ActualWidth / N, GameCanvas.ActualHeight / M);

            GameCanvas.Children.Clear();
            DrawGrid();
            DrawCursor();

            for (int y = 0; y < M; y++)
            {
                for (int x = 0; x < N; x++)
                {
                    DrawSymbol(y, x, Board[y, x]);
                }
            }
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int x = (int)((e.GetPosition(GameCanvas).X - startX) / cellSize);
            int y = (int)((e.GetPosition(GameCanvas).Y - startY) / cellSize);

            if ((startX > 0 && e.GetPosition(GameCanvas).X < startX) || (startY > 0 && e.GetPosition(GameCanvas).Y < startY))
            {
                return;
            }

            MakeMove(x, y);
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);

            if (mw.SaveDialog.Visibility == Visibility.Visible || mw.HelpScreen.Visibility == Visibility.Visible)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Left:
                    if (!isGameOver && CursorCoord[1] > 0)
                    {
                        CursorCoord[1]--;
                    }

                    PlayClick();
                    break;
                case Key.Right:
                    if (!isGameOver && CursorCoord[1] < N - 1)
                    {
                        CursorCoord[1]++;
                    }

                    PlayClick();
                    break;
                case Key.Up:
                    if (!isGameOver && CursorCoord[0] > 0)
                    {
                        CursorCoord[0]--;
                    }

                    PlayClick();
                    break;
                case Key.Down:
                    if (!isGameOver && CursorCoord[0] < M - 1)
                    {
                        CursorCoord[0]++;
                    }

                    PlayClick();
                    break;
                case Key.Return:
                    if (!isGameOver)
                    {
                        MakeMove(CursorCoord[1], CursorCoord[0]);
                    }
                    
                    break;
                case Key.R:
                    ResetGame(null, null);
                    PlayClick();

                    break;
                case Key.L:
                    if (!isGameOver)
                    {
                        SaveBtn_Click(null, null);
                    }

                    break;
                case Key.Q:
                    BackBtn_Click(null, null);
                    break;
                case Key.M:
                    MusicBtn_Click(null, null);
                    break;
                case Key.S:
                    SoundBtn_Click(null, null);
                    break;
                case Key.H:
                    HelpBtn_Click(null, null);
                    break;
            }
            
            DrawCursor();
        }

        public void MakeMove(int x, int y)
        {
            CursorCoord = [y, x];
            DrawCursor();

            if (x < N && y < M && Board[y, x] == '\0')
            {
                if (IsPlayerX)
                {
                    DrawSymbol(y, x, 'X');

                    if (isSoundOn)
                    {
                        if (mpX.NaturalDuration.HasTimeSpan)
                        {
                            mpX.Position = TimeSpan.Zero;
                        }

                        mpX.Play();
                    }
                }
                else
                {
                    DrawSymbol(y, x, 'O');

                    if (isSoundOn)
                    {
                        if (mpO.NaturalDuration.HasTimeSpan)
                        {
                            mpO.Position = TimeSpan.Zero;
                        }

                        mpO.Play();
                    }
                }

                Board[y, x] = IsPlayerX ? 'X' : 'O';

                MovesMade++;
                CheckGameOver(y, x);

                IsPlayerX = !IsPlayerX;
                TogglePlayerIcon();
            }
        }

        public void SetBoardSize(int m, int n)
        {
            M = m;
            N = n;

            Board = new char[M, N];

            Canvas_SizeChanged(null, null);
        }

        private void TogglePlayerIcon()
        {
            if (IsPlayerX)
            {
                CurrentPlayer.Source = new BitmapImage(new Uri("pack://application:,,,/icons/x.png"));
            }
            else
            {
                CurrentPlayer.Source = new BitmapImage(new Uri("pack://application:,,,/icons/o.png"));
            }
        }

        private void PlayClick()
        {
            if (!isSoundOn)
            {
                return;
            }

            MainWindow mw = (MainWindow)Window.GetWindow(this);

            if (mw.Click.NaturalDuration.HasTimeSpan)
            {
                mw.Click.Position = TimeSpan.Zero;
            }

            mw.Click.Play();
        }

        private void DrawGrid()
        {
            DrawingVisualHost gridHost = new DrawingVisualHost();

            startX = (GameCanvas.ActualWidth - N * cellSize) / 2;
            startY = (GameCanvas.ActualHeight - M * cellSize) / 2;

            using (DrawingContext dc = gridHost.RenderOpen())
            {
                for (int y = 1; y < M; y++)
                {
                    dc.DrawLine(gridBrush, new Point(startX, startY + y * cellSize), new Point(startX + N * cellSize, startY + y * cellSize));
                }

                for (int x = 1; x < N; x++)
                {
                    dc.DrawLine(gridBrush, new Point(startX + x * cellSize, startY), new Point(startX + x * cellSize, startY + M * cellSize));
                }
            }

            GameCanvas.Children.Add(gridHost);
        }

        private void DrawSymbol(int y, int x, char player)
        {
            DrawingVisualHost symbolHost = new DrawingVisualHost();

            using (DrawingContext dc = symbolHost.RenderOpen())
            {
                if (player == 'X')
                {
                    dc.DrawLine(new Pen(xBrush, 2), new Point(startX + x * cellSize + cellSize / 4, startY + y * cellSize + cellSize / 4), new Point(startX + (x + 1) * cellSize - cellSize / 4, startY + (y + 1) * cellSize - cellSize / 4));
                    dc.DrawLine(new Pen(xBrush, 2), new Point(startX + x * cellSize + cellSize / 4, startY + (y + 1) * cellSize - cellSize / 4), new Point(startX + (x + 1) * cellSize - cellSize / 4, startY + y * cellSize + cellSize / 4));
                }
                else if (player == 'O')
                {
                    dc.DrawEllipse(null, oBrush, new Point(startX + (x + 0.5) * cellSize, startY + (y + 0.5) * cellSize), cellSize / 4, cellSize / 4);
                }
            }

            GameCanvas.Children.Add(symbolHost);
        }

        private void DrawCursor()
        {
            GameCanvas.Children.Remove(CursorHost);

            CursorHost = new DrawingVisualHost();

            using (DrawingContext dc = CursorHost.RenderOpen())
            {
                double cursorLeft = startX + CursorCoord[1] * cellSize;
                double cursorTop = startY + CursorCoord[0] * cellSize;
                double cursorRight = cursorLeft + cellSize;
                double cursorBottom = cursorTop + cellSize;

                dc.DrawRectangle(null, cursorBrush, new Rect(cursorLeft, cursorTop, cellSize, cellSize));
            }

            GameCanvas.Children.Add(CursorHost);
        }

        private char[] GetRow(char[,] board, int rInd)
        {
            int cols = board.GetLength(1);
            char[] row = new char[cols];

            for (int j = 0; j < cols; j++)
            {
                row[j] = board[rInd, j];
            }

            return row;
        }

        private char[] GetColumn(char[,] board, int cInd)
        {
            int rows = board.GetLength(0);
            char[] col = new char[rows];

            for (int i = 0; i < rows; i++)
            {
                col[i] = board[i, cInd];
            }

            return col;
        }

        // pass in the coordinates of the top-left element
        private char[] GetBackSlashDiagonal(char[,] board, int rInd, int cInd) {
            int diagLength = Math.Min(M - rInd, N - cInd);
            char[] diag = new char[diagLength];

            for (int i = 0; i < diagLength; i++)
            {
                diag[i] = board[rInd + i, cInd + i];
            }

            return diag;
        }

        // pass in the coordinates of the top-right element
        private char[] GetForwardSlashDiagonal(char[,] board, int rInd, int cInd)
        {
            int diagLength = Math.Min(M - rInd, cInd + 1);
            char[] diag = new char[diagLength];

            for (int i = 0; i < diagLength; i++)
            {
                diag[i] = board[rInd + i, cInd - i];
            }

            return diag;
        }

        private int LongestSubstring(char[] s)
        {
            int ans = 1, temp = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != '\0' && s[i] == s[i - 1])
                {
                    ++temp;
                }
                else
                {
                    ans = Math.Max(ans, temp);
                    temp = 1;
                }
            }

            ans = Math.Max(ans, temp);

            return ans;
        }

        // y = row index, x = col index
        public void CheckGameOver(int y, int x)
        {
            // check row
            char[] row = GetRow(Board, y);
            int countRow = LongestSubstring(row);

            if (Math.Abs(countRow) == WINNING_COUNT)
            {
                EndGame(false);
                return;  
            }

            // check column
            char[] col = GetColumn(Board, x);
            int countCol = LongestSubstring(col);

            if (Math.Abs(countCol) == WINNING_COUNT)
            {
                EndGame(false);
                return;
            }

            // check diagonal \
            int rInd = Math.Max(y - x, 0);
            int cInd = Math.Max(x - y, 0);
            char[] diag = GetBackSlashDiagonal(Board, rInd, cInd);
            int countDiag = LongestSubstring(diag);

            if (Math.Abs(countDiag) == WINNING_COUNT)
            {
                EndGame(false);
                return;
            }

            // check diagonal /
            rInd = Math.Max(y - (N - 1 - x), 0);
            cInd = Math.Min(x + y, N - 1);
            diag = GetForwardSlashDiagonal(Board, rInd, cInd);
            countDiag = LongestSubstring(diag);

            if (Math.Abs(countDiag) == WINNING_COUNT)
            {
                EndGame(false);
                return;
            }

            CheckWinnability('X');
            CheckWinnability('O');

            // if both cannot win, declare a tie
            if (!xCanWin && !oCanWin)
            {
                EndGame(true);
            }
        }

        private void CheckWinnability(char player)
        {
            if ((player == 'X' && !xCanWin) || (player == 'O' && !oCanWin))
            {
                return;
            }

            char[,] cloneBoard = (char[,])Board.Clone();

            // fill the remaining cells with the player's symbol
            for (int r = 0; r < M; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    if (cloneBoard[r, c] == '\0')
                    {
                        cloneBoard[r, c] = player;
                    }
                }
            }

            // check if any row contains a chain of 5 Os
            for (int r = 0; r < M; r++)
            {
                char[] row = GetRow(cloneBoard, r);
                int countRow = LongestSubstring(row);

                if (countRow >= WINNING_COUNT)
                {
                    // since we know that the player can still win, there is no need to check further
                    return;
                }
            }

            // check columns
            for (int c = 0; c < N; c++)
            {
                char[] col = GetRow(cloneBoard, c);
                int countCol = LongestSubstring(col);

                if (countCol >= WINNING_COUNT)
                {
                    return;
                }
            }

            // check \ diagonals
            // top-left elements in the first row
            for (int c = 0; c < N; c++)
            {
                char[] diag = GetBackSlashDiagonal(cloneBoard, 0, c);

                // only diagonals longer than k have possible winning states
                if (diag.Length >= WINNING_COUNT)
                {
                    int countDiag = LongestSubstring(diag);

                    if (countDiag >= WINNING_COUNT)
                    {
                       return;
                    }
                }
            }

            // top-left elements in the first column
            for (int r = 1; r < M; r++)
            {
                char[] diag = GetBackSlashDiagonal(cloneBoard, r, 0);

                // only diagonals longer than k have possible winning states
                if (diag.Length >= WINNING_COUNT)
                {
                    int countDiag = LongestSubstring(diag);

                    if (countDiag >= WINNING_COUNT)
                    {
                        return;
                    }
                }
            }

            // check / diagonals
            // top-right elements in the first row
            for (int c = 0; c < N; c++)
            {
                char[] diag = GetForwardSlashDiagonal(cloneBoard, 0, c);

                // only diagonals longer than k have possible winning states
                if (diag.Length >= WINNING_COUNT)
                {
                    int countDiag = LongestSubstring(diag);

                    if (countDiag >= WINNING_COUNT)
                    {
                        return;
                    }
                }
            }

            // top-right elements in the last column
            for (int r = 1; r < M; r++)
            {
                char[] diag = GetForwardSlashDiagonal(cloneBoard, r, 0);

                // only diagonals longer than k have possible winning states
                if (diag.Length >= WINNING_COUNT)
                {
                    int countDiag = LongestSubstring(diag);

                    if (countDiag >= WINNING_COUNT)
                    {
                        return;
                    }
                }
            }

            // there is no possible win for the player on the board
            // set <player>CanWin to false to avoid checking next time
            if (player == 'X')
            {
                xCanWin = false;
            }
            else
            {
                oCanWin = false;
            }
        }

        private void EndGame(bool isTie)
        {
            isGameOver = true;

            GameCanvas.MouseLeftButtonDown -= Canvas_MouseLeftButtonDown;

            SaveBtn.IsEnabled = false;
            SaveIcon.Source = new BitmapImage(new Uri("pack://application:,,,/icons/save_disabled.png"));

            MainWindow mw = (MainWindow)Window.GetWindow(this);
            mw.PauseBgm();

            if (isTie)
            {
                mw.EndScreen.SetTie();
            }
            else
            {
                mw.EndScreen.SetWinner(IsPlayerX);
            }
            
            mw.EndScreen.Visibility = Visibility.Visible;
            mw.EndScreen.PlayEndTheme();
        }

        public void ResetGame(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);

            mw.KeyDown -= Canvas_KeyDown;
            GameCanvas.MouseLeftButtonDown -= Canvas_MouseLeftButtonDown;

            IsPlayerX = true;
            CurrentPlayer.Source = new BitmapImage(new Uri("pack://application:,,,/icons/x.png"));

            MovesMade = 0;

            GameCanvas.Children.Clear();
            DrawGrid();

            CursorCoord = [0, 0];
            DrawCursor();

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Board[i, j] = '\0';
                }
            }

            SaveBtn.IsEnabled = true;
            SaveIcon.Source = new BitmapImage(new Uri("pack://application:,,,/icons/save.png"));

            isGameOver = false;

            xCanWin = true;
            oCanWin = true;

            mw.KeyDown += Canvas_KeyDown;
            GameCanvas.MouseLeftButtonDown += Canvas_MouseLeftButtonDown;
        }

        public void LoadGame(int m, int n, int movesMade, bool isPlayerX, string boardState)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);

            mw.KeyDown -= Canvas_KeyDown;
            GameCanvas.MouseLeftButtonDown -= Canvas_MouseLeftButtonDown;

            M = m;
            N = n;
            Board = new char[M, N];

            GameCanvas.Children.Clear();
            DrawGrid();

            CursorCoord = [0, 0];
            DrawCursor();

            MovesMade = movesMade;

            IsPlayerX = isPlayerX;
            TogglePlayerIcon();

            int boardInd = 0;

            for (int r = 0; r < M; r++)
            {
                for (int c = 0; c < N ; c++)
                {
                    if (boardState[boardInd] == '-')
                    {
                        Board[r, c] = '\0';
                    }
                    else
                    {
                        Board[r, c] = boardState[boardInd];
                    }
                    
                    boardInd++;
                }
            }

            for (int y = 0; y < M; y++)
            {
                for (int x = 0; x < N; x++)
                {
                    DrawSymbol(y, x, Board[y, x]);
                }
            }

            SaveBtn.IsEnabled = true;
            SaveIcon.Source = new BitmapImage(new Uri("pack://application:,,,/icons/save.png"));

            isGameOver = false;

            xCanWin = true;
            oCanWin = true;

            mw.KeyDown += Canvas_KeyDown;
            GameCanvas.MouseLeftButtonDown += Canvas_MouseLeftButtonDown;
        }

        private void MusicBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayClick();

            MainWindow mw = (MainWindow)Window.GetWindow(this);

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

            // if the bgm is turned on or off from the game screen, change the icon in the start screen
            mw.StartScreen.ToggleMusicIcon();
        }

        public void MusicOff()
        {
            MusicIcon.Source = new BitmapImage(new Uri("pack://application:,,,/icons/music_off.png"));
        }

        private void SoundBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayClick();

            isSoundOn = !isSoundOn;

            if (isSoundOn)
            {
                SoundIcon.Source = new BitmapImage(new Uri("pack://application:,,,/icons/sound_on.png"));
            }
            else
            {
                SoundIcon.Source = new BitmapImage(new Uri("pack://application:,,,/icons/sound_off.png"));
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayClick();

            MainWindow mw = (MainWindow)Window.GetWindow(this);
            mw.SaveDialog.UpdateFname();
            mw.SaveDialog.Visibility = Visibility.Visible;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayClick();

            MainWindow mw = (MainWindow)Window.GetWindow(this);
            mw.KeyDown -= Canvas_KeyDown;
            mw.HideAllExcept(mw.Root, mw.StartScreen);
        }

        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayClick();

            MainWindow mw = (MainWindow)Window.GetWindow(this);
            mw.HelpScreen.Visibility = Visibility.Visible;
        }
    }
}
