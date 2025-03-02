namespace RayCaster
{
    internal class PlayerJSON
    {
        public class Rootobject
        {
            public Position Position { get; set; }
            public Camera Camera { get; set; }
        }

        public class Position
        {
            public int x { get; set; }
            public int y { get; set; }
            public int z { get; set; }
        }

        public class Camera
        {
            public int rotation { get; set; }
            public int pitch { get; set; }
        }
    }
}
