using Microsoft.AspNetCore.Mvc;
using examtask.Models;
using examtask.Services;
using Microsoft.VisualBasic.FileIO;

namespace examtask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/Patients
        [HttpGet]
        public IActionResult GetAllPatients()
        {
            try
            {
                var patients = _patientService.GetAll();
                return Ok(patients);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/Patients/{id}
        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            try
            {
                var patient = _patientService.GetpatientById(id);
                return Ok(patient);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/Patients/name/{name}
        [HttpGet("name/{name}")]
        public IActionResult GetPatientByName(string name)
        {
            try
            {
                var patient = _patientService.GetpatientByName(name);
                return Ok(patient);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/Patients/search/{name}
        [HttpGet("search/{name}")]
        public IActionResult SearchPatientsByName(string name)
        {
            try
            {
                var patients = _patientService.GetPatientByName(name);
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/Patients
        [HttpPost]
        public IActionResult AddPatient(string name, int age, string gender)

        {
            var patient = new patients { PatientName = name, age = age, gender = gender };
            if (patient == null)
            {
                return BadRequest(new { message = "Patient data is required." });
            }

            try
            {
                _patientService.AddPatientname(patient);
                return CreatedAtAction(nameof(GetPatientById), new { id = patient.PId }, patient);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

