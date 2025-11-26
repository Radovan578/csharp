using System.Security.Cryptography.X509Certificates;
using Cvicenie_SIMS;

namespace Cvicenie_SIMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SIMGame game = new SIMGame();
            game.StartGame();
        }
    }
}