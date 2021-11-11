using Data;
using Data.NoSqlRepository.MongoDb;
using MediatR;
using Service.Dto;
using Service.Employee.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Events.Handlers
{
    public class AddEmployeeEventHandler : INotificationHandler<AddEmployeeEvent>
    {
        private readonly IMongoRepository<CommonEvent<EmployeeDto>, EmployeeDto> mongoRepository;

        public AddEmployeeEventHandler(IMongoRepository<CommonEvent<EmployeeDto>, EmployeeDto> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }

        public async Task Handle(AddEmployeeEvent notification, CancellationToken cancellationToken)
        {
            var entity = new CommonEvent<EmployeeDto>
                (notification.ModelEvent, notification.CommandName, notification.EventDate, notification.TypeEvent, notification.NameEvent);
            await mongoRepository.InsertOneAsync(entity, cancellationToken);
        }
    }
}
