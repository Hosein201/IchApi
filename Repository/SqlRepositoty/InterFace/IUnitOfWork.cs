using System.Threading;
using System.Threading.Tasks;

namespace Data.InterFace
{
    public interface IUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; set; }
        IEmployeeRepository EmployeeRepository { get; set; }

        void SaveChange();
        Task AsyncSaveChange(CancellationToken cancellation = default);
    }
}
