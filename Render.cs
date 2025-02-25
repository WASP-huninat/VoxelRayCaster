using Silk.NET.OpenGL;

namespace Renderer
{
    internal class Render : Program
    {
        internal static unsafe void Window_Render(double obj)
        {
            //Open GL
            DateTime start = DateTime.Now;

            _gL.Clear(ClearBufferMask.ColorBufferBit);

            uint vao = _gL.GenVertexArray();
            _gL.BindVertexArray(vao);

            uint vertices = _gL.GenBuffer();
            uint indices = _gL.GenBuffer();

            float stepX = 2.0f / Settings.Graphics.RenderResulution[0];
            float stepY = 2.0f / Settings.Graphics.RenderResulution[1];
            float z = 0.0f;

            float[] color = new float[]
            {
                1.0f, 0.0f, 0.0f, 0.0f,
                0.0f, 1.0f, 0.0f, 0.0f,
                0.0f, 0.0f, 1.0f, 0.0f
            };

            int c = 0;

            List<float> vertexDataList = new List<float>();

            for (float y = 1.0f; y >= -0.8f; y -= stepY)
            {
                for (float x = -1.0f; x <= 0.8f; x += stepX)
                {
                    vertexDataList.AddRange([x, y, z, color[c], color[c + 1], color[c + 2], color[c + 3]]);
                    vertexDataList.AddRange([x + stepX, y, z, color[c], color[c + 1], color[c + 2], color[c + 3]]);
                    vertexDataList.AddRange([x, y - stepY, z, color[c], color[c + 1], color[c + 2], color[c + 3]]);
                    vertexDataList.AddRange([x + stepX, y - stepY, z, color[c], color[c + 1], color[c + 2], color[c + 3]]);

                    c += 4;
                    if (c >= color.Length - 1)
                    {
                        y = -1.0f;
                        x = 1.0f;
                    }
                }
            }

            uint[] indexArray = new uint[]
            {
                0, 1, 2, 1, 2, 3,
                4, 5, 6, 5, 6, 7,
                8, 9, 10, 9, 10, 11
            };

            _gL.BindBuffer(GLEnum.ArrayBuffer, vertices);
            _gL.BufferData(GLEnum.ArrayBuffer, (ReadOnlySpan<float>)vertexDataList.ToArray().AsSpan(), GLEnum.StaticDraw);
            _gL.VertexAttribPointer(0, 3, GLEnum.Float, false, 7 * sizeof(float), null);
            _gL.EnableVertexAttribArray(0);
            _gL.VertexAttribPointer(1, 4, GLEnum.Float, false, 7 * sizeof(float), 3 * sizeof(float));
            _gL.EnableVertexAttribArray(1);

            _gL.BindBuffer(GLEnum.ElementArrayBuffer, indices);
            _gL.BufferData(GLEnum.ElementArrayBuffer, (ReadOnlySpan<uint>)indexArray.AsSpan(), GLEnum.StaticDraw);

            _gL.BindBuffer(GLEnum.ArrayBuffer, 0);
            _gL.UseProgram(_program);
            _gL.DrawElements(GLEnum.Triangles, (uint)indexArray.Length, GLEnum.UnsignedInt, null);
            _gL.BindBuffer(GLEnum.ElementArrayBuffer, 0);
            _gL.BindVertexArray(vao);

            _gL.DeleteBuffer(vertices);
            _gL.DeleteBuffer(indices);
            _gL.DeleteVertexArray(vao);

            if (X != 0)
            {
                Console.WriteLine("Test");
            }

            Console.WriteLine($"RenderTime: {DateTime.Now - start}");
        }
    }
}