using Newtonsoft.Json;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace Renderer
{
    internal class Program
    {
        internal static Settings.Rootobject? Settings { get; private set; }
        internal static int X { get; set; }

        internal static IWindow _window;
        internal static GL _gL;
        internal static uint _program;
        internal static uint _texture;

        internal static string _vertexShader;
        internal static string _fragmentShader;

        static void Main(string[] args)
        {
            string t = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Settings.json");

            Settings = JsonConvert.DeserializeObject<Settings.Rootobject>(File.ReadAllText(t));

            string shaderFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Shaders");
            _vertexShader = File.ReadAllText(Path.Combine(shaderFolder, "VertexShader.glsl"));
            _fragmentShader = File.ReadAllText(Path.Combine(shaderFolder, "FragmentShader.glsl"));

            WindowOptions options = WindowOptions.Default;
            options.Title = "SILK Test";
            options.Size = new Vector2D<int>(Settings.Graphics.WindowResulution[0], Settings.Graphics.WindowResulution[1]);
            options.VSync = false;
            _window = Window.Create(options);

            _window.Load += Load.Window_Load;
            _window.Update += Update.Window_Update;
            _window.Render += Render.Window_Render;
            _window.FramebufferResize += (Vector2D<int> obj) => { _gL.Viewport(obj); };

            _window.FocusChanged += Window_FocusChanged;

            _window.Run();
        }

        private static void Window_FocusChanged(bool obj)
        {
            _window.FramesPerSecond = obj switch
            {
                true => Settings.Graphics.FPS,
                false => 1.0f
            };
        }
    }
}