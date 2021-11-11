using Data.InterFace;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) :
            base(context)
        {
        }

        public async Task<Employee> GetEmployee
            (string id, bool trackChanges = false, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(e => e.Id == Guid.Parse(id), trackChanges)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Employee>> GetEmployees(CancellationToken cancellationToken = default)
        {
            return await FindAll(cancellationToken).ToListAsync(cancellationToken);
        }
    }
}