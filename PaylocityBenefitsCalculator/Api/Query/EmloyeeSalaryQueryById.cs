﻿using Api.Controllers;
using Api.Dtos;
using Api.Models;
using Api.Services;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Query
{
    public class EmloyeeSalaryQueryById 
    {
        public class Query : IRequest<Result<GetEmployeeSalaryDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetEmployeeSalaryDto>>
        {
            private readonly EmployeeContext _context;
            private readonly IMapper _mapper;
            private readonly ISalaryCalculatorService _salaryCalculatorService;

            public Handler(EmployeeContext context, IMapper mapper, ISalaryCalculatorService salaryCalculatorService)
            {
                _context = context;
                _mapper = mapper;
                _salaryCalculatorService = salaryCalculatorService;
            }

            public async Task<Result<GetEmployeeSalaryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                //var employee = await _context.Employees.Include(nameof(Dependent))
                //    .SingleOrDefaultAsync(x => x.Id == request.Id);
                var employee = await _context.Employees.Include("Dependents")
                    .SingleOrDefaultAsync(x => x.Id == request.Id);

                if (employee == null) return new Result<GetEmployeeSalaryDto>();

                var calculatedSalary = _salaryCalculatorService.CalculateEmployeeSalary(employee);

                var hello = _mapper.Map<GetEmployeeSalaryDto>(calculatedSalary); //_mapper.ProjectTo<GetEmployeeSalaryDto>((IQueryable)calculatedSalary);                

                return Result<GetEmployeeSalaryDto>.Success(_mapper.Map<GetEmployeeSalaryDto>(calculatedSalary));
            }
        }
    }    
}
