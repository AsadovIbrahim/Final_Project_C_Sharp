using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace Final_Project_C_Sharp.Models
{
    public class Functions
    {

       public static void SendMail(string toMail,string Content)
        {
            var fromAddress = new MailAddress("ibrahimasadov31@gmail.com", "BossAz");
            var toAddress = new MailAddress(toMail);
            string fromPassword = "wzktlxuijxjewkae";
            const string subject = "Boss.Az";
            
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
                Body = Content,
            })
            {
                smtp.Send(message);
            }
        }

        static public void SetConsoleColor(string option)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(option);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void PressAnyKey()
        {
            Console.Write("\nPress any key to continue . . .");
            Console.ReadKey();
        }
        public static void MainMenu()
        {
            List<Worker> workers = FileManager.LoadWorkers();


            bool status = true;

            List<Employer> employers = FileManager.LoadEmployers();
            List<Admin> admins = FileManager.LoadAdmins();
            dynamic key;
            int choose = 0;
            User currentUser = null;
            while (true)
            {
                Console.Clear();
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

                            Worker worker1 = new Worker
                            {
                                Username = username,
                                Password = password,
                                Name = name,
                                Surname = surname,
                                City = city,
                                Phone = phone,
                                Age = age,
                                Cvs = new List<CV>()
                            };

                            workers.Add(worker1);
                            Console.WriteLine("Worker registered successfully!");

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
                                    currentUser = worker1;
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
                                        currentUser = employer1;
                                        break;
                                    }
                                }
                            }

                            if (isWorker || isEmployer)
                            {
                                Console.WriteLine("Logged in successfully!");
                                while (status)
                                {
                                    if (currentUser is Worker)
                                    {
                                        Console.Clear();
                                        if (choose == 0) SetConsoleColor("\n\n\n\n\n\n\n\t\t\t\t\t\t->POST CV<-");
                                        else Console.WriteLine("\n\n\n\n\n\n\n\t\t\t\t\t\tPOST CV");
                                        if (choose == 1) SetConsoleColor("\t\t\t\t\t\t->VIEW MY CVs<-");
                                        else Console.WriteLine("\t\t\t\t\t\tVIEW MY CVs");

                                        if (choose == 2) SetConsoleColor("\t\t\t\t\t\t->LOGOUT<-");
                                        else Console.WriteLine("\t\t\t\t\t\tLOGOUT");
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
                                                    Console.WriteLine("Enter CV Title:");
                                                    string cvTitle = Console.ReadLine();

                                                    Console.WriteLine("Enter CV Description:");
                                                    string cvDescription = Console.ReadLine();

                                                    CV cv = new CV
                                                    {
                                                        Title = cvTitle,
                                                        Description = cvDescription
                                                    };

                                                    ((Worker)currentUser).Cvs.Add(cv);
                                                    Console.WriteLine("CV posted successfully!");
                                                    Console.ReadKey();
                                                }
                                                else if (choose == 1)
                                                {
                                                    Console.WriteLine("MY CVs:");
                                                    foreach (CV cv in ((Worker)currentUser).Cvs)
                                                    {
                                                        Console.WriteLine("Title: " + cv.Title);
                                                        Console.WriteLine("Description: " + cv.Description);
                                                        Console.WriteLine("--------------------");
                                                    }
                                                    Console.ReadKey();
                                                }

                                                else if (choose == 2)
                                                {
                                                    MainMenu();
                                                }
                                                break;

                                        }


                                    }
                                }
                            }
                        }
                        break;
                }
            }
        }

        public static void WorkerMenu()
        {
            dynamic key;
            int choose = 0;
            User currentUser = null;
            bool status = true;

            while (status)
            {
                if (currentUser is Worker)
                {
                    Console.Clear();
                    if (choose == 0) SetConsoleColor("\n\n\n\n\n\n\n\t\t\t\t\t\t->POST CV<-");
                    else Console.WriteLine("\n\n\n\n\n\n\n\t\t\t\t\t\tPOST CV");
                    if (choose == 1) SetConsoleColor("\t\t\t\t\t\t->VIEW MY CVs<-");
                    else Console.WriteLine("\t\t\t\t\t\tVIEW MY CVs");

                    if (choose == 2) SetConsoleColor("\t\t\t\t\t\t->LOGOUT<-");
                    else Console.WriteLine("\t\t\t\t\t\tLOGOUT");
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
                                Console.WriteLine("Enter CV Title:");
                                string cvTitle = Console.ReadLine();

                                Console.WriteLine("Enter CV Description:");
                                string cvDescription = Console.ReadLine();

                                CV cv = new CV
                                {
                                    Title = cvTitle,
                                    Description = cvDescription
                                };

                                ((Worker)currentUser).Cvs.Add(cv);
                                Console.WriteLine("CV posted successfully!");
                                Console.ReadKey();
                            }
                            else if (choose == 1)
                            {
                                Console.WriteLine("MY CVs:");
                                foreach (CV cv in ((Worker)currentUser).Cvs)
                                {
                                    Console.WriteLine("Title: " + cv.Title);
                                    Console.WriteLine("Description: " + cv.Description);
                                    Console.WriteLine("--------------------");
                                }
                                Console.ReadKey();
                            }

                            else if (choose == 2)
                            {
                                MainMenu();
                            }
                            break;
                    }
                }
            }
        }
        public static void Logo()
        {
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine(@"                               ____                                           
                              |  _ \                              /\          
                              | |_) |   ___    ___   ___         /  \     ____
                              |  _ <   / _ \  / __| / __|       / /\ \   |_  /
                              | |_) | | (_) | \__ \ \__ \  _   / ____ \   / / 
                              |____/   \___/  |___/ |___/ (_) /_/    \_\ /___|
                                                 
                                                 ");
            Console.ForegroundColor=ConsoleColor.Red;
        }
        
    }
}
