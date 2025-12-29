using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class LogoCasino
    {
        private int positionX = 55;
        private int positionX2 = 35;
        private int positionY = 25;
        private string logo = nameof(LoadingUI);

        public void StartUI()
        {
            Console.CursorVisible = false;
            LoadingUI();

        }
        private void LogoCSN()
        {
            string[] lines = new string[]
            {
"  ██████╗ █████╗ ███████╗██╗███╗   ██╗ ██████╗ ",
" ██╔════╝██╔══██╗██╔════╝██║████╗  ██║██╔═══██╗",
" ██║     ███████║███████╗██║██╔██╗ ██║██║   ██║",
" ██║     ██╔══██║╚════██║██║██║╚██╗██║██║   ██║",
" ╚██████╗██║  ██║███████║██║██║ ╚████║╚██████╔╝",
"  ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝╚═╝  ╚═══╝ ╚═════╝ ",
" ",
"           ★★★  CASINO ADMIRAL  ★★★        "
            };

            int startY = (Console.WindowHeight / 2) - (lines.Length / 2) - 2;
            int widthConsole = Console.WindowWidth;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int xStart = (widthConsole / 2) - (line.Length / 2);
                if (xStart < 0) xStart = 0;
                int y = startY + i;
                if (y < 0) y = 0;
                try
                {
                    Console.SetCursorPosition(xStart, y);
                    Console.WriteLine(line);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Error!!");
                }
            }




        }
        public void LoadingUI()
        {
            LogoCSN();
            CursorPositionLoadning();
            Thread.Sleep(500);
            Console.Write("[░░░░░░░░░░░░░░░░]   0%  ─⊙─  Booting Casino");

            Thread.Sleep(500);
            Console.Clear();

            LogoCSN();
            CursorPositionLoadning();
            Console.Write(" [██░░░░░░░░░░░░░░]  10%  ─⊙─  Initializing.....");

            Thread.Sleep(700);
            Console.Clear();

            LogoCSN();
            CursorPositionLoadning();
            Console.Write(" [████░░░░░░░░░░░░]  20%  ─⊙─  Loading fruits");

            Thread.Sleep(400);
            Console.Clear();

            LogoCSN();
            CursorPositionLoadning();
            Console.Write(" [██████░░░░░░░░░░]  30%  ─⊙─  Loading Coin");

            Thread.Sleep(400);
            Console.Clear();

            LogoCSN();
            CursorPositionLoadning();
            Console.Write(" [████████░░░░░░░░]  40%  ─⊙─  Starting system");

            Thread.Sleep(400);
            Console.Clear();

            LogoCSN();
            CursorPositionLoadning();
            Console.Write(" [██████████░░░░░░]  50%  ─⊙─  Launching services");

            Thread.Sleep(700);
            Console.Clear();

            LogoCSN();
            CursorPositionLoadning();
            Console.Write("  [████████████░░░░]  60%  ─⊙─  Connecting to network");

            Thread.Sleep(100);
            Console.Clear();

            LogoCSN();
            CursorPositionLoadning();
            Console.Write(" [██████████████░░]  70%  ─⊙─  Anticheat ready");

            Thread.Sleep(300);
            Console.Clear();

            LogoCSN();
            CursorPositionLoadning();
            Console.Write(" [████████████████]  80%  ─⊙─  Optimizing system");

            Thread.Sleep(300);
            Console.Clear();

            LogoCSN();
            CursorPositionLoadning();
            Console.Write(" [██████████████████░░]  90% ─⊙─  Preparing UI");

            Thread.Sleep(800);
            Console.Clear();

            LogoCSN();
            CursorPositionLoadning();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" [████████████████████] 100% ─⊙─  Casino ready!");
            Console.ForegroundColor = ConsoleColor.White;

            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.White;

        }

        private void CursorPositionLoadning()
        {

            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2;
            int y = centerY + 10;
            int x = Math.Max(0, centerX - 30);
            Console.SetCursorPosition(x, y);
        }

    }
}