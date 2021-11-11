using AutoMapper;
using Data;
using Data.NoSqlRepository.MongoDb;
using MediatR;
using Service.Dto;
using Service.Queries.Models.Employee;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Queries.Handlers.Employee
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeeQuery, EmployeeDto>
    {
        private readonly IMongoRepository<CommonEvent<EmployeeDto>, EmployeeDto> mongoRepository;
        private IMapper Mapper { get; }

        public GetEmployeeHandler(IMongoRepository<CommonEvent<EmployeeDto>, EmployeeDto> mongoRepository, IMapper mapper)
        {
            this.mongoRepository = mongoRepository;
            this.Mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var source = await mongoRepository.GetByIdAsync(request.Id, cancellationToken);
            var destination = Mapper.Map<EmployeeDto>(source);
            return await Task.FromResult(destination);
        }
    }
}