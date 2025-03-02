using Pac_Man_V1.GameObjects.Enums;
using PacMan.GameObjects;
using PacMan.GameObjects.Enums;

namespace PacMan
{

    public partial class Form1 : Form
    {

        const int GameBlockWidth = 30;
        const int GameBlockHeight = 20;

        const int defaultLevel = 1;
        const int defaultLives = 3;


        const int _blockSize = 34;

        int score = 0;
        int coinCollected = 0;

        int level = defaultLevel;
        int lives = defaultLives;

        screenViewType ViewScreen = screenViewType.none;

        List<PictureBox> walls = new List<PictureBox>();
        List<PictureBox> coins = new List<PictureBox>();

        List<Score> Scores = new List<Score>();

        Game _games = new Game();

        GameObjects.PacMan pacMan;
        Ghost RedGhost, YellowGhost, BlueGhost, PinkGhost;
        List<Ghost> ghosts = new List<Ghost>();

        public Form1()
        {
            InitializeComponent();
            InitializeGameBoard();
            InitializeGhosts();
            InitializePackman();
            LoadGame(defaultLevel);
        }

        private void InitializeGameBoard()
        {
            this.Width = _blockSize * GameBlockWidth + 16;
            this.Height = _blockSize * GameBlockHeight + 16;

            int top = 40;
            var x = (this.Width - Pnl_MainMenu.Width) / 2;
            var y = ((this.Height - top) - Pnl_MainMenu.Height) / 2;

            Pnl_MainMenu.Location = new Point(x, y);

            LoadStartScreed();          
        }

        private void InitializePackman()
        {
            pacMan = new GameObjects.PacMan(this, _blockSize, new Point(15, 4));
        }

        private void InitializeGhosts()
        {
            RedGhost = new Ghost(this, GhostType.GhostRed, _blockSize, new Point(3, 3));
            ghosts.Add(RedGhost);

            YellowGhost = new Ghost(this, GhostType.GhostYellow, _blockSize, new Point(28, 3));
            ghosts.Add(YellowGhost);

            BlueGhost = new Ghost(this, GhostType.GhostBlue, _blockSize, new Point(3, 17));
            ghosts.Add(BlueGhost);

            PinkGhost = new Ghost(this, GhostType.GhostPink, _blockSize, new Point(28, 17));
            ghosts.Add(PinkGhost);
        }

        private void LoadGame(int level)
        {
            var GameLevel = _games.LoadLevel(level);

            pacMan.SetStartPosition(GameLevel.PacManStartPos, _blockSize);
            RedGhost.SetStartPosition(GameLevel.RedGhost.StartLocation, GameLevel.RedGhost.StartDirection ,_blockSize);
            YellowGhost.SetStartPosition(GameLevel.YellowGhost.StartLocation,GameLevel.YellowGhost.StartDirection ,_blockSize);
            BlueGhost.SetStartPosition(GameLevel.BlueGhost.StartLocation,GameLevel.BlueGhost.StartDirection, _blockSize);
            PinkGhost.SetStartPosition(GameLevel.PinkGhost.StartLocation,GameLevel.PinkGhost.StartDirection, _blockSize);



            foreach (Sketch prop in GameLevel.Sketchs)
            {
                if (prop.Type == SketchType.Wall)
                {
                    new Wall(this, _blockSize, prop);
                }

                if (prop.Type == SketchType.Coin)
                {
                    new Coin(this, prop.Units, prop.Position, prop.Direction, _blockSize);
                }
            }

            foreach (Control x in this.Controls)
            {
                if (x is not PictureBox)
                    continue;

                if (x.Tag == null)
                    continue;

                if ((string)x.Tag == SketchType.Wall.ToString())
                    walls.Add((PictureBox)x);

                if ((string)x.Tag == SketchType.Coin.ToString())
                    coins.Add((PictureBox)x);
            }
        }

        private void GameStartTimerEvent(object sender, EventArgs e)
        {
            pacMan.Movment(this.ClientSize.Width, this.ClientSize.Height);

            foreach (PictureBox wall in walls)
            {
                pacMan.CheckBoundaries(wall.Bounds);
            }

            foreach (PictureBox coin in coins)
            {
                CollectingCoins(coin);
            }

            if (coins.Count == coinCollected)
                LevelCompleteScreen();
            

            GhostsMovment();

            foreach (PictureBox wall in walls)
            {
                RedGhost.CheckBoundaries(wall.Bounds);
                YellowGhost.CheckBoundaries(wall.Bounds);
                BlueGhost.CheckBoundaries(wall.Bounds);
                PinkGhost.CheckBoundaries(wall.Bounds);
            }

            foreach (Ghost ghost in ghosts)
            {
                GhostCollison(ghost);
            }
        }

        private void GhostsMovment()
        {
            RedGhost.Movment(pacMan.Bounds);
            YellowGhost.Movment(pacMan.Bounds);
            BlueGhost.Movment(pacMan.Bounds);
            PinkGhost.Movment(pacMan.Bounds);
        }

        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            pacMan.UpdateDirection(e.KeyCode);
        }

        private void startGameClick(object sender, EventArgs e)
        {
            if (ViewScreen == screenViewType.start)
            {
                LoadStartScreed();
                return;
            }

            if (ViewScreen == screenViewType.score)
            {
                ScoreScreen();
                return;
            }




            Pnl_MainMenu.Enabled = false;
            Pnl_MainMenu.Visible = false;

            pacMan.RestPacMan();
            pacMan.ResetMovment();
            ResetGhostsLocation();
            GameTimer.Start();
        }

        private void ResetGhostsLocation()
        {
            RedGhost.ResetLocation();
            YellowGhost.ResetLocation();
            BlueGhost.ResetLocation();
            PinkGhost.ResetLocation();
        }

        private void CollectingCoins(PictureBox coin)
        {
            if (pacMan.IntersectsWith(coin.Bounds))
            {
                if (coin.Visible)
                {
                    coin.Visible = false;
                    score += 1;
                    coinCollected += 1;
                }
            }
        }

        private void GhostCollison(Ghost ghost)
        {
            if (!pacMan.IntersectsWith(ghost.Bounds))
                return;

            lives--;

            if (lives > 0)
            {
                DiedScreen();
                return;
            }

            GameOverScreen();
        }

        private void ClearGame()
        {
            foreach (PictureBox wall in walls)
            {
                this.Controls.Remove(wall);
            }

            foreach (PictureBox coin in coins)
            {
                this.Controls.Remove(coin);
            }

            walls.Clear();
            coins.Clear();
        }

        private void LoadStartScreed()
        {
            lbl_score_info.Text = $"...::: PACMAN :::...{Environment.NewLine}{Environment.NewLine}UP / DOWN / LEFT / RIGHT";
            btn_Play.Text = "Play";
            ViewScreen = screenViewType.none;
            Pnl_MainMenu.Enabled = true;
            Pnl_MainMenu.Visible = true;
        }

        private void LevelCompleteScreen()
        {
            GameTimer.Stop();
            lbl_score_info.Text = $"..::: YOU WIN :::..{Environment.NewLine}{Environment.NewLine}LEVEL: {level} SCORE: {score}";

            level++;

            ClearGame();

            int loadLevel = level <= _games.levels ? level : new Random().Next(1, _games.levels);
            
            coinCollected = 0;
            LoadGame(loadLevel);

            btn_Play.Text = "Go";
            Pnl_MainMenu.Visible = true;
            Pnl_MainMenu.Enabled = true;
        }

        public void DiedScreen()
        {
            GameTimer.Stop();

            lbl_score_info.Text = $"..::: YOU DIED :::..{Environment.NewLine}{Environment.NewLine} LIVES: {lives}";

            btn_Play.Text = "Go";

            Pnl_MainMenu.Visible = true;
            Pnl_MainMenu.Enabled = true;

        }

        private void GameOverScreen()
        {
            GameTimer.Stop();
            setMyScore(level, score);

            lbl_score_info.Text = $"..::: GAME OVER :::..{Environment.NewLine}{Environment.NewLine}SCORE: {score} LEVEL: {level}";

            

            score = 0;
            coinCollected = 0;
            lives = defaultLives;
            level = defaultLevel;

            ClearGame();
            LoadGame(level);
            btn_Play.Text = "Score";
            ViewScreen = screenViewType.score;

            Pnl_MainMenu.Visible = true;
            Pnl_MainMenu.Enabled = true;

        }

        private void ScoreScreen()
        { 
            string Screen = $"..::: SCORE :::..{Environment.NewLine}";

            var topScores = Scores.OrderByDescending(S => S.score).Take(3);

            foreach (Score score in topScores)
            {
                var ThisScore = score.thisScore ? "* " : "  ";
                Screen += $"{ThisScore}{score.score} {score.level}{Environment.NewLine}";                
            }
            lbl_score_info.Text = Screen;

            btn_Play.Text = "Reset";
            ViewScreen = screenViewType.start;

            Pnl_MainMenu.Visible = true;
            Pnl_MainMenu.Enabled = true;
        }

        private void setMyScore(int level, int score)
        {
            clearScore();
            var newScore = new Score() { level = level, score = score, thisScore = true  };
            Scores.Add(newScore);
        }

        private void clearScore()
        {
            foreach (Score score in Scores)
            {
                score.thisScore = false;
            }
        
        }
    }
}



