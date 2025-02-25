namespace Renderer
{
    internal class Settings
    {
        public class Rootobject
        {
            public Graphics Graphics { get; set; }
            public Controls Controls { get; set; }
        }

        public class Graphics
        {
            public int[] RenderResulution { get; set; }
            public float FPS { get; set; }
            public int[] WindowResulution { get; set; }
            public bool FullScreen { get; set; }
            public bool VSync { get; set; }
        }

        public class Controls
        {
            public string forward { get; set; }
            public string left { get; set; }
            public string backward { get; set; }
            public string right { get; set; }
        }

    }
}
