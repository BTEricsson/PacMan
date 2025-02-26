using PacMan.GameObjects.Enums;

namespace PacMan
{
    public class Game
    {
        private IList<Level> _levels = new List<Level>();

        public int levels { get {return _levels.Count(); } }

        public Game()
        {
            _levels.Add(FirstLevel());
            _levels.Add(SecundLevel());
            _levels.Add(thirdLevel());
        }

        public Level LoadLevel(int level)
        {
            return _levels.FirstOrDefault(L => L.Number == level);
        }

        private Level FirstLevel()
        {
            LevelGhost Red = new LevelGhost(new Point(2, 2), "right");
            LevelGhost Yellow = new LevelGhost(new Point(29, 2), "up");
            LevelGhost Blue = new LevelGhost(new Point(2, 18), "down");
            LevelGhost Pink = new LevelGhost(new Point(29, 18), "left");

            Level level = new Level(1, new Point(15,10), Red,Yellow,Blue,Pink);
            List<Sketch> levelLayout = new List<Sketch>();

            // Walls
            var wallSketchs = new List<Sketch>();
            #region Walls
            //top coner Left
            wallSketchs.AddRange(WallUppCornerLeft(new Point(1, 1), 12, 6));

            //bottom Coner Left
            wallSketchs.AddRange(WallDownCornerLeft(new Point(1, 13), 6, 12));

            // top coner right
            wallSketchs.AddRange(WallUppCornerRight(new Point(19, 1), 12, 6));

            // bottom coner right
            wallSketchs.AddRange(WallDownCornerRight(new Point(30, 13), 12, 6));

            //coner Left top inner
            wallSketchs.AddRange(WallUppCornerLeft(new Point(3, 3), 4, 3));

            //Coner Left bottom inner 
            wallSketchs.AddRange(WallDownCornerLeft(new Point(3, 14), 3, 4));

            //coner right top inner
            wallSketchs.AddRange(WallUppCornerRight(new Point(25, 3), 4, 3));

            //coner right bottom inner
            wallSketchs.AddRange(WallDownCornerRight(new Point(28, 14), 4, 3));

            #endregion
            levelLayout.AddRange(wallSketchs);

            // Coins 
            var coinSketchs = new List<Sketch>();
            #region Coins
            // top left Corner
            coinSketchs.AddRange(CoinsUpperLeftCorner(new Point(2, 2), 11, 5));
            // bottom left corner
            coinSketchs.AddRange(CoinsDownLeftCorner(new Point(2, 13), 11, 5));
            // top right corner
            coinSketchs.AddRange(CoinsUpperRightCorner(new Point(19, 2), 11, 5));

            coinSketchs.AddRange(CoinsDownRightCorner(new Point(29, 13), 11, 5));


            coinSketchs.AddRange(CoinsUpperLeftCorner(new Point(4, 4), 3, 2));
            // bottom left corner
            coinSketchs.AddRange(CoinsDownLeftCorner(new Point(4, 14), 3, 2));
            // top right corner
            coinSketchs.AddRange(CoinsUpperRightCorner(new Point(25, 4), 3, 2));

            coinSketchs.AddRange(CoinsDownRightCorner(new Point(27, 14), 3, 2));

            coinSketchs.AddRange(Coinshorizontal(new Point(12,7),8));
            coinSketchs.AddRange(CoinsVertical(new Point(12, 8), 4));
            coinSketchs.AddRange(CoinsVertical(new Point(19, 8), 4));
            coinSketchs.AddRange(Coinshorizontal(new Point(12, 12), 8));


            #endregion
            levelLayout.AddRange(coinSketchs);

            level.Sketchs = levelLayout;
            return level;
        }

        private Level SecundLevel()
        {
            LevelGhost Red = new LevelGhost(new Point(2, 2), "right");
            LevelGhost Yellow = new LevelGhost(new Point(29, 2), "up");
            LevelGhost Blue = new LevelGhost(new Point(2, 18), "down");
            LevelGhost Pink = new LevelGhost(new Point(29, 18), "left");

            Level level = new Level(2, new Point(15, 10), Red, Yellow, Blue, Pink);
            List<Sketch> levelLayout = new List<Sketch>();

            // Walls
            var wallSketchs = new List<Sketch>();
            #region Walls
            //top coner Left
            wallSketchs.AddRange(WallUppCornerLeft(new Point(1, 1), 12, 6));

            //bottom Coner Left
            wallSketchs.AddRange(WallDownCornerLeft(new Point(1, 13), 6, 12));

            // top coner right
            wallSketchs.AddRange(WallUppCornerRight(new Point(19, 1), 12, 6));

            // bottom coner right
            wallSketchs.AddRange(WallDownCornerRight(new Point(30, 13), 12, 6));


            //coner Left top inner
            wallSketchs.AddRange(WallUppCornerLeft(new Point(3, 3), 4, 3));

            //Coner Left bottom inner 
            wallSketchs.AddRange(WallDownCornerLeft(new Point(3, 14), 3, 4));

            //coner right top inner
            wallSketchs.AddRange(WallUppCornerRight(new Point(25, 3), 4, 3));

            //coner right bottom inner
            wallSketchs.AddRange(WallDownCornerRight(new Point(28, 14), 4, 3));


            // walls
            wallSketchs.AddRange(Wallhorizontal(new Point(12, 4), 8));

            wallSketchs.AddRange(Wallhorizontal(new Point(12, 16), 8));
            #endregion
            levelLayout.AddRange(wallSketchs);

            // Coins 
            var coinSketchs = new List<Sketch>();
            #region Coins
            // top left Corner
            coinSketchs.AddRange(CoinsUpperLeftCorner(new Point(2, 2), 11, 5));
            // bottom left corner
            coinSketchs.AddRange(CoinsDownLeftCorner(new Point(2, 13), 11, 5));
            // top right corner
            coinSketchs.AddRange(CoinsUpperRightCorner(new Point(19, 2), 11, 5));

            coinSketchs.AddRange(CoinsDownRightCorner(new Point(29, 13), 11, 5));


            coinSketchs.AddRange(CoinsUpperLeftCorner(new Point(4, 4), 3, 2));
            // bottom left corner
            coinSketchs.AddRange(CoinsDownLeftCorner(new Point(4, 14), 3, 2));
            // top right corner
            coinSketchs.AddRange(CoinsUpperRightCorner(new Point(25, 4), 3, 2));

            coinSketchs.AddRange(CoinsDownRightCorner(new Point(27, 14), 3, 2));

            coinSketchs.AddRange(Coinshorizontal(new Point(12, 5), 8));
            coinSketchs.AddRange(Coinshorizontal(new Point(12, 15), 8));


            #endregion
            levelLayout.AddRange(coinSketchs);

            level.Sketchs = levelLayout;
            return level;
        }

        private Level thirdLevel()
        {
            LevelGhost Red = new LevelGhost(new Point(2, 2), "right");
            LevelGhost Yellow = new LevelGhost(new Point(29, 2), "up");
            LevelGhost Blue = new LevelGhost(new Point(2, 18), "down");
            LevelGhost Pink = new LevelGhost(new Point(29, 18), "left");

            Level level = new Level(3, new Point(15, 10), Red, Yellow, Blue, Pink);
            List<Sketch> levelLayout = new List<Sketch>();

            // Walls
            var wallSketchs = new List<Sketch>();
            #region Walls
            //top coner Left
            wallSketchs.AddRange(WallUppCornerLeft(new Point(1, 1), 12, 6));

            //bottom Coner Left
            wallSketchs.AddRange(WallDownCornerLeft(new Point(1, 13), 6, 12));

            // top coner right
            wallSketchs.AddRange(WallUppCornerRight(new Point(19, 1), 12, 6));

            // bottom coner right
            wallSketchs.AddRange(WallDownCornerRight(new Point(30, 13), 12, 6));


            //coner Left top inner
            wallSketchs.AddRange(WallUppCornerLeft(new Point(3, 3), 4, 3));

            //Coner Left bottom inner 
            wallSketchs.AddRange(WallDownCornerLeft(new Point(3, 14), 3, 4));

            //coner right top inner
            wallSketchs.AddRange(WallUppCornerRight(new Point(25, 3), 4, 3));

            //coner right bottom inner
            wallSketchs.AddRange(WallDownCornerRight(new Point(28, 14), 4, 3));


            // walls
            wallSketchs.AddRange(Wallhorizontal(new Point(12, 4), 8));

            wallSketchs.AddRange(Wallhorizontal(new Point(12, 16), 8));



            wallSketchs.AddRange(Wallhorizontal(new Point(12, 7), 8, true));
            wallSketchs.AddRange(WallVertical(new Point(12, 8), 4,true));
            wallSketchs.AddRange(WallVertical(new Point(19, 8), 4,true));
            
            #endregion
            levelLayout.AddRange(wallSketchs);

            // Coins 
            var coinSketchs = new List<Sketch>();
            #region Coins
            // top left Corner
            coinSketchs.AddRange(CoinsUpperLeftCorner(new Point(2, 2), 11, 5));
            // bottom left corner
            coinSketchs.AddRange(CoinsDownLeftCorner(new Point(2, 13), 11, 5));
            // top right corner
            coinSketchs.AddRange(CoinsUpperRightCorner(new Point(19, 2), 11, 5));

            coinSketchs.AddRange(CoinsDownRightCorner(new Point(29, 13), 11, 5));


            coinSketchs.AddRange(CoinsUpperLeftCorner(new Point(4, 4), 3, 2));
            // bottom left corner
            coinSketchs.AddRange(CoinsDownLeftCorner(new Point(4, 14), 3, 2));
            // top right corner
            coinSketchs.AddRange(CoinsUpperRightCorner(new Point(25, 4), 3, 2));

            coinSketchs.AddRange(CoinsDownRightCorner(new Point(27, 14), 3, 2));



            coinSketchs.AddRange(Coinshorizontal(new Point(12, 5), 8));
            coinSketchs.AddRange(Coinshorizontal(new Point(12, 15), 8));


            coinSketchs.AddRange(Coinshorizontal(new Point(13, 8), 6));
            coinSketchs.AddRange(CoinsVertical(new Point(13, 8), 4));
            coinSketchs.AddRange(CoinsVertical(new Point(18, 8), 4));

            #endregion
            levelLayout.AddRange(coinSketchs);

            level.Sketchs = levelLayout;
            return level;
        }


        #region Base Coins sketchs
        private List<Sketch> Coinshorizontal(Point startPoint, int coins)
        {
            var sketchs = new List<Sketch>();
            sketchs.Add(new Sketch(SketchType.Coin, startPoint, coins, "r"));
            return sketchs;
        }

        private List<Sketch> CoinsVertical(Point startPoint, int coins)
        {
            var sketchs = new List<Sketch>();
            sketchs.Add(new Sketch(SketchType.Coin, startPoint, coins, "d"));
            return sketchs;
        }

        private List<Sketch> CoinsUpperLeftCorner(Point startPoint, int coinsTop,int CoinsLeft)
        {
            Point nextPoint = startPoint;
            nextPoint.Y += 1;

            var sketchs = new List<Sketch>();
            sketchs.Add(new Sketch(SketchType.Coin, startPoint, coinsTop, "r"));
            sketchs.Add(new Sketch(SketchType.Coin, nextPoint, CoinsLeft, "d"));
            return sketchs;
        }

        private List<Sketch> CoinsDownLeftCorner(Point startPoint, int coinsBottom, int CoinsLeft)
        {
            Point nextPoint = startPoint;
            nextPoint.Y += CoinsLeft;

            var sketchs = new List<Sketch>();
            sketchs.Add(new Sketch(SketchType.Coin, startPoint, CoinsLeft, "d"));
            sketchs.Add(new Sketch(SketchType.Coin, nextPoint, coinsBottom, "r"));
            return sketchs;
        }

        private List<Sketch> CoinsUpperRightCorner(Point startPoint, int coinsTop, int CoinsRight)
        {
            Point nextPoint = startPoint;
            nextPoint.Y += 1;
            nextPoint.X += coinsTop - 1;

            var sketchs = new List<Sketch>();
            sketchs.Add(new Sketch(SketchType.Coin, startPoint, coinsTop, "r"));
            sketchs.Add(new Sketch(SketchType.Coin, nextPoint, CoinsRight, "d"));
            return sketchs;
        }
        private List<Sketch> CoinsDownRightCorner(Point startPoint, int coinsBottom, int CoinsRight)
        {
            Point nextPoint = startPoint;
            nextPoint.Y += CoinsRight;
            nextPoint.X -= coinsBottom - 1;

            var sketchs = new List<Sketch>();
            sketchs.Add(new Sketch(SketchType.Coin, startPoint, CoinsRight, "d"));
            sketchs.Add(new Sketch(SketchType.Coin, nextPoint, coinsBottom, "r"));
            return sketchs;
        }
        #endregion


        #region Base Wall sketchs
        private List<Sketch> Wallhorizontal(Point startPoint, int bolcks, bool endAdjust = false)
        {
            

            var sketchs = new List<Sketch>();
            if(endAdjust)
                sketchs.Add(new Sketch(SketchType.Wall, startPoint, bolcks, "r", "c", -1, -1));
            else
                sketchs.Add(new Sketch(SketchType.Wall, startPoint, bolcks, "r", "c", 0, 0));
            
            return sketchs;
        }



        private List<Sketch> WallVertical(Point startPoint, int bolcks, bool topAdjust = false)
        {
            var sketchs = new List<Sketch>();
            if(topAdjust)
                sketchs.Add(new Sketch(SketchType.Wall, startPoint, bolcks, "d", "c", 1, 0));
            else
                sketchs.Add(new Sketch(SketchType.Wall, startPoint, bolcks, "d", "c", 0, 0));
            return sketchs;
        }

        private List<Sketch> WallUppCornerLeft(Point startpoint, int TopBlocks, int LeftBlocks) 
        {
            Point nextPoint = startpoint;
            nextPoint.Y += 1; 
            var sketchs = new List<Sketch>();
            sketchs.Add(new Sketch(SketchType.Wall, startpoint , TopBlocks, "r", "c", -1, 0));
            sketchs.Add(new Sketch(SketchType.Wall, nextPoint, LeftBlocks, "d", "c", 1, 0));
            return sketchs;
        }

        private List<Sketch> WallDownCornerLeft(Point startpoint, int BotomBlocks, int LeftBlocks)
        {
            Point nextPoint = startpoint;
            nextPoint.Y += BotomBlocks;
            var sketchs = new List<Sketch>();
            sketchs.Add(new Sketch(SketchType.Wall, startpoint, BotomBlocks, "d", "c", 0, 1));
            sketchs.Add(new Sketch(SketchType.Wall, nextPoint, LeftBlocks, "r", "c", -1, 0));
            return sketchs;
        }

        private List<Sketch> WallUppCornerRight(Point startpoint, int TopBlocks, int RightBlocks)
        {
            Point nextPoint = startpoint;
            nextPoint.Y += 1;
            nextPoint.X += TopBlocks - 1;
            var sketchs = new List<Sketch>();
            sketchs.Add(new Sketch(SketchType.Wall, startpoint, TopBlocks, "r", "c", 0, -1));
            sketchs.Add(new Sketch(SketchType.Wall, nextPoint, RightBlocks, "d", "c", 1, 0));
            return sketchs;
        }

        private List<Sketch> WallDownCornerRight(Point startpoint, int BottomBlocks, int RithBlocks)
        {
            Point nextPoint = startpoint;
            nextPoint.Y += RithBlocks;
            nextPoint.X -= BottomBlocks - 1;
            var sketchs = new List<Sketch>();
            sketchs.Add(new Sketch(SketchType.Wall, startpoint, RithBlocks, "d", "c", 0, 1));
            sketchs.Add(new Sketch(SketchType.Wall, nextPoint, BottomBlocks, "r", "c", 0, -1));
            return sketchs;
        }

        #endregion


    }
}
