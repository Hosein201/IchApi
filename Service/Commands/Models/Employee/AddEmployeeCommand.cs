using MediatR;
using Service.Dto;

namespace Service.Commands.Models.Employee
{
    public class AddEmployeeCommand : IRequest
    {
        public EmployeeDto Dto { get; set; }

        public AddEmployeeCommand(EmployeeDto dto)
        {
            this.Dto = dto;
        }
    }
}
