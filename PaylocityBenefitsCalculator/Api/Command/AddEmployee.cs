using Api.Controllers;
using Api.Dtos.Employee;
using Api.Models;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using MediatR;
using System;
using System.Diagnostics;

namespace Api.Command
{
    public class AddEmployee
    {

        public class Command : IRequest<Result<Unit>>
        {
            public Employee Employee { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly EmployeeContext _context;
            private readonly IMapper _mapper;

            public Handler(EmployeeContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                Relationship validateRelationship = Relationship.DomesticPartner | Relationship.Spouse;
                var dependentList = request.Employee.Dependents.Where(f => f.Relationship == (validateRelationship & f.Relationship)).Count();

                if (dependentList > 1) return Result<Unit>.Failure("Employe can have either spouse or domestic partner");

                _context.Employees.Add(request.Employee);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to add employee");

                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}
