using EasySaveLib.Controllers;
using EasySaveLib.Models;
using EasySaveLib.Services;
using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveConsole.Vues
{
    internal class JobRun : AbstractViewImpl<JobRunController>, IJobRun
    {


        public JobRun()
        {
        }

        public void Show(List<JobModel> jobs)
        {
            Console.Clear();
            Console.WriteLine("You have enterred the Job execution interface.");
            Console.WriteLine("Enter 'q' to quit the Job execution interface.\n");

            string? exe;
            while (true)
            {
                Console.WriteLine("Do you want to run all jobs sequentially ('s') or just one job ('o') ? \nPlease enter your option :");
                exe = Console.ReadLine();
                switch (exe)
                {
                    case "s":
                        Controller.ExecuteAllJob();
                        return;
                    case "o":
                        JobModel job = ChooseJob(jobs);
                        Controller.ExecuteOneJob(job);
                        return;
                    case "q":
                        return;
                    default:
                        Console.WriteLine("\nThis is not a valid option (enter 's', 'o' or 'q')\n");
                        break;
                }
            }
        }

        //FAIRE LES RETOURS DES MENUS.
        //AFFICHER UN AVANCEMENT
        public JobModel ChooseJob(List<JobModel> jobs)
        {
            Console.Clear();
            Console.WriteLine("List of jobs : \n");
            int[] id = new int[jobs.Count];
            int j = 0;
            foreach (JobModel job in jobs)
            {
                id[j] = j++;
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("ID of job : " + j);
                Console.WriteLine("Job's name : " + job.Name);
                Console.WriteLine("Job's source path :" + job.Source);
                Console.WriteLine("Job's destination path : " + job.Destination);
                Console.WriteLine("Job's type : " + (job.IsDifferential ? "Differential" : "Full"));
            }
            Console.WriteLine("-----------------------------------");
            int idInt;
            while (true)
            {
                Console.WriteLine("\nPlease enter the id of the job you want :");
                string? idString = Console.ReadLine();
                if (idString != null && idString != "")
                {
                    try
                    {
                        idInt = Int32.Parse(idString);
                        break;
                    }
                    catch (System.FormatException) { }
                }
                Console.WriteLine("\nThis is not a valid job id.");
            }
            return jobs[idInt-1];
        }
    }
}
