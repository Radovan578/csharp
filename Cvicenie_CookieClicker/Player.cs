using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie_CookieClicker
{
    public class Player
    {
        public int Cookies { get; set; } = 10;
        public int Day { get; set; } = 0;
        public ConsoleKeyInfo PressedKey { get; set; }


    }
}