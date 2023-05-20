using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C_Sharp.Models
{
    public class Application
    {
        public Worker Worker { get; set; }
        public CV Cv { get; set; }
        public string Job { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return $"Worker: {Worker.Name} {Worker.Surname}\nJob: {Job}\nStatus: {Status}";
        }
    }
}
