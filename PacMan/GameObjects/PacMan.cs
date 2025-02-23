namespace PacMan.GameObjects
{
    internal class PacMan
    {
        bool _goup, _godown, _goleft, _goright;
        bool _noup, _nodown, _noleft, _noright;

        int _speed = 8;
        int _size = 30;
        Point _starPosition = new Point();

        PictureBox _pacman = new PictureBox();

        public Rectangle Bounds
        {
            get { return _pacman.Bounds; }
        }

        public PacMan(Form game, int imageBlock, Point position)
        {
            _starPosition.X = position.X * imageBlock - _size;
            _starPosition.Y = position.Y * imageBlock - _size;

            _pacman.Image = Properties.Resources.PackManLeft;
            _pacman.SizeMode = PictureBoxSizeMode.StretchImage;
            _pacman.Width = _pacman.Height = _size;
            _pacman.Left = _starPosition.X;
            _pacman.Top = _starPosition.Y;
            game.Controls.Add(_pacman);

        }

        public void SetStartPosition(Point position, int imageBlock)
        {
            _starPosition.X = position.X * imageBlock - _size;
            _starPosition.Y = position.Y * imageBlock - _size;
            _pacman.Left = _starPosition.X;
            _pacman.Top = _starPosition.Y;
        }

        public void UpdateDirection(Keys keyAction)
        {
            if (keyAction == Keys.Left && !_noleft)
            {
                ResetMovment();
                _goleft = true;
                _pacman.Image = Properties.Resources.PackManLeft;
            }

            if (keyAction == Keys.Right && !_noright)
            {
                ResetMovment();
                _goright = true;
                _pacman.Image = Properties.Resources.PackManRight;
            }

            if (keyAction == Keys.Up && !_noup)
            {
                ResetMovment();
                _goup = true;
                _pacman.Image = Properties.Resources.PackManUp;
            }

            if (keyAction == Keys.Down && !_nodown)
            {
                ResetMovment();
                _godown = true;
                _pacman.Image = Properties.Resources.PackManDown;
            }


        }

        public void ResetMovment()
        {
            _goleft = _goright = _godown = _goup = false;
            _noleft = _noright = _nodown = _noup = false;
        }

        public void CheckBoundaries(Rectangle wall)
        {
            if (_pacman.Bounds.IntersectsWith(wall))
            {
                if (_goleft)
                {
                    _noleft = true;
                    _goleft = false;
                    _pacman.Left = wall.Right + 2;
                }

                if (_goright)
                {
                    _noright = true;
                    _goright = false;
                    _pacman.Left = wall.Left - _pacman.Width - 2;
                }

                if (_goup)
                {
                    _noup = true;
                    _goup = false;
                    _pacman.Top = wall.Bottom + 2;
                }

                if (_godown)
                {
                    _nodown = true;
                    _godown = false;
                    _pacman.Top = wall.Top - _pacman.Height - 2;
                }
            }
        }

        public bool IntersectsWith(Rectangle bounds)
        {
           return _pacman.Bounds.IntersectsWith(bounds);
        }

        public void Movment(int maxWith, int maxHeight)
        {
            if (_goleft) { _pacman.Left -= _speed; }
            if (_goright) { _pacman.Left += _speed; }
            if (_goup) { _pacman.Top -= _speed; }
            if (_godown) { _pacman.Top += _speed; }

            if (_pacman.Left < -30)
                _pacman.Left = maxWith - _pacman.Width;

            if (_pacman.Left + _pacman.Width > maxWith)
                _pacman.Left = -10;

            if (_pacman.Top < -30)
                _pacman.Top = maxHeight - _pacman.Height;

            if (_pacman.Top + _pacman.Height > maxHeight)
                _pacman.Top = -10;


        }

        public void RestPacMan()
        {
            _pacman.Location = _starPosition;
            _pacman.Image = Properties.Resources.PackManLeft;
        }
    }
}
