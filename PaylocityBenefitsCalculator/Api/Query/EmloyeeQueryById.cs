using Api.Controllers;
using Api.Dtos.Employee;
using Api.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Query
{
    public class EmloyeeQueryById
    {

        public class Query : IRequest<Result<GetEmployeeDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetEmployeeDto>>
        {
            private readonly EmployeeContext _context;
            private readonly IMapper _mapper;

            public Handler(EmployeeContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<GetEmployeeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees
                    .ProjectTo<GetEmployeeDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return Result<GetEmployeeDto>.Success(employee);
            }
        }
    }
}
