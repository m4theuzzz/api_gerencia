using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.Data;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/pacientes")]
    public class PatientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext? context)
        {
            if (context == null)
            {
                // string options = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
                _context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            }
            else
            {
                _context = context;
            }
        }

        [HttpGet("/all")]
        public ActionResult<IEnumerable<Patient>> Get()
        {
            var patients = _context.Patients.ToList();
            if (patients.Count == 0)
            {
                return NotFound();
            }
            return patients;
        }

        [HttpGet("{id}")]
        public ActionResult<Patient> Get(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            return patient;
        }

        [HttpPost]
        public void Post([FromBody] Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Patient patient)
        {
            var patientToUpdate = _context.Patients.Find(id);

            if (patientToUpdate == null)
            {
                NotFound();
                return;
            }

            patientToUpdate.Nome = patient.Nome;
            patientToUpdate.Sobrenome = patient.Sobrenome;
            patientToUpdate.Sexo = patient.Sexo;
            patientToUpdate.Nascimento = patient.Nascimento;
            patientToUpdate.Idade = patient.Idade;
            patientToUpdate.Altura = patient.Altura;
            patientToUpdate.Peso = patient.Peso;
            patientToUpdate.CPF = patient.CPF;
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var patientToDelete = _context.Patients.Find(id);
            if (patientToDelete == null)
            {
                NotFound();
                return;
            }
            _context.Patients.Remove(patientToDelete);
            _context.SaveChanges();
        }
    }
}
