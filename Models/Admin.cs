using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C_Sharp.Models
{
    public class Admin:User
    {
        public Admin(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public void ViewAllWorkers(List<Worker>workers)
        {
            Console.WriteLine("All Workers:");
            foreach (Worker worker in workers)
            {
                Console.WriteLine($"Name:{worker.Name} {worker.Surname}");
                Console.WriteLine($"Username:{worker.Username}");
                Console.WriteLine($"City:{worker.City}");
                Console.WriteLine($"Phone:{worker.Phone}");
                Console.WriteLine($"Age:{worker.Age}");
                Console.WriteLine();
            }
        }
        public void AddVacancy(Employer employer,string vacancy)
        {
            employer.Vacancies.Add(vacancy);
            Console.WriteLine($"Vacancy:{vacancy} added for employer {employer.Name}");
        }
        public void RemoveVacancy(Employer employer,string vacancy)
        {
            if(employer.Vacancies.Contains(vacancy))
            {
                employer.Vacancies.Remove(vacancy);
                Console.WriteLine($"Vacancy {vacancy} removed for employer {employer.Name}");
            }
            else
            {
                Console.WriteLine($"Vacancy {vacancy} does not exist for employer {employer.Name}");
            }
        }
    }
}
