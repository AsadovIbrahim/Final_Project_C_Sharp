using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Final_Project_C_Sharp.Models
{
    public class FileManager
    {
        private const string DataDirectory = "data";
        private const string AdminsFile = "admins.json";
        private const string WorkersFile = "workers.json";
        private const string EmployersFile = "employers.json";
        private const string LogFile = "log.txt";

        public static void SaveWorkers(List<Worker> workers)
        {
            string workersJson = JsonConvert.SerializeObject(workers,Formatting.Indented);
            string workersFilePath = Path.Combine(DataDirectory, WorkersFile);

            Directory.CreateDirectory(DataDirectory);
            File.WriteAllText(workersFilePath, workersJson);
        }
        public static List<Worker> LoadWorkers()
        {
            string workersFilePath=Path.Combine(DataDirectory , WorkersFile);
            if (!File.Exists(workersFilePath))
            {
                return new List<Worker>();
            }
            string workersJson=File.ReadAllText(workersFilePath);
            return JsonConvert.DeserializeObject<List<Worker>>(workersJson);
        }
        public static void SaveEmployers(List<Employer> employers)
        {
            string employersJson=JsonConvert.SerializeObject(employers,Formatting.Indented);
            string employersFilePath=Path.Combine(EmployersFile, EmployersFile);

            Directory.CreateDirectory(EmployersFile);
            File.WriteAllText(employersFilePath, employersJson);
        }
        public static List<Employer> LoadEmployers()
        {
            string employersFilePath = Path.Combine(DataDirectory, EmployersFile);
            if (!File.Exists(employersFilePath))
            {
                return new List<Employer>();
            }
            string workersJson = File.ReadAllText(employersFilePath);
            return JsonConvert.DeserializeObject<List<Employer>>(workersJson);
        }
        public static void SaveAdmins(List<Admin> admins)
        {
            string adminsJson = JsonConvert.SerializeObject(admins, Formatting.Indented);
            string adminsFilePath = Path.Combine(DataDirectory, AdminsFile);

            Directory.CreateDirectory(DataDirectory);
            File.WriteAllText(adminsFilePath, adminsJson);
        }
        public static List<Admin> LoadAdmins()
        {
            string adminsFilePath = Path.Combine(DataDirectory, AdminsFile);
            if (!File.Exists(adminsFilePath))
            {
                return new List<Admin>();
            }
            string adminsJson = File.ReadAllText(adminsFilePath);
            return JsonConvert.DeserializeObject<List<Admin>>(adminsJson);
        }
        
        public static void Log(string message)
        {
            string logFilePath=Path.Combine(DataDirectory,LogFile);

            Directory.CreateDirectory(DataDirectory);
            File.AppendAllText(logFilePath, $"{DateTime.Now}:{message}\n");  

        }


    }
}
