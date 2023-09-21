using QuickTools.QCore;
using QuickTools.QConsole;
using QuickTools.QColors;
using QuickTools.QData;
using QuickTools.QIO;
using QuickTools.QNet;
using QuickTools.QSecurity;
using QuickTools.QSecurity.FalseIO;
using QuickTools.QMath;
using MultiTools.Menu;
namespace MultiTools.Init
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
   
            if(args.Length  > 1)
            {
                menu.Start(args); 
                return;
            }
            else
            {
                menu.Start();
                return; 
            }
        }
    }
}
