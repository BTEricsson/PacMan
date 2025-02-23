using PacMan.GameObjects.Enums;

namespace PacMan
{
    public class Level
    {
        public int Number { get; private set; }
        public Point PacManStartPos { get; private set; }
        public Point RedGhostStartPos { get; private set; }
        public Point PinkGhostStartPos { get; private set; }
        public Point YellowGhostStartPos { get; private set; }
        public Point BlueGhostStartPos { get; private set; }

        public IList<Sketch> Sketchs;

        public Level(int number, Point pacMan, Point redGhost, Point yellowGhost, Point blueGhost, Point pinkGhost )
        {
            Number = number;
            PacManStartPos = pacMan;
            RedGhostStartPos = redGhost;
            PinkGhostStartPos = pinkGhost;
            YellowGhostStartPos = yellowGhost;
            BlueGhostStartPos = blueGhost;
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

        public Sketch(SketchType Type, Point position, int units, string direction, string location = "b", int lAdjust = 0, int eAdjust = 0)
        {
            this.Type = Type;
            Position = position;
            Units = units;
            Direction = direction;
            Location = location;
            LAdjust = lAdjust;
            EAdjust = eAdjust;
        }
    }    
}
