using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C_Sharp.Models
{
    public class Worker : User
    {
        private readonly Guid _ID;

        public Guid ID { get { return _ID; } }

        public List<CV> Cvs { get; set; }
        public List<string>Vacancies{ get; set; }

        public void ApplyForJob(Employer employer,CV cv)
        {
            employer.ProcessJobApplication(this, cv);
        }
        public Worker() { _ID = Guid.NewGuid(); }
       
    }
}
