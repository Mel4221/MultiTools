using QuickTools.QCore;
using QuickTools.QConsole;
using QuickTools.QColors;
using QuickTools.QData;
using QuickTools.QIO;
using QuickTools.QNet;
using QuickTools.QSecurity;
using QuickTools.QSecurity.FalseIO;
using QuickTools.QMath;
using System;
using System.IO;
using System.Collections.Generic;

namespace MultiTools.Tools.Explorer
{
    public class FileExplorer
    {
        public FileExplorer()
        {
            this.LoadItems();
        }


        /// <summary>
        /// by default is set to the desktop
        /// </summary>
        public string Path { get; set; } = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{Get.Slash()}";
        public int MaxHeigh { get; set; } = Console.BufferHeight -4;
        public int MaxWidth { get; set; } = Console.BufferWidth - 4;
        private int CurrentSelection = 0;
        private int Indexer = 0;
        private List<string> Items { get; set; } = new List<string>();  
        private void DirectionHandeler()
        {
            /*
             RightArrow  0
LeftArrow  0
DownArrow  0
UpArrow  0
scape
             */
            ConsoleKeyInfo  info;
         
            while (true)
            {
                info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        break;
                    case ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.LeftArrow:
                        this.Back(); 
                        break;
                    case ConsoleKey.RightArrow:
                        this.Foward(); 
                        break;
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    default:
                        Get.Red($"Not Valid Key: {info.Key} Char: {info.KeyChar} Modifier: {info.Modifiers}");
                        break;

                }

            }
            
            
        }
        private void Foward()
        {
            this.Path += this.Items[this.CurrentSelection]; 
        }
        private void Back()
        {
            this.Path = this.Path.Substring(0,this.Path.LastIndexOf(Get.Slash()));
        }

        private void Display()
        {
            int max = this.Items.Count < this.MaxHeigh ? this.Items.Count : this.MaxHeigh; 
                for(int item = 0; item < max; item++)
                {
                    if(item == this.CurrentSelection)
                    {
                        Get.Label($"{this.Items[item]}");
                        Get.WriteL("");
                    }
                    if (File.Exists(this.Items[item]) && item != this.CurrentSelection)
                    {
                        Get.Yellow(Get.FileNameFromPath(this.Items[item]));
                    }
                    if (Directory.Exists(this.Items[item]) && item != this.CurrentSelection)
                    {
                        Get.Blue(Get.FolderFromPath(this.Items[item])+Get.Slash());
                    }
                }
        }
        private void LoadItems()
        {
            string[] files, dirs;
            files = Directory.GetFiles(this.Path);
            dirs = Directory.GetDirectories(this.Path);
            foreach (string file in files)
            {
                this.Items.Add(file);
            }
            foreach (string dir in dirs)
            {
                this.Items.Add(dir);
            }
        }
        public void Run()
        {
            
            Get.Blue(this.Path);
            this.Display(); 
            //this.DirectionHandeler();
         

            Get.Wait();
            
        }
     
    }
}
