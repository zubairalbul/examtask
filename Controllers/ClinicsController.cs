using examtask.Models;
using examtask.Services;
using Microsoft.AspNetCore.Mvc;

namespace examtask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClinicsController : ControllerBase
    {
        private readonly IClinicsService _clinicsService;

        public ClinicsController(IClinicsService clinicsService)
        {
            _clinicsService = clinicsService;
        }

        // GET: api/Clinics
        [HttpGet]
        public IActionResult GetAllClinics()
        {
            try
            {
                var clinics = _clinicsService.GetAll();
                return Ok(clinics);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/Clinics/{id}
        [HttpGet("{id}")]
        public IActionResult GetClinicById(int id)
        {
            try
            {
                var clinic = _clinicsService.GetClinicById(id);
                return Ok(clinic);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/Clinics/name/{name}
        [HttpGet("name/{name}")]
        public IActionResult GetClinicByName(string name)
        {
            try
            {
                var clinic = _clinicsService.GetClinicByName(name);
                return Ok(clinic);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/Clinics
        [HttpPost]
        public IActionResult AddClinic(string clinicName, int numberOfSlots)
        {
            var clinic = new Clinics
            {
                Specialization = clinicName,
                No_Slot = numberOfSlots
            };
            if (clinic == null)
            {
                return BadRequest(new { message = "Clinic data is required." });
            }

            try
            {
                _clinicsService.AddPClinicSlot(clinic);
                return CreatedAtAction(nameof(GetClinicById), new { id = clinic.CId }, clinic);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
