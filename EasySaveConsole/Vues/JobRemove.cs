using EasySaveLib.Controllers;
using EasySaveLib.Models;
using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveConsole.Vues
{
    internal class JobRemove : AbstractViewImpl<JobRemoveController>, IJobRemove
    {
        public JobRemove()
        {
        }

        public void ShowJobs(List<JobModel> jobs)
        {
            Console.Clear();
            Console.WriteLine(Controller.GetTranslation("jobRemove_showJobs_title") + "\n\n");
            int i = 1;
            foreach (JobModel job in jobs)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(Controller.GetTranslation("jobRemove_showJobs_id") + " " + i.ToString());
                Console.WriteLine(Controller.GetTranslation("jobView_show_nameJob") + job.Name);
                Console.WriteLine(Controller.GetTranslation("jobView_show_sourcePath") + job.Source);
                Console.WriteLine(Controller.GetTranslation("jobView_show_destPath") + job.Destination);
            }
            Console.WriteLine("-----------------------------------\n\n");
        }

        public int ChooseJob(int listJobLength)
        {
            Console.WriteLine(Controller.GetTranslation("jobRemove_chooseJob_WichJob"));
            string? choice = "";
            while (choice != "q")
            {
                choice = Console.ReadLine();
                if (Int32.TryParse(choice, out int choiceInt))
                    if (choiceInt <= listJobLength)
                        return choiceInt;
                if (choice != "q")
                    Console.WriteLine(Controller.GetTranslation("jobRemove_chooseJob_errorChoice"));
            }
            return 0;
        }

        public void EndMessage(bool success = false)
        {
            if (success) Console.WriteLine(Controller.GetTranslation("jobRemove_endMessage_success"));
            Console.WriteLine(Controller.GetTranslation("jobUpdate_exit_exitMenu"));
            Console.ReadLine();
        }

        public void ShowError(string key)
        {
            Console.Clear();
            Console.WriteLine(Controller.GetTranslation(key) + "\n\n");
        }
    }
}
