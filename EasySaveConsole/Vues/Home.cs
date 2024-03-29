﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveLib.Controllers;
using EasySaveLib.Vues;

namespace EasySaveConsole.Vues
{
    internal class Home : AbstractViewImpl<HomeController>, IHome
    {

        public Home()
        {
        }

        public void showMenu()
        {
            string a = "";
            while (a != "q")
            {
                Console.Clear();
                Console.WriteLine(Controller.GetTranslation("home_showMenu_welcome"));
                Console.WriteLine(Controller.GetTranslation("home_showMenu_selectOption"));
                Console.WriteLine();
                Console.WriteLine(Controller.GetTranslation("home_showMenu_jc"));
                Console.WriteLine(Controller.GetTranslation("home_showMenu_je"));
                Console.WriteLine(Controller.GetTranslation("home_showMenu_jv"));
                Console.WriteLine(Controller.GetTranslation("home_showMenu_ju"));
                Console.WriteLine(Controller.GetTranslation("home_showMenu_jr"));
                Console.WriteLine(Controller.GetTranslation("home_showMenu_s"));
                Console.WriteLine();
                Console.WriteLine(Controller.GetTranslation("home_showMenu_quitProgram"));
                a = Console.ReadLine() ?? "";
                switch (a)
                {
                    case "jc":
                        Controller.AccessSave(new JobCreate());
                        break;
                    case "je":
                        Controller.ShowJobRun(new JobRun());
                        break;
                    case "jv":
                        Controller.ShowJobViews(new JobView());
                        break;
                    case "ju":
                        Controller.ShowJobUpdate(new JobUpdate());
                        break;
                    case "jr":
                        Controller.ShowJobRemove(new JobRemove());
                        break;
                    case "s":
                        Controller.ShowSettings(new Settings());
                        break;
                    case "q":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine(Controller.GetTranslation("home_showMenu_errorEnterValidOption"));
                        Console.WriteLine();
                        break;
                }
            }
        }
        
    }
}
