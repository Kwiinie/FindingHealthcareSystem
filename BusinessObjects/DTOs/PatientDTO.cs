using BusinessObjects.Dtos.User;
using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class PatientDTO
    {
        public int? Id { get; set; }
        public int UserId { get; set; }

        public string Note { get; set; }

        //public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        //public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public GeneralUserDto? User { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
