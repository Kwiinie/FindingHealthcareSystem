using BusinessObjects.Dtos.User;
using BusinessObjects.DTOs.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Professional.Appointment
{
    public class IndexModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        public List<AppointmentDTO> Appointments { get; set; }
        public DateTime Monday { get; set; }
        public IndexModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                string? text;
                GeneralUserDto? acc;
                CheckRole(out text, out acc);
                if (string.IsNullOrEmpty(text) || acc == null || acc.Role != "Professional")
                {
                    return RedirectToPage("/Index");
                }
                Monday = DateTime.Today;
                Appointments = (await _appointmentService.GetAllAsync()).ToList();
                return Page();

            }
            catch (Exception)
            {
                return RedirectToPage("/Index");
            }
        }

        private void CheckRole(out string? text, out GeneralUserDto? acc)
        {
            text = HttpContext.Session.GetString("User");
            acc = null;
            if (!string.IsNullOrEmpty(text))
            {
                acc = JsonConvert.DeserializeObject<GeneralUserDto>(text);
            }
        }

        public async Task<IActionResult> OnGetNextWeek(DateTime monday, int next)
        {
            try
            {
                Monday = monday.AddDays(next);
                if (next == 0)
                {
                    Monday = monday.AddDays(-(int)monday.DayOfWeek + (int)DayOfWeek.Monday);
                }
                await Task.Delay(10);
                Appointments = (await _appointmentService.GetAllAsync()).ToList();
                return new PartialViewResult
                {
                    ViewName = "_PatientAppointments",
                    StatusCode = 200,
                    ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    {
                        Model = this
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new StatusCodeResult(500);
            }
        }
    }
}
