using QuickTools.QCore;
using QuickTools.QConsole;
using QuickTools.QColors;
using QuickTools.QData;
using QuickTools.QIO;
using QuickTools.QNet;
using QuickTools.QSecurity;
using QuickTools.QSecurity.FalseIO;
using QuickTools.QMath;
using System.Text;
using System;
using MultiTools.Tools.Explorer;
namespace MultiTools.Menu
{
    public class MainMenu
    {
        private string[] Args { get; set; }
        public void Start()
        {
            //Get.Wait("no args");
            string[] options = {"FileExplorer","Exit"};
            Options option = new Options(options);
            FileExplorer explorer = new FileExplorer();
            explorer.Run(); //
            switch (option.Pick())
            {
                case 0:
                    explorer.Run(); 
                    break;
                default:
                    Environment.Exit(0); 
                    break;
            }
            

        }
        public void Start(string[] args)
        {
            this.Args = args;
            
            //this.Start(); 
        }
    }
}
