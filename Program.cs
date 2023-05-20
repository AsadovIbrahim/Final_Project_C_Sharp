using Final_Project_C_Sharp.Models;
using System.Net.Mail;
using System.Net;
using static Final_Project_C_Sharp.Models.Functions;
using static Final_Project_C_Sharp.Models.Network;
using static Final_Project_C_Sharp.Models.FileManager;
namespace Final_Project_C_Sharp


{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Worker> workers = FileManager.LoadWorkers();


            bool status = true;

            List<Employer> employers = FileManager.LoadEmployers();
            List<Admin> admins = FileManager.LoadAdmins();
            dynamic key;
            int choose = 0;
            User currentUser = null;

            Worker worker = new Worker
            {

                Username = "ibrahim",
                Password = "12345678",
                Name = "Ibrahim",
                Surname = "Asadov",
                City = "Baku",
                Phone = "0704040300",
                Age = 19,
                Cvs = new List<CV>()
                {
                    new CV
                    {
                        Education = "InformationTechnology",
                        University = "Azerbaijan Technic University",
                        Gpa = 3.7,
                        Skills = new List<string> { "C#", "C++", "Java", "Python" },
                        Companies = new List<string> { "Microsoft", "Google" },
                        StartDate = new DateTime(2020, 09, 15),
                        EndDate = new DateTime(2013, 05, 14),
                        Languages = new List<string> { "English", "Spanish", "French" },
                        HasDiploma = true,
                        GitLink = "https://github.com/AsadovIbrahim",
                        LinkedIn = "https://www.linkedin.com/in/ibrahim"
                    }
                }
            };

            Employer employer = new Employer
            {
                Username = "hesen",
                Password = "12345678",
                Name = "Hesen",
                Surname = "Abdullazade",
                City = "Baku",
                Phone = "0704040301",
                Age = 15,
                Vacancies = new List<string> { "Software Engineer", "Data Analyst","Front-End Developer","Back-End Developer" }
            };
            
            workers.Add(worker);
            employers.Add(employer);
            choose = 0;
            while (status)
            {
                Console.Clear();
                Logo();
                if (choose == 0) SetConsoleColor("\n\n\n\n\n\n\n\t\t\t\t\t\t->SIGN UP<-");
                else Console.WriteLine("\n\n\n\n\n\n\n\t\t\t\t\t\tSIGN UP");
                if (choose == 1) SetConsoleColor("\t\t\t\t\t\t->SIGN IN<-");
                else Console.WriteLine("\t\t\t\t\t\tSIGN IN");
                if (choose == 2) SetConsoleColor("\t\t\t\t\t\t->EXIT<-");
                else Console.WriteLine("\t\t\t\t\t\tEXIT");
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case 27:
                        status = false;
                        break;
                    case ConsoleKey.UpArrow:
                        if (choose != 0) choose--;
                        else choose = 2;
                        break;
                    case ConsoleKey.DownArrow:
                        if (choose != 2) choose++;
                        else choose = 0;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        if (choose == 0)
                        {
                            Console.WriteLine("Enter Username:");
                            string username = Console.ReadLine();

                            Console.WriteLine("Enter Gmail:");
                            string gmail = Console.ReadLine();

                            Console.WriteLine("Enter Password:");
                            string password = Console.ReadLine();

                            Console.WriteLine("Enter Name:");
                            string name = Console.ReadLine();

                            Console.WriteLine("Enter Surname:");
                            string surname = Console.ReadLine();

                            Console.WriteLine("Enter City:");
                            string city = Console.ReadLine();

                            Console.WriteLine("Enter Phone:");
                            string phone = Console.ReadLine();

                            Console.WriteLine("Enter Age:");
                            int age = int.Parse(Console.ReadLine());


                            Random random = new();
                            int randint = random.Next(100000, 1000000);
                            SendMail(gmail, randint.ToString());
                            Console.WriteLine("Enter Verification Code:");
                            string eded =Console.ReadLine();
                            int.TryParse(eded, out int a);
                            if (a == randint)
                            {

                                Worker worker1 = new Worker
                                {
                                    Username = username,
                                    Password = password,
                                    Name = name,
                                    Surname = surname,
                                    Email = gmail,
                                    City = city,
                                    Phone = phone,
                                    Age = age,
                                    Cvs = new List<CV>()
                                };

                                workers.Add(worker1);
                                Console.WriteLine("Worker registered successfully!");
                                LoadWorkers();
                                SaveWorkers(workers);
                            }
                            else {
                                Console.WriteLine("Invalid Code");
                            }

                            Console.ReadKey();
                        }
                        else if (choose == 1)
                        {
                            Console.WriteLine("Enter Username:");
                            string username = Console.ReadLine();

                            Console.WriteLine("Enter Password:");
                            string password = Console.ReadLine();

                            bool isWorker = false;
                            bool isEmployer = false;

                            foreach (Worker worker1 in workers)
                            {
                                if (worker1.Username == username && worker1.Password == password)
                                {
                                    isWorker = true;
                                    currentUser = worker;
                                    break;
                                }
                            }

                            if (!isWorker)
                            {
                                foreach (Employer employer1 in employers)
                                {
                                    if (employer1.Username == username && employer1.Password == password)
                                    {
                                        isEmployer = true;
                                        currentUser = employer;
                                        break;
                                    }
                                }
                            }

                            if (isWorker || isEmployer)
                            {
                                Console.WriteLine("Logged in successfully!");




                                while (status)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    if (choose == 0) SetConsoleColor("\n\n\n\n\n\n\n\t\t\t\t\t\t->WORKER<-");
                                    else Console.WriteLine("\n\n\n\n\n\n\n\t\t\t\t\t\tWORKER");
                                    if (choose == 1) SetConsoleColor("\t\t\t\t\t\t->EMPLOYER<-");
                                    else Console.WriteLine("\t\t\t\t\t\tEMPLOYER");
                                    if (choose == 2) SetConsoleColor("\t\t\t\t\t\t->ADMIN<-");
                                    else Console.WriteLine("\t\t\t\t\t\tADMIN");
                                    if (choose == 3) SetConsoleColor("\t\t\t\t\t\t->EXIT<-");
                                    else Console.WriteLine("\t\t\t\t\t\tEXIT");
                                    key = Console.ReadKey();
                                    switch (key.Key)
                                    {
                                        case 27:
                                            status = false;
                                            break;
                                        case ConsoleKey.UpArrow:
                                            if (choose != 0) choose--;
                                            else choose = 3;
                                            break;
                                        case ConsoleKey.DownArrow:
                                            if (choose != 3) choose++;
                                            else choose = 0;
                                            break;
                                        case ConsoleKey.Enter:
                                            Console.Clear();

                                            if (choose == 0)
                                            {
                                                bool isFound = false;

                                                Console.WriteLine("Enter Username:");
                                                string username1 = Console.ReadLine();

                                                Console.WriteLine("Enter Password:");
                                                string password1 = Console.ReadLine();
                                                Console.Clear();

                                                while (true)
                                                {
                                                    foreach (Worker worker1 in workers)
                                                    {
                                                        if (worker1.Username == username && worker1.Password == password)
                                                        {
                                                            isFound = true;
                                                            while (true)
                                                            {
                                                                Console.ForegroundColor= ConsoleColor.Red;
                                                                if (choose == 0) SetConsoleColor("\n\n\n\n\n\n\n\t\t\t\t\t\t->View Vacancies<-");
                                                                else Console.WriteLine("\n\n\n\n\n\n\n\t\t\t\t\t\tView Vacancies");
                                                                if (choose == 1) SetConsoleColor("\t\t\t\t\t\t->Apply For A Job<-");
                                                                else Console.WriteLine("\t\t\t\t\t\tApply For A Job");
                                                                if (choose == 2) SetConsoleColor("\t\t\t\t\t\t->EXIT<-");
                                                                else Console.WriteLine("\t\t\t\t\t\tEXIT");
                                                                key = Console.ReadKey();
                                                                switch (key.Key)
                                                                {
                                                                    case 27:
                                                                        status = false;
                                                                        break;
                                                                    case ConsoleKey.UpArrow:
                                                                        if (choose != 0) choose--;
                                                                        else choose = 2;
                                                                        break;
                                                                    case ConsoleKey.DownArrow:
                                                                        if (choose != 2) choose++;
                                                                        else choose = 0;
                                                                        break;
                                                                    case ConsoleKey.Enter:
                                                                        if (choose == 0)
                                                                        {
                                                                            Console.WriteLine("Vacancies:");
                                                                            foreach (string vacancy in employer.Vacancies)
                                                                            {
                                                                                Console.WriteLine("- " + vacancy);

                                                                            }
                                                                            Console.ReadKey();

                                                                        }
                                                                        else if (choose == 1)
                                                                        {
                                                                            Console.WriteLine("Please enter the name of employer you want to apply to:");
                                                                            string employerName = Console.ReadLine();

                                                                            Employer employer1 = null;
                                                                            foreach (Employer e in employers)
                                                                            {
                                                                                if (e.Name == employerName)
                                                                                {
                                                                                    employer1 = e;
                                                                                    break;
                                                                                }
                                                                            }

                                                                            if (employer1 == null)
                                                                            {
                                                                                Console.WriteLine("No employer found with that name!");
                                                                                continue;
                                                                            }
                                                                            Console.WriteLine("Please enter the index of the CV you want to use for your application:");
                                                                            int cvIndex = int.Parse(Console.ReadLine()) - 1;

                                                                            if (cvIndex < 0 || cvIndex >= worker.Cvs.Count)
                                                                            {
                                                                                Console.WriteLine("Invalid CV index.");
                                                                                continue;
                                                                            }
                                                                            CV cv = worker.Cvs[cvIndex];
                                                                            worker.ApplyForJob(employer, worker.Cvs[0]);
                                                                            Console.WriteLine("Application Submitted!");
                                                                            Console.ReadKey(true);
                                                                            
                                                                            Console.WriteLine("Email sent!");

                                                                        }
                                                                        else if (choose == 2)
                                                                        {
                                                                            Logo();
                                                                            MainMenu();

                                                                        }
                                                                        break;


                                                                }
                                                                Console.Clear();
                                                                Console.ResetColor();

                                                            }
                                                        }
                                                    }
                                                    if (!isFound)
                                                    {
                                                        try
                                                        {
                                                            throw new Exception("Invalid Password!");

                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }
                                                    }
                                                    Console.ReadKey();
                                                    break;

                                                }
                                                FileManager.SaveWorkers(workers);


                                            }

                                            else if (choose == 1)
                                            {

                                                bool isFound = false;
                                                status = true;

                                                Console.WriteLine("Enter Username:");
                                                string username1 = Console.ReadLine();

                                                Console.WriteLine("Enter Password:");
                                                string password1 = Console.ReadLine();

                                                Console.Clear();
                                                foreach (Employer employer1 in employers)
                                                {

                                                    if (employer1.Username == username && employer1.Password == password)
                                                    {
                                                        isFound = true;

                                                        while (true)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            currentUser = employer;

                                                            if (choose == 0) SetConsoleColor("\n\n\n\n\n\n\n\t\t\t\t\t\t->View Vacancies<-");
                                                            else Console.WriteLine("\n\n\n\n\n\n\n\t\t\t\t\t\tView Vacancies");
                                                            if (choose == 1) SetConsoleColor("\t\t\t\t\t\t->EXIT<-");
                                                            else Console.WriteLine("\t\t\t\t\t\tEXIT");
                                                            key = Console.ReadKey();
                                                            switch (key.Key)
                                                            {
                                                                case 27:
                                                                    status = false;
                                                                    break;
                                                                case ConsoleKey.UpArrow:
                                                                    if (choose != 0) choose--;
                                                                    else choose = 1;
                                                                    break;
                                                                case ConsoleKey.DownArrow:
                                                                    if (choose != 1) choose++;
                                                                    else choose = 0;
                                                                    break;
                                                                case ConsoleKey.Enter:
                                                                    Console.Clear();
                                                                    if (choose == 0)
                                                                    {
                                                                        Console.WriteLine("Vacancies:");
                                                                        foreach (string vacancy in employer.Vacancies)
                                                                        {
                                                                            Console.WriteLine("- " + vacancy);
                                                                        }
                                                                        Console.ReadKey();
                                                                        var fromAddress = new MailAddress("ibrahimasadov31@gmail.com", "BossAz");
                                                                        var toAddress = new MailAddress("ibrahimasadov31@gmail.com");
                                                                        string fromPassword = "wzktlxuijxjewkae";
                                                                        const string subject = "Boss.Az";
                                                                        string body = currentUser.Name + currentUser.Surname + " has logged in ";

                                                                        var smtp = new SmtpClient
                                                                        {
                                                                            Host = "smtp.gmail.com",
                                                                            Port = 587,
                                                                            EnableSsl = true,
                                                                            DeliveryMethod = SmtpDeliveryMethod.Network,
                                                                            Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                                                                            Timeout = 20000
                                                                        };

                                                                        using (var message = new MailMessage(fromAddress, toAddress)
                                                                        {
                                                                            Subject = subject,
                                                                            Body = body
                                                                        })
                                                                        {
                                                                            smtp.Send(message);
                                                                        }
                                                                        Console.WriteLine("Email sent!");


                                                                    }
                                                                    else if (choose == 1)
                                                                    {
                                                                        Logo();
                                                                        MainMenu();
                                                                    }
                                                                    break;
                                                            }
                                                            Console.Clear();
                                                            Console.ResetColor();
                                                        }
                                                    }

                                                }
                                                if (!isFound)
                                                {
                                                    try
                                                    {
                                                        throw new Exception("Invalid Password!");

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }
                                                Console.ReadKey();
                                            }

                                            else if (choose == 2)
                                            {
                                                Console.WriteLine("Enter Username:");
                                                string usernameAdmin = Console.ReadLine();

                                                Console.WriteLine("Enter Password:");
                                                string adminPassword = Console.ReadLine();

                                                if (usernameAdmin == "admin" && adminPassword == "admin123")
                                                {
                                                    Console.WriteLine("Admin logged in succesfully!");
                                                    Console.Clear();
                                                    while (true)
                                                    {
                                                        Console.ForegroundColor= ConsoleColor.Red;
                                                        if (choose == 0) SetConsoleColor("\n\n\n\n\n\n\n\t\t\t\t\t\t->ADD VACANCY<-");
                                                        else Console.WriteLine("\n\n\n\n\n\n\n\t\t\t\t\t\tADD VACANCY");
                                                        if (choose == 1) SetConsoleColor("\t\t\t\t\t\t->REMOVE VACANCY<-");
                                                        else Console.WriteLine("\t\t\t\t\t\tREMOVE VACANCY");
                                                        if (choose == 2) SetConsoleColor("\t\t\t\t\t\t->VIEW VACANCY<-");
                                                        else Console.WriteLine("\t\t\t\t\t\tVIEW VACANCY");
                                                        if (choose == 3) SetConsoleColor("\t\t\t\t\t\t->EXIT<-");
                                                        else Console.WriteLine("\t\t\t\t\t\tEXIT");
                                                        key = Console.ReadKey();
                                                        switch (key.Key)
                                                        {
                                                            case 27:
                                                                status = false;
                                                                break;
                                                            case ConsoleKey.UpArrow:
                                                                if (choose != 0) choose--;
                                                                else choose = 3;
                                                                break;
                                                            case ConsoleKey.DownArrow:
                                                                if (choose != 3) choose++;
                                                                else choose = 0;
                                                                break;
                                                            case ConsoleKey.Enter:
                                                                if (choose == 0)
                                                                {
                                                                    Console.WriteLine("\nEnter the vacancy to add:");
                                                                    string vacancy = Console.ReadLine();
                                                                    employer.Vacancies.Add(vacancy);
                                                                    Console.WriteLine("Vacancy added successfully!");
                                                                    Console.ReadKey(true);
                                                                    SaveEmployers(employers);

                                                                }
                                                                else if (choose == 1)
                                                                {
                                                                    try
                                                                    {
                                                                        Console.WriteLine("\nEnter the index of the vacancy to remove:");
                                                                        int vacancyIndex;
                                                                        if(!int.TryParse(Console.ReadLine(),out vacancyIndex))
                                                                        {
                                                                            throw new Exception("Invalid input format");
                                                                        }

                                                                        vacancyIndex--;
                                                                        if (vacancyIndex < 0 || vacancyIndex >= employer.Vacancies.Count)
                                                                        {
                                                                            throw new Exception("Invalid Index");
                                                                        }

                                                                        employer.Vacancies.RemoveAt(vacancyIndex);
                                                                        Console.WriteLine("Vacancy removed successfully!");
                                                                        Console.ReadKey(true);
                                                                        SaveEmployers(employers);
                                                                        break;
                                                                    }
                                                                    
                                                                    catch(Exception ex)
                                                                    {
                                                                        Console.WriteLine(ex.Message);
                                                                        Console.ReadKey();
                                                                    }
                                                                }
                                                                else if (choose == 2)
                                                                {
                                                                    Console.WriteLine("Vacancies:");
                                                                    for (int i = 0; i < employer.Vacancies.Count; i++)
                                                                    {
                                                                        Console.WriteLine($"{i + 1}. {employer.Vacancies[i]}");
                                                                    }
                                                                    Console.ReadKey(true);
                                                                    break;
                                                                }
                                                                else if (choose == 3)
                                                                {
                                                                    Logo();
                                                                    MainMenu();
                                                                }
                                                                FileManager.SaveAdmins(admins);

                                                                break;


                                                        }
                                                        Console.Clear();
                                                        Console.ResetColor();

                                                    }

                                                }
                                            }
                                            else if (choose == 3)
                                            {
                                                Logo();
                                                MainMenu();

                                            }
                                            break;
                                    }
                                    FileManager.SaveEmployers(employers);
                                    Console.Clear();
                                    Console.ResetColor();

                                }
                            }
                        }
                        break;
                }
            
            
            }

        }
    }
}