using MediatR;
using Service.Dto;

namespace Service.Queries.Models.Employee
{
    public class GetEmployeeQuery : IRequest<EmployeeDto>
    {
        public string Id { get; set; }
    }
}
