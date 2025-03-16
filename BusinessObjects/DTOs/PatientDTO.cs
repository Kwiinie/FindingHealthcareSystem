using BusinessObjects.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public GeneralUserDto User { get; set; }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Now;
                int age = today.Year - User.Birthday.Year;
                if (User.Birthday.Year > today.Year)
                {
                    age--;
                }
                return age;
            }
        }
    }
}
