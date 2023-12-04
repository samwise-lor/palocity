using Api.Controllers;
using Api.Dtos.Dependent;
using Api.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Query
{
    public class DependentQueryById
    {
        public class Query : IRequest<Result<GetDependentDto>> 
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetDependentDto>>
        {
            private readonly EmployeeContext _context;
            private readonly IMapper _mapper;

            public Handler(EmployeeContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<GetDependentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var dependent = await _context.Dependents
                    .ProjectTo<GetDependentDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return Result<GetDependentDto>.Success(dependent);
            }
        }
    }
}
