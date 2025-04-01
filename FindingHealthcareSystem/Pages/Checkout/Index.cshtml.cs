using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Checkout
{
    public class IndexModel : PageModel
    {
        private readonly IPaymentService _paymentService;

        public IndexModel(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var response = await _paymentService.ExecutePaymentAsync(Request.Query);

                if (response.ResponseCode == "00")
                {
                    return Redirect("/checkout/success");
                }
                else
                {
                    return Redirect("/checkout/fail");
                }
            }
            catch (Exception ex)
            {
                return Redirect("/checkout/fail");
            }
        }
    }
}
