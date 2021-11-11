using Entities.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Data.InterFace
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetEmployee(string id, bool trackChanges = false, CancellationToken cancellationToken = default);
        Task<IEnumerable<Employee>> GetEmployees(CancellationToken cancellationToken = default);
    }
}
