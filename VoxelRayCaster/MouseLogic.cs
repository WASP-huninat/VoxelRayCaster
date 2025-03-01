using Silk.NET.Input;
using System.Numerics;

namespace Renderer
{
    internal class MouseLogic
    {
        private Vector2 _position = new Vector2(0, 0);

        public MouseLogic(IReadOnlyList<IMouse> mices)
        {
            foreach (IMouse mouse in mices)
            {
                mouse.Click += Mouse_Click;
                mouse.MouseMove += Mouse_MouseMove;
            }
        }

        private void Mouse_MouseMove(IMouse arg1, System.Numerics.Vector2 arg2)
        {
            var t = _position.X - arg2.X;

            if (t > _position.X)
            {
                
            }
        }

        internal static void Mouse_Click(IMouse arg1, MouseButton arg2, System.Numerics.Vector2 arg3)
        {
            Console.WriteLine("Window Clicked");
        }
    }
}
