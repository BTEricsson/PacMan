using PacMan.GameObjects.Enums;

namespace PacMan
{
    public class Level
    {
        public int Number { get; private set; }
        public Point PacManStartPos { get; private set; }
        public LevelGhost RedGhost { get; private set; }
        public LevelGhost PinkGhost { get; private set; }
        public LevelGhost YellowGhost { get; private set; }
        public LevelGhost BlueGhost { get; private set; }

        public IList<Sketch> Sketchs;

        public Level(int number, Point pacMan, LevelGhost redGhost, LevelGhost yellowGhost, LevelGhost blueGhost, LevelGhost pinkGhost )
        {
            Number = number;
            PacManStartPos = pacMan;
            RedGhost = redGhost;
            PinkGhost = pinkGhost;
            YellowGhost = yellowGhost;
            BlueGhost = blueGhost;
            Sketchs = [];
        }
    }

    public class Sketch 
    {
        public SketchType Type { get; }
        public Point Position { get; }
        public int Units { get; }
        public string Direction { get; }
        public string Location { get; }
        public int LAdjust { get; }
        public int EAdjust { get; }

        public Sketch(SketchType type, Point position, int units, string direction, string location = "b", int lAdjust = 0, int eAdjust = 0)
        {
            Type = type;
            Position = position;
            Units = units;
            Direction = direction;
            Location = location;
            LAdjust = lAdjust;
            EAdjust = eAdjust;
        }
    }

    public class LevelGhost
    {
        public Point StartLocation { get; }
        public string StartDirection { get; }

        public LevelGhost(Point startLocation, string startDirection)
        {
            StartLocation = startLocation;
            StartDirection = startDirection;
        }
    
    }
}
