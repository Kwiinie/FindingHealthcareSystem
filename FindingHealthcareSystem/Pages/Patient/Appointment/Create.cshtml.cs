using BusinessObjects.DTOs.Facility;
using BusinessObjects.DTOs.Professional;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Globalization;

namespace FindingHealthcareSystem.Pages.Patient.Appointment
{
    public class CreateModel : PageModel
    {
        private readonly IProfessionalService _professionalService;
        private readonly IFacilityService _facilityService;

        public CreateModel(IProfessionalService professionalService, IFacilityService facilityService)
        {
            _facilityService = facilityService;
            _professionalService = professionalService;
        }

        /// <summary>
        /// PROPERTIES
        /// </summary>
        public List<string> TimeSlots { get; set; } = new List<string>();
        public int? ProviderId { get; set; }
        public string ProviderType { get; set; }
        public ProfessionalDto? professional { get; set; }
        public FacilityDto? facility { get; set; }


        public async Task OnGet()
        {
            var providerIdString = Request.Query["ProviderId"].FirstOrDefault();
            string workingHours = null;

            if (int.TryParse(providerIdString, out int providerId))
            {
                ProviderId = providerId;
            }

            ProviderType = Request.Query["ProviderType"].FirstOrDefault();

            if (!string.IsNullOrEmpty(ProviderType))
            {
                if (ProviderType == "Professional")
                {
                    professional = await _professionalService.GetById(providerId);
                    workingHours = professional?.WorkingHours;
                }
                else if (ProviderType == "Facility")
                {
                    facility = await _facilityService.GetById(providerId);
                    workingHours = "7:00 - 16:00";  // Assuming a default time for facilities
                }

                TimeSlots = GenerateTimeSlots(workingHours);
            }
        }


        private List<string> GenerateTimeSlots(string workingHours)
        {
            List<string> slots = new List<string>();
            if (string.IsNullOrEmpty(workingHours))
                return slots;

            string[] hours = workingHours.Split('-');
            if (hours.Length != 2) return slots;

            TimeSpan startTime = TimeSpan.ParseExact(hours[0].Trim(), "h\\:mm", CultureInfo.InvariantCulture);
            TimeSpan endTime = TimeSpan.ParseExact(hours[1].Trim(), "h\\:mm", CultureInfo.InvariantCulture);

            while (startTime < endTime)
            {
                TimeSpan nextSlot = startTime.Add(TimeSpan.FromHours(1));
                if (nextSlot <= endTime)
                {
                    slots.Add($"{startTime:hh\\:mm} - {nextSlot:hh\\:mm}");
                }
                startTime = nextSlot;
            }
            return slots;
        }
    }
}
