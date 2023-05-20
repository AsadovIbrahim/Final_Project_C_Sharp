using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C_Sharp.Models
{
    public class CV
    {
        public string Education { get; set; }
        public string University { get; set; }
        public double Gpa { get; set; }
        public List<string> Skills { get; set; }
        public List<string> Companies { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> Languages { get; set; }
        public bool HasDiploma { get; set; }
        public string GitLink { get; set; }
        public string LinkedIn { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CV() { }
        public CV(string education, string university, double gpa, List<string> skills, List<string> companies, DateTime startDate, DateTime endDate, List<string> languages, bool hasDiploma, string gitLink, string linkedIn,string title,string description)
            : this()
        {
            Education = education;
            University = university;
            Gpa = gpa;
            Skills = skills;
            Companies = companies;
            StartDate = startDate;
            EndDate = endDate;
            Languages = languages;
            HasDiploma = hasDiploma;
            GitLink = gitLink;
            LinkedIn = linkedIn;
            Title = title;
            Description = description;
        }
        public override string ToString()
        {
            return $"Education:{Education}\nUniversity:{University}\nGpa:{Gpa}\nSkills:{Skills}\nCompanies:{Companies}\n" +
                $"StartDate:{StartDate}\nEndDate:{EndDate}\nLanguages:{Languages}\nHasDiploma:{HasDiploma}\nGitLink:{GitLink}\n" +
                $"LinedIN:{LinkedIn}\nTitle:{Title}\nDescription{Description}";
        }
    }
}
