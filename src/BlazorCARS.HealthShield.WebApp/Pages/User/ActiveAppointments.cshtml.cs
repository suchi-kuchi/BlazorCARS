using BlazorCARS.HealthShield.Utility.Response;
using BlazorCARS.HealthShield.Utility;
using BlazorCARS.HealthShield.WebApp.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using BlazorCARS.HealthShield.WebApp.Model.DTO;
using BlazorCARS.HealthShield.WebApp.Services;
using BlazorCARS.HealthShield.WebApp.Model.DTO.Appointment;

namespace BlazorCARS.HealthShield.WebApp.Pages.User
{
    public class ActiveAppointmentsModel : PageModel
    {
      
        private readonly IVaccineRegistrationService _vaccineserivce;
        public string ErrorMessage { get; set; }
        public List<ActiveAppointmentDTO> ActiveAppointmentlist { get; set; }

        public ActiveAppointmentsModel(IVaccineRegistrationService VaccineService)
        {
            this._vaccineserivce = VaccineService;
        }

        public async Task<IActionResult> OnGet()
        {
            int id = 0;
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32(SessionData.Discrimination).ToString()))
                return Redirect("/Logout");
            else
                id = int.Parse(HttpContext.Session.GetInt32(SessionData.Discrimination).ToString());

            string token = HttpContext.Session.GetString(SessionData.Token);

            var response = await _vaccineserivce.GetActiveappoinmentAsync<APIResponse>(id, token);
            if (response != null && response.IsSuccess)
            {
                this.ActiveAppointmentlist = JsonConvert.DeserializeObject<List<ActiveAppointmentDTO>>(Convert.ToString(response.Result));
            }

            return Page();
        }
    }
}