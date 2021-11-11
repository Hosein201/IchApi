using Data;
using Data.NoSqlRepository.MongoDb;
using MediatR;
using Service.Dto;
using Service.Events.Employee;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Events.Handlers
{
    public class UpdateEmployeeEventHandler : INotificationHandler<UpdateEmployeeEvent>
    {
        public IMongoRepository<CommonEvent<EmployeeDto>, EmployeeDto> mongoRepository;

        public UpdateEmployeeEventHandler(IMongoRepository<CommonEvent<EmployeeDto>, EmployeeDto> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }

        public async Task Handle(UpdateEmployeeEvent notification, CancellationToken cancellationToken)
        {
            //get
            var source = await mongoRepository.GetByCondition(e => e.ModelEvent.Id == notification.ModelEvent.Id);
            //delete
            await mongoRepository.DeleteAsync(source, cancellationToken);
        }
    }
}
