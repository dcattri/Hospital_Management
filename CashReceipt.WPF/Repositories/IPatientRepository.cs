using System.Collections.Generic;
using System.Threading.Tasks;
using CashReceipt.WPF.Models;

namespace CashReceipt.WPF.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> AddAsync(Patient patient);
        Task<IEnumerable<Patient>> GetAllAsync();
    }
}