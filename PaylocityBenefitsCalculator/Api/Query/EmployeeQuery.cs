using Api.Controllers;
using Api.Dtos.Employee;
using Api.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Query
{
    public class EmployeeQuery
    {
        public class Query : IRequest<Result<List<GetEmployeeDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GetEmployeeDto>>>
        {
            private readonly EmployeeContext _context;
            private readonly IMapper _mapper;

            public Handler(EmployeeContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<GetEmployeeDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var test = _context.Employees.ToList();
                var employees = await _context.Employees
                    .ProjectTo<GetEmployeeDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                return Result<List<GetEmployeeDto>>.Success(employees);
            }
        }
    }
}
