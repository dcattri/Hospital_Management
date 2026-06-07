using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CashReceipt.WPF.Data;
using CashReceipt.WPF.Models;

namespace CashReceipt.WPF.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly CashReceiptContext _db;
        public PatientRepository(CashReceiptContext db) => _db = db;

        public async Task<Patient> AddAsync(Patient patient)
        {
            _db.Patients.Add(patient);
            await _db.SaveChangesAsync();
            return patient;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _db.Patients.AsNoTracking().ToListAsync();
        }
    }
}