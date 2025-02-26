using PacMan.GameObjects.Enums;


namespace PacMan.GameObjects
{
    public class Coin
    {
        int _size = 20;
        PictureBox _coin = new PictureBox();
        private Image imgCoin = Properties.Resources.BaseCoin;
        string type = SketchType.Coin.ToString();


        public Coin(Form gameboard, int units, Point position, string direction, int blockSize)
        {
            for (int i = 0; i < units; i++)
            {
                var row = direction == "r" ? position.X + i : position.X;
                var col = direction == "d" ? position.Y + i : position.Y;

                new Coin(gameboard, row, col, blockSize);
            }
        }

        public Coin(Form gameboard, int row, int col, int blockSize)
        {
            int xpos = row * blockSize - blockSize + (blockSize - _size) / 2;
            int ypos = col * blockSize - blockSize + (blockSize - _size) / 2;

            _coin.Image = imgCoin;
            _coin.SizeMode = PictureBoxSizeMode.StretchImage;
            _coin.Width = _coin.Height = _size;
            _coin.Left = xpos;
            _coin.Top = ypos;
            _coin.Tag = type;
            _coin.Visible = true;
            _coin.Enabled = true;

            gameboard.Controls.Add(_coin);
        }
    }
}
