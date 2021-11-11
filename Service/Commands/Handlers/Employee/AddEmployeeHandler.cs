using AutoMapper;
using Data.InterFace;
using MediatR;
using Service.Commands.Models.Employee;
using Service.Employee.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using Utility.Enums;

namespace Service.Commands.Handlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand>
    {
        private IMediator _mediator { get; set; }
        private IUnitOfWork _unitOfWork { get; }
        public IMapper _mapper { get; }

        public AddEmployeeHandler(IMediator mediator, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var des = _mapper.Map<Entities.Models.Employee>(request.Dto);

            // insert 
            await _unitOfWork.EmployeeRepository.AddAsync(des, cancellationToken);

            //event
            AddEmployeeEvent addEmployeeEvent = new AddEmployeeEvent(request.Dto, nameof(AddEmployeeCommand), DateTime.UtcNow, TypeEvent.Add, nameof(AddEmployeeEvent));

            await _mediator.Publish(addEmployeeEvent, cancellationToken);
            return Unit.Value;
        }
    }
}
