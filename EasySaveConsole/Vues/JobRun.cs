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
            Console.WriteLine(Controller.GetTranslation("jobRun_show_enterringJobRun"));
            Console.WriteLine(Controller.GetTranslation("jobRun_show_exitMenu") + "\n");

            string? exe;
            while (true)
            {
                Console.WriteLine(Controller.GetTranslation("jobRun_show_selectOption") + "\n" + Controller.GetTranslation("jobRun_show_requestOption"));
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
                        Console.WriteLine("\n"+ Controller.GetTranslation("jobRun_show_errorEnterValidOption") +"\n");
                        break;
                }
            }
        }
       
        public JobModel ChooseJob(List<JobModel> jobs)
        {
            Console.Clear();
            Console.WriteLine(Controller.GetTranslation("jobRun_chooseJob_listJobs\n"));
            int[] id = new int[jobs.Count];
            int j = 0;
            foreach (JobModel job in jobs)
            {
                id[j] = j++;
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(Controller.GetTranslation("jobRun_chooseJob_id") + j);
                Console.WriteLine(Controller.GetTranslation("jobRun_chooseJob_name") + job.Name);
                Console.WriteLine(Controller.GetTranslation("jobRun_chooseJob_source") + job.Source);
                Console.WriteLine(Controller.GetTranslation("jobRun_chooseJob_dest") + job.Destination);
                Console.WriteLine(Controller.GetTranslation("jobRun_chooseJob_type") + (job.IsDifferential ? Controller.GetTranslation("jobRun_chooseJob_typeDiff") : Controller.GetTranslation("jobRun_chooseJob_typeFull")));
            }
            Console.WriteLine("-----------------------------------");
            int idInt;
            while (true)
            {
                Console.WriteLine("\n" + Controller.GetTranslation("jobRun_chooseJob_requestId"));
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
                Console.WriteLine("\n" + Controller.GetTranslation("jobRun_chooseJob_errorEnterValidId"));
            }
            return jobs[idInt-1];
        }
        
        public void Progress(JobModel job)
        {
            Console.Clear();
            Console.WriteLine(Controller.GetTranslation("jobRun_progress_jobProgress") + job.Name);
        }
    }
}
