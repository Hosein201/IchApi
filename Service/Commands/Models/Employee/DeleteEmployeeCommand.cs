using MediatR;

namespace Service.Commands.Models.Employee
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public string EmployeeId { get; set; }

        public DeleteEmployeeCommand(string employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
