using Data.InterFace;
using Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _dbContext;
        public ICompanyRepository CompanyRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            CompanyRepository = new CompanyRepository(_dbContext);
            EmployeeRepository = new EmployeeRepository(_dbContext);
        }

        public async Task AsyncSaveChange(CancellationToken cancellation = default)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.SaveChangesAsync(cancellation);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new Exception();//TODO
                }
            }
        }

        public void SaveChange()
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new Exception();//TODO
                }
            }
        }
    }
}
