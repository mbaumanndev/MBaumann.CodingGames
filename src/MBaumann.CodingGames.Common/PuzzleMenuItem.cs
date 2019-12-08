using System;

namespace MBaumann.CodingGames.Common
{
    public sealed class PuzzleMenuItem : MenuItem
    {
        public PuzzleMenuItem(string p_Title, Action p_Action) : base(p_Title, p_Action)
        {
            Title = p_Title;
            Action = () =>
            {
                Console.WriteLine();
                p_Action.Invoke();
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
            };
        }
    }
}