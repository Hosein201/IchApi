using Data;
using Data.NoSqlRepository.MongoDb;
using MediatR;
using Service.Dto;
using Service.Employee.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Events.Handlers
{
    public class DeleteEmployeeEventHandler : INotificationHandler<DeleteEmployeeEvent>
    {
        public readonly IMongoRepository<CommonEvent<EmployeeDto>, EmployeeDto> _mongoRepository;
        public DeleteEmployeeEventHandler(IMongoRepository<CommonEvent<EmployeeDto>, EmployeeDto> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task Handle(DeleteEmployeeEvent notification, CancellationToken cancellationToken)
        {
            //get 
            var eventLog = await _mongoRepository.GetByCondition(g => g.ModelEvent.Id == notification.ModelEvent.Id);

            //delete
            await _mongoRepository.DeleteAsync(eventLog, cancellationToken);
        }
    }
}
