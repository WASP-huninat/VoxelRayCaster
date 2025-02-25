using Silk.NET.Input;

namespace Renderer
{
    internal class KeyboardLogic
    {
        internal KeyboardLogic(IReadOnlyList<IKeyboard> keyboards)
        {
            foreach (IKeyboard keyboard in keyboards)
            {
                keyboard.KeyDown += KeyboardLogic.Keyboard_KeyDown;
            }
        }

        internal static void Keyboard_KeyDown(IKeyboard arg1, Key arg2, int arg3)
        {
            throw new NotImplementedException();
        }
    }
}