using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C_Sharp.Models
{
    public class Employer:User
    {
        public List<string> Vacancies { get; set; }

        public Employer() { }
        
        
        public void ProcessJobApplication(Worker worker,CV cv)
        {
            bool isApplied = false;
            foreach(string vacancy in Vacancies)
            {
                isApplied = true;
                break;
            }
            if(!isApplied)
            {
                Console.WriteLine($"Worker {worker.Name} {worker.Surname} did not apply for any of the vacancies.");
                return;
            }
            bool isQualified = false;  
            {
                isQualified = true;
            }
            if (!isQualified)
            {
                Console.WriteLine($"Worker {worker.Name} {worker.Surname} is not qualified for any of the vacancies.");
                return;

            }
            Console.WriteLine($"Worker {worker.Name} {worker.Surname} has been invited for an interview.");


        }
    }
}
