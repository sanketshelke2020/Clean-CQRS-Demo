using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Features.Categories.Commands.CreateCategory;
using Clean.Application.Responses;
using Clean.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Commands.CreateStudent
{
    public class RemoveStudentCommandHandler : IRequestHandler<CreateStudentCommand, Response<CreateStudentDto>>
    {
        private readonly ILogger<RemoveStudentCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public RemoveStudentCommandHandler(ILogger<RemoveStudentCommandHandler> logger,IMapper mapper, IStudentRepository studentRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._studentRepository = studentRepository;
        }
        public async Task<Response<CreateStudentDto>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Create Student Handler Started!");
            var data = await _studentRepository.AddAsync(_mapper.Map<Student>(request));
            _logger.LogInformation("Create Student Handler Started!");
            var student = _mapper.Map<CreateStudentDto>(data);
            var response = new Response<CreateStudentDto>(student);
            return response;
        }
    }
}
