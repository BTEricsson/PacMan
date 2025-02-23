namespace PacMan.GameObjects
{
    public enum GhostType
    {
        GhostRed = 10,
        GhostBlue = 20,
        GhostYellow = 30,
        GhostPink = 40
    }

    internal class Ghost
    {
        int _speed = 6;
        int _seekSpeed = 3;
        int _moveCount;
        int _maxHeight;
        int _maxWidth;
        int _minHeight;
        int _minWidth;

        int _size = 30;
        int _offset = 5;

        bool _outOfBounds;

        string[] _directions = { "left", "right", "up", "down", "seek"};
        string _direction = "left";

        Random random = new Random();
        Point _starPosition = new Point();
        PictureBox _ghost = new PictureBox();

        public Rectangle Bounds
        {
            get { return _ghost.Bounds; }
        }

        public Ghost(Form gameboard, GhostType ghostType, int blockSize, Point position)
        {
            _maxHeight = gameboard.Height - _size - _speed;
            _maxWidth = gameboard.Width - _size - _speed;
            _minHeight = _speed;
            _minWidth = _speed;

            _starPosition.X = position.X * blockSize - _size;
            _starPosition.Y = position.Y * blockSize - _size;

            _ghost.Image = GetImage(ghostType);
            _ghost.SizeMode = PictureBoxSizeMode.StretchImage;
            _ghost.Width = _ghost.Height = _size;
            _ghost.Left = _starPosition.X;
            _ghost.Top = _starPosition.Y;
            
            gameboard.Controls.Add(_ghost);
        }

        private Image GetImage(GhostType GhostType)
        {
            if (GhostType == GhostType.GhostRed)
                return Properties.Resources.RedGhost;

            if (GhostType == GhostType.GhostBlue)
                return Properties.Resources.BlueGhost;

            if (GhostType == GhostType.GhostYellow)
                return Properties.Resources.YellowGhost;

            if (GhostType == GhostType.GhostPink)
                return Properties.Resources.PinkGhost;


            return Properties.Resources.WhiteGhost;
        }

        public void SetStartPosition(Point position, int blockSize)
        {
            _starPosition.X = position.X * blockSize - _size;
            _starPosition.Y = position.Y * blockSize - _size;

            _ghost.Left = _starPosition.X;
            _ghost.Top = _starPosition.Y;

        }

        public void Movment(Rectangle pacman)
        {
            if (_moveCount > 0)
                _moveCount--;
            else
            {
                _moveCount = random.Next(50, 60);
                int _prevSeek = _direction != "seek"? 0 : 1;
                _direction =  _directions[random.Next(_directions.Length - _prevSeek)];
            }

            DirectionMovment();
            DirectionMovmentSeek(pacman);

            _outOfBounds = SwitchDirectionOutOfBounds();
        }
        
        public void CheckBoundaries(Rectangle wall)
        {
            Rectangle bounds = _ghost.Bounds;
            bounds.Location = new Point(bounds.X - _offset, bounds.Y - _offset);
            bounds.Height = bounds.Height + _offset;
            bounds.Width = bounds.Width + _offset;

            if (_direction == "seek" && bounds.IntersectsWith(wall))
                _moveCount += _moveCount < 2 ?  0 : 1;

            if (_outOfBounds || _direction == "seek" || !bounds.IntersectsWith(wall))
            {
                return;
            }

            SwitchDirection();
            DirectionMovment();
        }

        private void SwitchDirection()
        {
            switch (_direction)
            {
                case "right":
                    _direction = "left";
                    break;
                case "left":
                    _direction = "right";
                    break;
                case "up":
                    _direction = "down";
                    break;
                case "down":
                    _direction = "up";
                    break;
            }
        }

        private bool SwitchDirectionOutOfBounds()
        {
            var startDirection = _direction;

            if (_ghost.Left < _minWidth)
                _direction = "right";

            if (_ghost.Left + _ghost.Width > _maxWidth)
                _direction = "left";

            if (_ghost.Top < _minHeight)
                _direction = "down";

            if (_ghost.Top + _ghost.Height > _maxHeight)
                _direction = "up";

            return startDirection != _direction;
        }

        private void DirectionMovment()
        {
            switch (_direction)
            {
                case "left":
                    _ghost.Left -= _speed;
                    break;
                case "right":
                    _ghost.Left += _speed;
                    break;
                case "up":
                    _ghost.Top -= _speed;
                    break;
                case "down":
                    _ghost.Top += _speed;
                    break;
            }
        }

        private void DirectionMovmentSeek(Rectangle pacman)
        {
            if (_direction != "seek")
                return;

            if (_ghost.Left > pacman.Left)
            {
                _ghost.Left -= _seekSpeed;
            }

            if (_ghost.Left < pacman.Left)
            {
                _ghost.Left += _seekSpeed;
            }

            if (_ghost.Top > pacman.Top)
            {
                _ghost.Top -= _seekSpeed;
            }

            if (_ghost.Top < pacman.Top)
            {
                _ghost.Top += _seekSpeed;
            }
        }

        public void ResetLocation()
        {
            _ghost.Left = _starPosition.X;
            _ghost.Top = _starPosition.Y;
        }
    }
}
