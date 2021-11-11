using Data.InterFace;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) :
            base(context)
        {
        }
    }
}
