using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace FileManager
{
    class Program
    {

        static void Main(string[] args)
        {
            
            while (true)
            {

                Comands.Get_Command();
                
                
                //Comands.Window();



                //Console.SetCursorPosition(0, 22);
                //Console.WriteLine("Введите путь к директории:");
                //Console.WriteLine("Для выхода нажмите крестик");
                //Console.SetCursorPosition(0, 27);
                //Tree.GetDir();
              
                
            }
        }
    }
}
