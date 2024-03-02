using System;
using System.IO;
using System.Windows.Forms;

namespace XAB
{
    internal static class Program
    {
        private static void Main()
        {
            using( Main main = new Main() )
            {
                main.Run();
            }
        }
    }
}