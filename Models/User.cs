using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C_Sharp.Models
{
    public class User
    {
        private readonly Guid _Id;
        private string _Username;
        private string _Password;
        private string _Name;
        private string _Surname;
        private string _City;
        private string _Phone;
        private int _Age;

        public Guid Id { get { return _Id; } }
        public string Username { get; set; }
        public string Email { get; set; } 
        public string Password{ get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public int? Age { get; set; }

        public User() { _Id = Guid.NewGuid(); }
        public User(string username, string password,string email, string name, string surname, string city, string phone, int age):this()
        {
            Username = username;
            Password = password;
            Email = email;
            Name = name;
            Surname = surname;
            City = city;
            Phone = phone;
            Age = age;
        }
    }
}
