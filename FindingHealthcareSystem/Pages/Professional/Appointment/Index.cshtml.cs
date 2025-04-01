using BusinessObjects.Dtos.User;
using BusinessObjects.DTOs.Appointment;
using BusinessObjects.Enums;
using FindingHealthcareSystem.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Professional.Appointment
{
    public class IndexModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IHubContext<UpdateHub> _hubContext;
        [BindProperty]
        public int DeleteId { get; set; }
        public List<AppointmentDTO> Appointments { get; set; }
        public int TotalMyAppointment { get; set; }
        public int TotalPatient { get; set; }
        public int TotalWaitAppointment { get; set; }
        public int TotalCompleteAppointment { get; set; }
        public DateTime Monday { get; set; }
        public IndexModel(IAppointmentService appointmentService, IHubContext<UpdateHub> hubContext)
        {
            _appointmentService = appointmentService;
            _hubContext = hubContext;
        }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                var textAcc = HttpContext.Session.GetString("User");
                var acc = JsonConvert.DeserializeObject<GeneralUserDto>(textAcc);
                Monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                Appointments = await _appointmentService.GetAllAppoinmentByDate(acc.Id, Monday, Monday.AddDays(7));
                TotalMyAppointment = await _appointmentService.CountAppointmentByStatus(acc.Id, "");
                TotalWaitAppointment = await _appointmentService.CountAppointmentByStatus(acc.Id, AppointmentStatus.Pending.ToString());
                TotalCompleteAppointment = await _appointmentService.CountAppointmentByStatus(acc.Id, AppointmentStatus.Completed.ToString());
                return Page();
            }
            catch (Exception)
            {
                return RedirectToPage("/Index");
            }
        }

        //private async void CheckRole(out string? text, out GeneralUserDto? acc)
        //{
        //    text = HttpContext.Session.GetString("User");
        //    acc = null;
        //    if (!string.IsNullOrEmpty(text))
        //    {
        //        acc = JsonConvert.DeserializeObject<GeneralUserDto>(text);
        //    }
        //}

        public async Task<IActionResult> OnGetNextWeek(DateTime monday, int next)
        {
            try
            {
                var textAcc = HttpContext.Session.GetString("User");
                var acc = JsonConvert.DeserializeObject<GeneralUserDto>(textAcc);
                Monday = monday.AddDays(next);
                if (next == 0)
                {
                    Monday = monday.AddDays(-(int)monday.DayOfWeek + (int)DayOfWeek.Monday);
                }
                Appointments = await _appointmentService.GetAllAppoinmentByDate(acc.Id, Monday, Monday.AddDays(7));
                await _hubContext.Clients.All.SendAsync("UpdateProfessionalAppointmentInfo", new
                {
                    totalMyAppointment = TotalMyAppointment
                }
                .ToString());
                return new PartialViewResult
                {
                    ViewName = "_PatientAppointments",
                    StatusCode = 200,
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
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

        public async Task<IActionResult> OnGetCancelAppointment(int id)
        {
            try
            {
                bool success = await _appointmentService.ChangeAppointmentStatus(id, AppointmentStatus.Rejected);
                if (success)
                {
                    var textAcc = HttpContext.Session.GetString("User");
                    var acc = JsonConvert.DeserializeObject<GeneralUserDto>(textAcc);
                    Monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                    Appointments = await _appointmentService.GetAllAppoinmentByDate(acc.Id, Monday, Monday.AddDays(7));
                    await _hubContext.Clients.All.SendAsync("UpdateProfessionalAppointmentInfo", new
                    {
                        totalMyAppointment = TotalMyAppointment
                    }
                    .ToString());
                    return new PartialViewResult
                    {
                        ViewName = "_PatientAppointments",
                        StatusCode = 200,
                        ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                        {
                            Model = this
                        }
                    };
                }
                return new StatusCodeResult(500);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new StatusCodeResult(500);
            }
        }
    }
}
