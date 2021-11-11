using AutoMapper;
using Data.InterFace;
using MediatR;
using Service.Commands.Models.Employee;
using Service.Dto;
using Service.Employee.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Commands.Handlers.Employee
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public DeleteEmployeeHandler(IUnitOfWork unitOfWork, IMediator mediator, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            //get
            var source = await unitOfWork.EmployeeRepository.GetEmployee(request.EmployeeId, false, cancellationToken);

            //delete
            unitOfWork.EmployeeRepository.Delete(source);
            //event
            var destination = mapper.Map<EmployeeDto>(source);
            await mediator.Publish(new DeleteEmployeeEvent(destination, nameof(DeleteEmployeeCommand), DateTime.UtcNow, Utility.Enums.TypeEvent.Delete,
                nameof(DeleteEmployeeEvent)));
            return await Task.FromResult(true);
        }
    }
}
