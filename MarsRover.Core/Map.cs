using System.Collections.Generic;

namespace MarsRover.Core
{
    public class Map
    {
        public Map()
        {
            Rovers = new List<Rover>();
        }

        public List<Rover> Rovers { get; set; }

        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public int MinX { get; set; }
        public int MinY { get; set; }


    }
}