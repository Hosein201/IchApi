using AutoMapper;
using Data;
using Data.NoSqlRepository.MongoDb;
using MediatR;
using Service.Dto;
using Service.Queries.Models.Employee;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Queries.Handlers.Employee
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<EmployeeDto>>
    {
        private readonly IMongoRepository<CommonEvent<EmployeeDto>, EmployeeDto> mongoRepository;
        private IMapper Mapper { get; }

        public GetAllEmployeeHandler(IMongoRepository<CommonEvent<EmployeeDto>, EmployeeDto> mongoRepository, IMapper mapper)
        {
            this.mongoRepository = mongoRepository;
            this.Mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var source = await mongoRepository.GetAllAsync(cancellationToken);
            var destination = Mapper.Map<IEnumerable<EmployeeDto>>(source);
            return await Task.FromResult(destination);
        }
    }
}