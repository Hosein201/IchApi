using AutoMapper;
using Data.InterFace;
using MediatR;
using Service.Commands.Models.Employee;
using Service.Events.Employee;
using System;
using System.Threading;
using System.Threading.Tasks;
using Utility.Enums;

namespace Service.Commands.Handlers.Employee
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        public IMediator mediator;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateEmployeeHandler(IMediator mediator, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var source = await unitOfWork.EmployeeRepository.GetEmployee(request.Dto.Id, true, cancellationToken);
            var des = mapper.Map<Entities.Models.Employee>(request.Dto);
            unitOfWork.EmployeeRepository.Update(des);


            await mediator.Publish(new UpdateEmployeeEvent(request.Dto, nameof(UpdateEmployeeCommand), DateTime.UtcNow, TypeEvent.Update, nameof(UpdateEmployeeEvent)));

            return Unit.Value;
        }
    }
}
