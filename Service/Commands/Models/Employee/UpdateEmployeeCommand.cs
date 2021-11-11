using MediatR;
using Service.Dto;

namespace Service.Commands.Models.Employee
{
    public class UpdateEmployeeCommand :IRequest
    {
        public EmployeeDto Dto { get; set; }
        public UpdateEmployeeCommand(EmployeeDto dto)
        {
            Dto = dto;
        }
    }
}
