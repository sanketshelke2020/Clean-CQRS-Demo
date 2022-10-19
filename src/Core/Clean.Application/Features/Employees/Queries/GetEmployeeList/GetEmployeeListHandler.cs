using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, Response<List<GetEmployeeDto>>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public GetEmployeeListHandler(IEmployeeRepository employeeRepository,ILogger<GetEmployeeListHandler> logger, IMapper mapper)
        {
            this._employeeRepository = employeeRepository;
            this._logger = logger;
            this._mapper = mapper;
        }

        async Task<Response<List<GetEmployeeDto>>> IRequestHandler<GetEmployeeListQuery, Response<List<GetEmployeeDto>>>.Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initiated!");
            var employee = await _employeeRepository.ListAllAsync();
            var data = _mapper.Map<List<GetEmployeeDto>>(employee);
            var response = new Response<List<GetEmployeeDto>>(data);
            return response;
        }
    }
}
