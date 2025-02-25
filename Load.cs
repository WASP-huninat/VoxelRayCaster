using Silk.NET.Input;
using Silk.NET.OpenGL;
using System.Drawing;

namespace Renderer
{
    internal class Load: Program
    {
        internal static void Window_Load()
        {
            #region Setup Input Logic
            IInputContext input = _window.CreateInput();
            new MouseLogic(input.Mice);
            new KeyboardLogic(input.Keyboards);
            #endregion

            _gL = _window.CreateOpenGL();

            _gL.ClearColor(Color.Gray);
            uint vshader = _gL.CreateShader(ShaderType.VertexShader);
            uint fshader = _gL.CreateShader(ShaderType.FragmentShader);

            _gL.ShaderSource(vshader, _vertexShader);
            _gL.ShaderSource(fshader, _fragmentShader);
            _gL.CompileShader(vshader);
            _gL.CompileShader(fshader);

            _program = _gL.CreateProgram();
            _gL.AttachShader(_program, vshader);
            _gL.AttachShader(_program, fshader);
            _gL.LinkProgram(_program);
            _gL.DetachShader(_program, vshader);
            _gL.DetachShader(_program, fshader);
            _gL.DeleteShader(vshader);
            _gL.DeleteShader(fshader);

            _gL.GetProgram(_program, GLEnum.LinkStatus, out var status);
            if (status == 0)
            {
                Console.WriteLine($"Error linking shader {_gL.GetProgramInfoLog(_program)}");
            }
        }
    }
}