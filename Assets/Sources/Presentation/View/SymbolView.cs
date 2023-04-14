using System;

namespace Assets.Sources.Presentation.View
{
    public class SymbolView
    {
        public void Draw(int left, int top, char symbol, ConsoleColor color)
        {
            if (left < 0 || left >= Console.WindowWidth)
                return;

            if (top < 0 || top >= Console.WindowHeight)
                return;
        
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = color;
            Console.Write(symbol);
        }
    }
}