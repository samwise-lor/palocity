using Api.Controllers;
using Api.Dtos.Dependent;
using Api.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Query
{
    public class DependentQuery
    {
        public class Query : IRequest<Result<List<GetDependentDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GetDependentDto>>>
        {
            private readonly EmployeeContext _context;
            private readonly IMapper _mapper;

            public Handler(EmployeeContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<GetDependentDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var dependents = await _context.Dependents
                    .ProjectTo<GetDependentDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                return Result<List<GetDependentDto>>.Success(dependents);
            }
        }
    }
}
