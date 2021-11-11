using MediatR;
using Service.Dto;
using System.Collections.Generic;

namespace Service.Queries.Models.Employee
{
    public class GetAllEmployeeQuery : IRequest<IEnumerable<EmployeeDto>>
    {
    }
}
