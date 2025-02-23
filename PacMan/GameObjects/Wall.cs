using PacMan.GameObjects.Enums;

namespace PacMan.GameObjects
{
    internal class Wall
    {
        int _size = 16;

        PictureBox _wall = new PictureBox();
        Image _imgWall = Properties.Resources.Block;


        public Wall(Form gameboard,int blockSize, Sketch sketch)
        {

            int with = _size;
            int height = _size;
            
            int left = sketch.Position.X * blockSize - blockSize;
            int top = sketch.Position.Y * blockSize - blockSize;
            
            int calcAdjust = 0;
            int calcAdjustB = (blockSize - _size) / 2;
            int LengthAdjust = sketch.Units * blockSize + sketch.LAdjust * calcAdjustB + sketch.EAdjust * calcAdjustB;



            if (sketch.Location == "e")
                calcAdjust = blockSize - _size;

            if (sketch.Location == "c")
                calcAdjust = (blockSize - _size) / 2;


            if (sketch.Direction == "r")
            {
                top += calcAdjust;
                left -= sketch.LAdjust * calcAdjustB;
                with =  LengthAdjust;
            }

            if (sketch.Direction == "d")
            {
                top -=  sketch.LAdjust * calcAdjustB;
                left +=  calcAdjust;
                height =  LengthAdjust;
            }



            _wall.Image = _imgWall;
            _wall.SizeMode = PictureBoxSizeMode.StretchImage;

            _wall.Width = with;
            _wall.Height = height;

            _wall.Left = left;
            _wall.Top = top; 
            _wall.Tag = SketchType.Wall.ToString();
            _wall.Visible = true;
            _wall.Enabled = true;
            _wall.BackColor = Color.Black;


            gameboard.Controls.Add(_wall);
        }
         
    }
}
