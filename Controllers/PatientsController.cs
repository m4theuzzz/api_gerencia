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

        public PatientsController(
            ApplicationDbContext? context
        )
        {
            _context = context != null ? context : new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> Get()
        {
            var patients = _context.patients.ToList();
            if (patients.Count == 0)
            {
                return NotFound();
            }
            return patients;
        }

        [HttpGet("{id}")]
        public ActionResult<Patient> Get(int id)
        {
            var patient = _context.patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            return patient;
        }

        [HttpPost]
        public void Post([FromBody] Patient patient)
        {
            _context.patients.Add(patient);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Patient patient)
        {
            var patientToUpdate = _context.patients.Find(id);

            if (patientToUpdate == null)
            {
                NotFound();
                return;
            }

            patientToUpdate.nome = patient.nome;
            patientToUpdate.sobrenome = patient.sobrenome;
            patientToUpdate.sexo = patient.sexo;
            patientToUpdate.nascimento = patient.nascimento;
            patientToUpdate.altura = patient.altura;
            patientToUpdate.peso = patient.peso;
            patientToUpdate.cpf = patient.cpf;
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var patientToDelete = _context.patients.Find(id);
            if (patientToDelete == null)
            {
                NotFound();
                return;
            }
            _context.patients.Remove(patientToDelete);
            _context.SaveChanges();
        }
    }
}
