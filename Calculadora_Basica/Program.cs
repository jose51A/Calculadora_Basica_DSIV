using System;
using System.Windows.Forms;

namespace CalculadoraBasica
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize(); // .NET 6/7/8 style
            Application.Run(new CalculatorForm());
        }
    }
}