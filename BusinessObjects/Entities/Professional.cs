using BusinessObjects.Commons;
using BusinessObjects.Enums;
using System;
using System.Collections.Generic;

namespace BusinessObjects.Entities;

public partial class Professional : BaseEntity
{
    public int? UserId { get; set; }

    public int? ExpertiseId { get; set; }

    public string? Province { get; set; }

    public string? District { get; set; }

    public string? Ward { get; set; }

    public string? Address { get; set; }

    public string? Degree { get; set; }

    public string? Experience { get; set; }

    public string? WorkingHours { get; set; }

    public ProfessionalRequestStatus RequestStatus { get; set; }

    public virtual Expertise? Expertise { get; set; }

    public virtual ICollection<PrivateService> PrivateServices { get; set; } = new List<PrivateService>();

    public virtual ICollection<ProfessionalSpecialty> ProfessionalSpecialties { get; set; } = new List<ProfessionalSpecialty>();

    public virtual User? User { get; set; }
}

