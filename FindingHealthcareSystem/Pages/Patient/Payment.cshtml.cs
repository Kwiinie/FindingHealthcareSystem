using BusinessObjects.DTOs.Payment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Patient
{
    public class PaymentModel : PageModel
    {
        private readonly IPaymentService _paymentService;

        public PaymentModel(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public List<PaymentDto> PatientPayments { get; set; }

        [BindProperty]
        public int UserId { get; set; }

        public async Task OnGetAsync()
        {
            PatientPayments = await _paymentService.GetPaymentsByPatientIdAsync(UserId);
        }
    }
}
